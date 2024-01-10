using BreakInfinity;
using MechMenuScripts;
using UnityEngine;
using UnityEngine.UI;

namespace ButtonScripts
{
    public class LockedMechSlotButton : MonoBehaviour
    {
        private Button _button;
        [SerializeField] private MechSlotsParent parentObject;
        [SerializeField] private BigDouble priceToUnlock;
        private void OnEnable()
        {
            if (!_button) _button = GetComponent<Button>();
            _button.onClick.AddListener(CallUnlockSlot);
        }

        private void CallUnlockSlot()
        {
            parentObject.UnlockSlot(gameObject, priceToUnlock);
        }
        private void OnDisable()
        {
            _button.onClick.RemoveListener(CallUnlockSlot);
        }
    }
}
