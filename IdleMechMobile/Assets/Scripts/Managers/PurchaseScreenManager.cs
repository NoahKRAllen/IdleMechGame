using ButtonScripts;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class PurchaseScreenManager : MonoBehaviour
    {
        [SerializeField] private Button[] emptyMechButtons;
        [SerializeField] private GameObject uiParent;
        [SerializeField] private GameObject mechOverlayOpenButton;
        [SerializeField] private ScreenManager screenManager;

        private GameObject _overlayScreen;
        private string _buttonText = string.Empty;

        //This will be what we pass into the button that is made, giving us the multiplier for that specific mech
        //dependent on how many previous different mechs have been made.
        private int _totalDifferentMechs;
        
        
        //These two functions are called off the same button click, doing the checks to ensure both have triggered
        //before calling the main function. This allows me to not have a script handle the calls so I'm not
        //crossing the two different ways up. 
        public void SetOverlayScreen(GameObject overlayScreen)
        {
            _overlayScreen = overlayScreen;
            if (!_buttonText.Equals(string.Empty))
            {
                UpdateEmptyMechSlot();
            }
        }
        public void SetButtonText(string buttonText)
        {
            _buttonText = buttonText;
            if (_overlayScreen)
            {
                UpdateEmptyMechSlot();
            }
        }
        
        private void UpdateEmptyMechSlot()
        {
            foreach (var button in emptyMechButtons)
            {
                if (!button.isActiveAndEnabled) continue;
                _totalDifferentMechs++;
                var modifiedButton = Instantiate(mechOverlayOpenButton, uiParent.transform);
                modifiedButton.GetComponent<MechOverlayOpenButton>().SetupOverlayButton(_overlayScreen, screenManager, _totalDifferentMechs);
                modifiedButton.transform.SetSiblingIndex(button.transform.GetSiblingIndex());
                
                button.GameObject().SetActive(false);
                TextManager.UpdateAnyBasicText(modifiedButton.GetComponentInChildren<TextMeshProUGUI>(), _buttonText);
                _overlayScreen = null;
                _buttonText = string.Empty;
                break;
            }
        }
    }
}
