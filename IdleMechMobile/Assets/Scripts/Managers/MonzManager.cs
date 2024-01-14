using BreakInfinity;
using DataPersistence;
using Serialized;
using UnityEngine;

namespace Managers
{
    public class MonzManager : MonoBehaviour, IDataPersistence
    {
        [SerializeField] private TextManager textManager;
        //TODO: This value needs to be saved in the save system
        private BigDouble _monzBigDoubleHolder;
        private BigDouble _monzPerCycle;
        
        private void Start()
        {
            if (_monzPerCycle == 0)
            {
                _monzPerCycle++;
            }
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
            textManager.UpdateCycleValueText(_monzPerCycle);
        }
        public void IncreaseMoney()
        {
            ModifyingMonzTotal(_monzPerCycle, true);
        }

        public void IncreaseCycleValue(BigDouble cycleValueUp)
        {
            ModifyCycleMonzValue(cycleValueUp, true);
        }
        private void ModifyCycleMonzValue(BigDouble valueToModifyBy, bool increase)
        {
            if (increase)
            {
                _monzPerCycle += valueToModifyBy;
            }
            else
            {
                _monzPerCycle -= valueToModifyBy;
            }
            textManager.UpdateCycleValueText(_monzPerCycle);
        }
        
        public void UpdateCycleValue(BigDouble newCycleValue)
        {
            _monzPerCycle = newCycleValue;
            textManager.UpdateCycleValueText(_monzPerCycle);
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
            if (!TrySpend(info.purchaseCost))
            {
                return false;
            } 
            info.totalAmount++;
            
            info.purchaseCost = info.initialCost * info.totalAmount * 1.2;
        

            textManager.UpdateMonzText(_monzBigDoubleHolder);
            textManager.UpdateUpgradeCostText(info.purchaseCost, info.costTextConnection);
            return true;
        }
        public bool UpgradeValue(UpgradeInfo info)
        {
            Debug.Log(info.upgradeCost);
            if (!TrySpend(info.upgradeCost))
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
            info.upgradeCost = info.initialCost * info.totalAmount * .8;
        

            textManager.UpdateMonzText(_monzBigDoubleHolder);
            textManager.UpdateUpgradeCostText(info.upgradeCost, info.costTextConnection);
            return true;
        }

        public void LoadData(GameData data)
        {
            _monzBigDoubleHolder = data.totalMonzSaved;
            _monzPerCycle = data.monzPerCycleSaved;
        }

        public void SaveData(ref GameData data)
        {
            data.totalMonzSaved = _monzBigDoubleHolder;
            data.monzPerCycleSaved = _monzPerCycle;
        }
    }
}
