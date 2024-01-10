using BreakInfinity;
using MechMenuScripts;
using UnityEngine;
using UnityEngine.UI;

namespace ButtonScripts
{
    public class LockedMechSlotButton : ButtonParent
    {
        [SerializeField] private MechSlotsParent parentObject;
        [SerializeField] private BigDouble priceToUnlock;
        private void OnEnable()
        {
            if (!ButtonChild) ButtonChild = GetComponent<Button>();
            
            if(IsUnlocked) Managers.ButtonUnlockManager.UnlockButton(this);
            
            ButtonChild.onClick.AddListener(CallUnlockSlot);
        }

        private void CallUnlockSlot()
        {
            parentObject.UnlockSlot(gameObject, priceToUnlock);
        }
        private void OnDisable()
        {
            ButtonChild.onClick.RemoveListener(CallUnlockSlot);
            
            if(IsUnlocked) Managers.ButtonUnlockManager.UnlockButton(this);

        }
    }
}
