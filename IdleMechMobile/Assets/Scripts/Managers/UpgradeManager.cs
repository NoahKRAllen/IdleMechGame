using BreakInfinity;
using Serialized;
using UnityEngine;

namespace Managers
{
    public class UpgradeManager : Singleton<UpgradeManager>
    {

        #region MechPurchaseRegion

        public bool CallPurchaseMech(PurchaseInfo info)
        {
            if (!MonzManager.Instance.UpgradeValue(info))
            {
                Debug.Log($"can't purchase mech {info.mechName}");
                return false;
            }
            var totalValueOfAllMechs = TotalMechsManager.Instance.CheckAllMechCollection(info.mechName)
                ? TotalMechsManager.Instance.AddMechToCollection(info)
                : TotalMechsManager.Instance.UpdateMechInCollection(info);
            MonzManager.Instance.UpdateCycleValue(totalValueOfAllMechs);
            return true;
        }

        #endregion

        #region MechUpgradeRegion

        public bool CallUpgradeMech(UpgradeInfo info)
        {
            BigDouble totalValueOfAllMechs;
            if (!MonzManager.Instance.UpgradeValue(info)) return false;
            if (!TotalMechsManager.Instance.CheckAllMechCollection(info.mechName))
            {
                return false;
            }

            totalValueOfAllMechs = TotalMechsManager.Instance.UpdateMechInCollection(info);
            MonzManager.Instance.UpdateCycleValue(totalValueOfAllMechs);

            return true;
        }

        #endregion

        #region OverallUpgradeRegion

        public void CallUpgradeCycleTimer(PurchaseInfo info)
        {
            if (MonzManager.Instance.UpgradeValue(info))
            {
                TimeCycleManager.Instance.DecreaseCycleTimer(info.totalValuePerMech);
            }
        }

        #endregion

    }
}
