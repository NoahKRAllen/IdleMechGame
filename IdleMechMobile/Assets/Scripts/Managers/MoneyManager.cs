using BreakInfinity;
using UnityEngine;

namespace Managers
{
    public class MoneyManager : MonoBehaviour
    {
        [SerializeField] private TextManager textManager;
        private BigDouble _moneyIntHolder;
        [SerializeField]
        private BigDouble moneyPerTick = 1;

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
            textManager.UpdateMoneyText(_moneyIntHolder);
            textManager.UpdateCycleValueText(moneyPerTick);
        }
        public void IncreaseMoney()
        {
            _moneyIntHolder += moneyPerTick;
            textManager.UpdateMoneyText(_moneyIntHolder);
        }

        public void IncreaseTickValue(int valueUp)
        {
            moneyPerTick += valueUp;
            textManager.UpdateCycleValueText(moneyPerTick);
        }

        public bool UpgradeValue(UpgradeSelectionInfo info)
        {
            if (info.upgradeCost > _moneyIntHolder)
            {
                return false;
            }

            _moneyIntHolder -= info.upgradeCost;
            //This is the current way we calculate the cost of each upgrade, based off its initial cost times the total
            //amount of times its been upgraded
            info.totalAmount++;
            //This math formula needs to be fixed. After some researching there seems to be
            //the consensus that doing a variable multiplier, one that grows over the course of use
            //is the best way instead of doing a fixed value. So starting at 1.15 until a certain
            //amount is bought, then going to 1.2 or whatever. This scaling only works once
            //there are upgrades that increase the value each mech is generating.
            info.upgradeCost = info.initialCost * info.totalAmount;
        

            textManager.UpdateMoneyText(_moneyIntHolder);
            textManager.UpdateUpgradeCostText(info.upgradeCost, info.upgradeTextConnection);
            return true;
        }
    }
}
