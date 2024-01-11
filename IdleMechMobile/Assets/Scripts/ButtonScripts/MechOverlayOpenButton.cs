using MechMenuScripts;
using UnityEngine;
using UnityEngine.UI;

namespace ButtonScripts
{
    public class MechOverlayOpenButton : ButtonParent
    {
        private MechSlot _mechSlot;
        private GameObject _overlayScreen;
        //private IndividualMechScreen _mechScreen; ignoring this for now
        [SerializeField] private GameObject swapScreen;

        private void OnEnable()
        {
            if (!ButtonChild) ButtonChild = GetComponent<Button>();
            if (!_mechSlot) _mechSlot = GetComponent<MechSlot>();
            
            if (!_mechSlot.CheckMechSelected())
            {
                ButtonChild.onClick.AddListener(MechOverlaySwapScreen);
            }

            if (_mechSlot.CheckMechSelected())
            {
                _mechSlot.SetupOverlayButton();
            }
        }
        
        private void MechOverlaySwapScreen()
        {
            _mechSlot.PassAlongCurrentMechSlot();
            screenManagerChild.SwapScreenTo(swapScreen);
        }
        
        
        public void SetupOverlayButton(GameObject overlayScreen)
        {
            _overlayScreen = overlayScreen;
            ButtonChild.onClick.AddListener(OverlayScreen);

            //_mechScreen = _overlayScreen.GetComponent<IndividualMechScreen>();
        }
        private void OverlayScreen()
        {
            screenManagerChild.OpenOverlayScreen(_overlayScreen);
        }
        
        
        private void OnDisable()
        {
            if (!_mechSlot.CheckMechSelected())
            {
                ButtonChild.onClick.RemoveListener(MechOverlaySwapScreen);
            }
            else
            {
                ButtonChild.onClick.RemoveListener(OverlayScreen);
            }

        }
    }
}
