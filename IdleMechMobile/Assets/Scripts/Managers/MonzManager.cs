using BreakInfinity;
using DataPersistence;
using MechMenuScripts;
using Serialized;
using UnityEngine;
using UnityEngine.Events;

namespace Managers
{
    public class MonzManager : Singleton<MonzManager>, IDataPersistence
    {
        private BigDouble _monzBigDoubleHolder;
        private BigDouble _monzPerCycle;
        private bool _isLoading;
        public bool IsLoading => _isLoading;
        
        // public UnityEvent DataChanged;
        public Event onMonzChanged;
        
        public BigDouble getCurrentMonz => _monzBigDoubleHolder;

        private void Start()
        {
            Debug.Log($"MM: {nameof(MonzManager)} started");
            if (_monzPerCycle < 1)
            {
                _monzPerCycle = 1;
            }
            UpdateStartMoneyText();
        }
        
        public void OnTimeCycleOver(GameObject go)
        {
            // Debug.Log($"MM: OnTimeCycleOver {go.name}");
            IncreaseMoney();
        }

        private void UpdateStartMoneyText()
        {
            Debug.Log($"MM: updating money text to {_monzBigDoubleHolder} and {_monzPerCycle}");
            TextManager.Instance.UpdateMonzText(_monzBigDoubleHolder);
            TextManager.Instance.UpdateCycleValueText(_monzPerCycle);
        }
        public void IncreaseMoney()
        {
            ModifyingMonzTotal(_monzPerCycle, true);
            onMonzChanged.Occurred(gameObject);
        }

        public void SetLoadBool(bool isLoading)
        {
            _isLoading = isLoading;
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
            TextManager.Instance.UpdateCycleValueText(_monzPerCycle);
        }
        
        public void UpdateCycleValue(BigDouble newCycleValue)
        {
            _monzPerCycle = newCycleValue;
            TextManager.Instance.UpdateCycleValueText(_monzPerCycle);
        }

        
        public bool TrySpend(BigDouble priceIncoming)
        {
            if (_isLoading) return true; // during load state, allow logic to run without impacting monz balance
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
            // OnDataChanged();
            onMonzChanged.Occurred(gameObject);
            // TextManager.Instance.UpdateMonzText(_monzBigDoubleHolder);
        }
        
        public bool UpgradeValue(PurchaseInfo info)
        {
            if (! _isLoading && !TrySpend(info.purchaseCost) ) // if not in load state, and you can't afford, false
            {
                return false;
            } 
            info.totalAmount++;
            
            info.purchaseCost = info.initialCost * info.totalAmount * 1.2;
            
            TextManager.Instance.UpdateMonzText(_monzBigDoubleHolder);
            TextManager.Instance.UpdateUpgradeCostText(info.purchaseCost, info.costTextConnection);
            return true;
        }
        public bool UpgradeValue(UpgradeInfo info)
        {
            // Debug.Log(info.upgradeCost);
            
            if (!TrySpend(info.upgradeCost))
            {
                Debug.Log($"MM: Can't spend {info.upgradeCost}", gameObject);
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
            
            TextManager.Instance.UpdateMonzText(_monzBigDoubleHolder);
            TextManager.Instance.UpdateUpgradeCostText(info.upgradeCost, info.costTextConnection);
            return true;
        }

        public void LoadData(GameData data)
        {
            SetLoadBool(true); // tell the monz manager that we are in load process, to not check or deduct money
            Debug.Log($"MM: in LoadData {data.totalMonzSaved} {data.monzPerCycleSaved}");
            ModifyingMonzTotal(data.totalMonzSaved, increase: true);  // use real methods to explicitly call logic in them
            ModifyCycleMonzValue(data.monzPerCycleSaved, increase: true);
            SetLoadBool(false); // tell the monz manager that we are in load process, to not check or deduct money
            onMonzChanged.Occurred(gameObject);
        }

        public void SaveData(ref GameData data)
        {
            Debug.Log($"MM: In SaveData {_monzBigDoubleHolder} {_monzPerCycle}");
            data.totalMonzSaved = _monzBigDoubleHolder;
            data.monzPerCycleSaved = _monzPerCycle;
        }

        
    }
}
