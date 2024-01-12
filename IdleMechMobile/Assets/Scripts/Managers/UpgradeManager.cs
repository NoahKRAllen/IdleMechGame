using BreakInfinity;
using Serialized;
using Unity.VisualScripting;
using UnityEngine;

namespace Managers
{
    public class UpgradeManager : MonoBehaviour
    {
        [SerializeField] private MonzManager monzManager;
        [SerializeField] private TimeCycleManager timeCycleManager;
        [SerializeField] private TotalMechsManager totalMechsManager;
        #region MechPurchaseRegion
        public bool CallPurchaseMech(PurchaseInfo info)
        {
            if (!monzManager.UpgradeValue(info)) return false;
            var totalValueOfAllMechs = !totalMechsManager.CheckAllMechCollection(info.mechName) ? totalMechsManager.AddMechToCollection(info) : totalMechsManager.UpdateMechInCollection(info);
            monzManager.UpdateTickValue(totalValueOfAllMechs);
            return true;
        }
        #endregion
        #region MechUpgradeRegion
        public bool CallUpgradeMech(UpgradeInfo info)
        {
            BigDouble totalValueOfAllMechs;
            if (!monzManager.UpgradeValue(info)) return false;
            if (!totalMechsManager.CheckAllMechCollection(info.mechName)) return false;
            else
            {
                totalValueOfAllMechs = totalMechsManager.UpdateMechInCollection(info);
            }
            monzManager.UpdateTickValue(totalValueOfAllMechs);
            
            
            return true;
        }
        #endregion
        #region OverallUpgradeRegion
        public void CallUpgradeCycleTimer(PurchaseInfo info)
        {
            if (monzManager.UpgradeValue(info))
            {
                timeCycleManager.DecreaseCycleTimer(info.totalValuePerMech);
            }
        }
        #endregion
    }
}
