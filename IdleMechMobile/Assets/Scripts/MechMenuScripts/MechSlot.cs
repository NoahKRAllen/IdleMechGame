using ButtonScripts;
using Managers;
using TMPro;
using UnityEngine;

namespace MechMenuScripts
{
    public class MechSlot : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI buttonText;
        [SerializeField] private MechSlotsParent mechSlotsParent;

        private LockedMechSlotButton _lockedSlotButton;
        private MechOverlayOpenButton _mechOverlayOpenButton;
    
        private void OnEnable()
        {
            if (!_lockedSlotButton) _lockedSlotButton = GetComponent<LockedMechSlotButton>();
            if (!_mechOverlayOpenButton) _mechOverlayOpenButton = GetComponent<MechOverlayOpenButton>();
        }

        public void CallUpdateMechSlotText(string newText)
        {
            mechSlotsParent.UpdateMechSlotText(buttonText, newText);
        }
        public void CallUnlockSlot()
        {
            if (!mechSlotsParent.UnlockSlot(_lockedSlotButton.GetPriceToUnlock()))
            {
                return;
            }
            TextManager.UpdateAnyBasicText(buttonText, "Empty Mech Slot");
            _lockedSlotButton.enabled = false;
            _mechOverlayOpenButton.enabled = true;
        }

        public void SetupOverlayButton()
        {
            var mechName = mechSlotsParent.MechSlotRequestInfo(out var overlayScreen);
            TextManager.UpdateAnyBasicText(buttonText, mechName);
            _mechOverlayOpenButton.SetupOverlayButton(overlayScreen);
        }

        public bool CheckMechSelected()
        {
            return mechSlotsParent.mechSelected;
        }
    }
}
