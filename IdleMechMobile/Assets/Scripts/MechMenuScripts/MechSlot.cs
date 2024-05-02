using ButtonScripts;
using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace MechMenuScripts
{
    // [RequireComponent(typeof(LockedMechSlotButton))]
    // [RequireComponent(typeof(MechOverlayOpenButton))]
    public class MechSlot : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI buttonText;
        [SerializeField] private MothershipManager mothershipManager;
        // [SerializeField] public bool mechSelected;
        //TODO: Save this script, using the script enable to decide what the save hits, be it the required mech overlay 
        //or just the buttonText to state it is still a locked slot
        public LockedMechSlotButton lockedSlotButton;
        private MechOverlayOpenButton _mechOverlayOpenButton;
        
        private void OnEnable()
        {
            if (!lockedSlotButton) lockedSlotButton = GetComponent<LockedMechSlotButton>();
            if (!_mechOverlayOpenButton) _mechOverlayOpenButton = GetComponent<MechOverlayOpenButton>();
            if (!mothershipManager) mothershipManager = GetComponent<MothershipManager>();
        }

        public void CallUpdateMechSlotText(string newText)
        {
            mothershipManager.UpdateMechSlotText(buttonText, newText);
        }
        public void CallUnlockSlot()
        {
            if (!mothershipManager.UnlockSlot(lockedSlotButton.GetPriceToUnlock()))
            {
                return;
            }
            TextManager.UpdateAnyBasicText(buttonText, "Empty Mech Slot");
            lockedSlotButton.enabled = false;
            _mechOverlayOpenButton.enabled = true;
        }

        public void SetupOverlayButton()
        {
            var mechName = mothershipManager.MechSlotRequestInfo(out var overlayScreen);
            
            // TODO: collect the army counts we have in this slot
            // TotalMechsManager.Instance.GetMech(mechName);
            
            Debug.Log($"MS: setting up overlay button for {mechName}", gameObject);
            mothershipManager.UpdateMechSlotText(buttonText, mechName);
            _mechOverlayOpenButton.SetupListeningOverlayButton(overlayScreen);
            mothershipManager.mechSelected = false;
        }

        public void PassActiveSlotUp()
        {
            mothershipManager.SetActiveMechSlot(this);
        }

        public MechSlot RequestActiveMechSlot()
        {
            return mothershipManager.CheckActiveMechSlot();
        }
        public bool CheckMechSelected()
        {
            return mothershipManager.mechSelected; // return if this particular slot has a value in it
        }


        #region SaveFunctions


        public bool GetMechSelected()
        {
            return _mechOverlayOpenButton.IsMechSelected();
        }
        public string GetTextObject()
        {
            return buttonText.text;
        }

        public bool IsButtonLocked()
        {
            return lockedSlotButton.enabled;
        }
        #endregion

        #region LoadFunctions

        public void UpdateButtonText(string savedText)
        {
            buttonText.text = savedText;
        }

        public void UpdateIsLocked(bool isLocked)
        {
            if (isLocked)
            {
                lockedSlotButton.enabled = true;
                _mechOverlayOpenButton.enabled = false;
            }
            else
            {
                lockedSlotButton.enabled = false;
                _mechOverlayOpenButton.enabled = true;
            }
        }
        
        #endregion        
    }
}
