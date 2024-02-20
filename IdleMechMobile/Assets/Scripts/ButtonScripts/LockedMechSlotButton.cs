using BreakInfinity;
using MechMenuScripts;
using UnityEngine;
using UnityEngine.UI;

namespace ButtonScripts
{
    [RequireComponent(typeof(MechSlot))]
    [RequireComponent(typeof(Button))]
    public class LockedMechSlotButton : ButtonParent
    {
        private MechSlot _mechSlot;
        [SerializeField] private BigDouble priceToUnlock;
        private void OnEnable()
        {
            if (!ButtonChild) ButtonChild = GetComponent<Button>();
            if (!_mechSlot) _mechSlot = GetComponent<MechSlot>();            
            ButtonChild.onClick.AddListener(_mechSlot.CallUnlockSlot);
            SendNewText();
        }

        private void SendNewText()
        {
            string newText = $"Locked Mech Slot\n\nSpend {priceToUnlock.ToDouble()} Monz to Unlock";
            _mechSlot.CallUpdateMechSlotText(newText);
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
