using BreakInfinity;
using Managers;
using UnityEngine;

namespace MechMenuScripts
{
    public class MechSlotsParent : MonoBehaviour
    {
        //This will hold all locked slots, allowing logic to be done on each in order instead of finagling with the hierarchy order.
        [SerializeField] private GameObject[] lockedSlots;

        //This will hold the unlocked slots, which need no logic done on them, however will need to be toggled on when the corresponding locked slot is toggled off
        [SerializeField] private GameObject[] unlockedSlots;

        [SerializeField] private MoneyManager moneyManager;
        public void UnlockSlot(GameObject slotCallingUnlock, BigDouble priceToUnlock)
        {
            //Now we must do the logic here to handle reaching out to the MoneyManager and ensure we actually have the money to unlock this spot.
            if (!moneyManager.TrySpend(priceToUnlock)) return;
            //For now, we will be manually putting in the price for each slot, later I wish to update this to manage it mathematically.
            
            
            var index = System.Array.IndexOf(lockedSlots, slotCallingUnlock);
            lockedSlots[index].SetActive(false);
            unlockedSlots[index].SetActive(true);
        }
        
    }
}
