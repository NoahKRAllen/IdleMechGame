using ButtonScripts;
using Managers;
using TMPro;
using UnityEngine;

namespace MechMenuScripts
{
    [RequireComponent(typeof(LockedMechSlotButton))]
    [RequireComponent(typeof(MechOverlayOpenButton))]
    public class MechSlot : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI buttonText;
        [SerializeField] private MechSlotsParent mechSlotsParent;
        // [SerializeField] public bool mechSelected;
        //TODO: Save this script, using the script enable to decide what the save hits, be it the required mech overlay 
        //or just the buttonText to state it is still a locked slot
        public LockedMechSlotButton lockedSlotButton;
        private MechOverlayOpenButton _mechOverlayOpenButton;
        
        private void OnEnable()
        {
            if (!lockedSlotButton) lockedSlotButton = GetComponent<LockedMechSlotButton>();
            if (!_mechOverlayOpenButton) _mechOverlayOpenButton = GetComponent<MechOverlayOpenButton>();
        }

        public void CallUpdateMechSlotText(string newText)
        {
            mechSlotsParent.UpdateMechSlotText(buttonText, newText);
        }
        public void CallUnlockSlot()
        {
            if (!mechSlotsParent.UnlockSlot(lockedSlotButton.GetPriceToUnlock()))
            {
                return;
            }
            TextManager.UpdateAnyBasicText(buttonText, "Empty Mech Slot");
            lockedSlotButton.enabled = false;
            _mechOverlayOpenButton.enabled = true;
        }

        public void SetupOverlayButton()
        {
            var mechName = mechSlotsParent.MechSlotRequestInfo(out var overlayScreen);
            
            // TODO: collect the army counts we have in this slot
            // TotalMechsManager.Instance.GetMech(mechName);
            
            Debug.Log($"MS: setting up overlay button for {mechName}", gameObject);
            mechSlotsParent.UpdateMechSlotText(buttonText, mechName);
            _mechOverlayOpenButton.SetupListeningOverlayButton(overlayScreen);
            mechSlotsParent.mechSelected = false;
        }

        public void PassActiveSlotUp()
        {
            mechSlotsParent.SetActiveMechSlot(this);
        }

        public MechSlot RequestActiveMechSlot()
        {
            return mechSlotsParent.CheckActiveMechSlot();
        }
        public bool CheckMechSelected()
        {
            return mechSlotsParent.mechSelected; // return if this particular slot has a value in it
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
