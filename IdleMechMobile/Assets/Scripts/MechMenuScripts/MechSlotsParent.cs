using BreakInfinity;
using Managers;
using TMPro;
using UnityEngine;

namespace MechMenuScripts
{
    public class MechSlotsParent : MonoBehaviour
    {
        [SerializeField] private MechSlot[] mechSlots;
        
        [SerializeField] private MonzManager monzManager;

        [SerializeField] private MechSelectionScreenManager mechSelectionScreenManager;

        public bool UnlockSlot(BigDouble priceToUnlock)
        {
            //Now we must do the logic here to handle reaching out to the MoneyManager and ensure we actually have the money to unlock this spot.
            return monzManager.TrySpend(priceToUnlock);
            //For now, we will be manually putting in the price for each slot, later I wish to update this to manage it mathematically

            //var index = System.Array.IndexOf(lockedSlots, slotCallingUnlock);
            //lockedSlots[index].SetActive(false);
            //unlockedSlots[index].SetActive(true);
        }

        public void SendCurrentMechSlotToManager(MechSlot currentMechSlot)
        {
            mechSelectionScreenManager.SetCurrentMechSlot(currentMechSlot);
        }

        public void UpdateMechSlotText(TextMeshProUGUI textToUpdate, string newText)
        {
            TextManager.UpdateAnyBasicText(textToUpdate, newText);
        }

        private string _tempNameHolder;
        private GameObject _overlayScreenHolder;
        public bool mechSelected;
        public void AffectMechSlot(string mechName, GameObject overlayScreen)
        {
            _tempNameHolder = mechName;
            _overlayScreenHolder = overlayScreen;
            mechSelected = true;
        }

        public string MechSlotRequestInfo(out GameObject overlayScreen)
        {
            overlayScreen = _overlayScreenHolder;
            return _tempNameHolder;
        }
    }
}
