using BreakInfinity;
using Serialized;
using UnityEngine;

namespace Managers
{
    public class MonzManager : MonoBehaviour
    {
        [SerializeField] private TextManager textManager;
        private BigDouble _monzBigDoubleHolder;
        [SerializeField] private BigDouble monzPerTick = 1000;

        private void Start()
        {
            //This if check will be modified to respond when we load in the playerprefs
            //If the playerpref is empty, we set the value to default
            //if (PlayerPrefs.GetInt(UpgradeCost))
            //{
            UpdateStartMoneyText();
            //    _currentUpgradeMoneyCost = PlayerPrefs.GetInt(UpgradeCost);
            //}
            
        }

        private void UpdateStartMoneyText()
        {
            textManager.UpdateMonzText(_monzBigDoubleHolder);
            textManager.UpdateCycleValueText(monzPerTick);
        }
        public void IncreaseMoney()
        {
            ModifyingMonzTotal(monzPerTick, true);
        }

        public void IncreaseTickValue(BigDouble cycleValueUp)
        {
            ModifyCycleMonzValue(cycleValueUp, true);
        }

        private void ModifyCycleMonzValue(BigDouble valueToModifyBy, bool increase)
        {
            if (increase)
            {
                monzPerTick += valueToModifyBy;
            }
            else
            {
                monzPerTick -= valueToModifyBy;
            }
            textManager.UpdateCycleValueText(monzPerTick);
        }
        public bool TrySpend(BigDouble priceIncoming)
        {
            if (priceIncoming > _monzBigDoubleHolder) return false;
            
            ModifyingMonzTotal(priceIncoming, false);
            return true;
        }

        private void ModifyingMonzTotal(BigDouble priceToModifyBy, bool increase)
        {
            if (increase)
            {
                _monzBigDoubleHolder += priceToModifyBy;
            }
            else
            {
                _monzBigDoubleHolder -= priceToModifyBy;
            }
            textManager.UpdateMonzText(_monzBigDoubleHolder);
        }
        
        public bool UpgradeValue(PurchaseInfo info)
        {
            if (TrySpend(info.purchaseCost))
            {
                return false;
            } 
            //This is the current way we calculate the cost of each upgrade, based off its initial cost times the total
            //amount of times its been upgraded
            info.totalAmount++;
            //This math formula needs to be fixed. After some researching there seems to be
            //the consensus that doing a variable multiplier, one that grows over the course of use
            //is the best way instead of doing a fixed value. So starting at 1.15 until a certain
            //amount is bought, then going to 1.2 or whatever. This scaling only works once
            //there are upgrades that increase the value each mech is generating.
            info.purchaseCost = info.initialCost * info.totalAmount;
        

            textManager.UpdateMonzText(_monzBigDoubleHolder);
            textManager.UpdateUpgradeCostText(info.purchaseCost, info.costTextConnection);
            return true;
        }
    }
}
