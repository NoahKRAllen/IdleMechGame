using UnityEngine;

namespace Managers
{
    public class UpgradeManager : MonoBehaviour
    {
        [SerializeField] private MoneyManager moneyManager;
        [SerializeField] private TimeCycleManager timeCycleManager;
        #region MechPurchaseRegion
        public void CallPurchaseMech(UpgradeSelectionInfo info)
        {
            //This needs to call increase tick value as the basic stat
            //Once this is in place, it will modify the basics of the tick value upgrades as the upgrade will be upgrading the value gained from each purchased/built mech
            //Anything else will be extra fluff, like another mech visual in the army or whatever
        }
        #endregion
        #region MechUpgradeRegion
        public void CallUpgradeCycleValue(UpgradeSelectionInfo info)
        {
            if (moneyManager.UpgradeValue(info))
            {
                //Currently hardcoded as I get things working
                //This will be changed to info.Multiplier once its working
                moneyManager.IncreaseTickValue(info.multiplierAmount);
            }
        }
        #endregion
        #region OverallUpgradeRegion
        public void CallUpgradeCycleTimer(UpgradeSelectionInfo info)
        {
            if (moneyManager.UpgradeValue(info))
            {
                timeCycleManager.DecreaseCycleTimer(info.multiplierAmount);
            }
        }
        #endregion
    }
}
