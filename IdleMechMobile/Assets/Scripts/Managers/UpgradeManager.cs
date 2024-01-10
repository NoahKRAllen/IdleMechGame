using Serialized;
using UnityEngine;
using UnityEngine.Serialization;

namespace Managers
{
    public class UpgradeManager : MonoBehaviour
    {
        [FormerlySerializedAs("moneyManager")] [SerializeField] private MonzManager monzManager;
        [SerializeField] private TimeCycleManager timeCycleManager;
        #region MechPurchaseRegion
        public void CallPurchaseMech(PurchaseInfo info)
        {
            //This needs to call increase tick value as the basic stat
            //Once this is in place, it will modify the basics of the tick value upgrades as the upgrade will be upgrading the value gained from each purchased/built mech
            //Anything else will be extra fluff, like another mech visual in the army or whatever
        }
        #endregion
        #region MechUpgradeRegion
        public void CallUpgradeCycleValue(PurchaseInfo info)
        {
            if (monzManager.UpgradeValue(info))
            {
                //Currently hardcoded as I get things working
                //This will be changed to info.Multiplier once its working
                monzManager.IncreaseTickValue(info.multiplierAmount);
            }
        }
        #endregion
        #region OverallUpgradeRegion
        public void CallUpgradeCycleTimer(PurchaseInfo info)
        {
            if (monzManager.UpgradeValue(info))
            {
                timeCycleManager.DecreaseCycleTimer(info.multiplierAmount);
            }
        }
        #endregion
    }
}
