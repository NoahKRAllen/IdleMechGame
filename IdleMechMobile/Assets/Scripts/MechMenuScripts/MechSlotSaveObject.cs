using BreakInfinity;
using ButtonScripts;
using DataPersistence;
using TMPro;
using UnityEngine;

namespace MechMenuScripts
{
    public class MechSlotSaveObject : MonoBehaviour
    {
        //From mechslot, we need the buttonText, and which of the two buttons are active
        private MechSlot _mechSlot;
        private string _buttonText;
        private bool _isLocked;
        
        
        //From lockedslot, we need the price to unlock
        private LockedMechSlotButton _lockedSlot;
        private BigDouble _priceToUnlock;
        
        
        
        //From overlayslot, we need the overlayscreen and whether it has had a mech selected or not
        private MechOverlayOpenButton _overlaySlot;
        private GameObject _overlayScreen;
        private bool _mechSelected;
        
        
        private void OnEnable()
        {
            if (!_mechSlot)
            {
                _mechSlot = GetComponent<MechSlot>();
                _buttonText = _mechSlot.GetTextObject();
                _isLocked = _mechSlot.lockedSlotButton;
            }

            if (!_lockedSlot)
            {
                _lockedSlot = GetComponent<LockedMechSlotButton>();
                _priceToUnlock = _lockedSlot.GetPriceToUnlock();
            }

            if (!_overlaySlot)
            {
                _overlaySlot = GetComponent<MechOverlayOpenButton>();
                _overlayScreen = _overlaySlot.GetOverlayScreen();
                _mechSelected = _overlaySlot.IsMechSelected();
            }
        }

        public void RebuildButton()
        {
            _mechSlot.UpdateButtonText(_buttonText);
            _mechSlot.UpdateIsLocked(_isLocked);
        }

    }
}
