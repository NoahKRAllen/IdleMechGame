using BreakInfinity;
using MechMenuScripts;
using UnityEngine;
using UnityEngine.UI;

namespace ButtonScripts
{
    public class LockedMechSlotButton : ButtonParent
    {
        private MechSlot _mechSlot;
        [SerializeField] private BigDouble priceToUnlock;
        private void OnEnable()
        {
            if (!ButtonChild) ButtonChild = GetComponent<Button>();
            if (!_mechSlot) _mechSlot = GetComponent<MechSlot>();            
            ButtonChild.onClick.AddListener(_mechSlot.CallUnlockSlot);
        }
        public BigDouble GetPriceToUnlock()
        {
            return priceToUnlock;
        }
        private void OnDisable()
        {
            ButtonChild.onClick.RemoveListener(_mechSlot.CallUnlockSlot);
        }
    }
}
