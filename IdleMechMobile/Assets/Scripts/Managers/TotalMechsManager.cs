using System;
using System.Collections.Generic;
using System.Linq;
using BreakInfinity;
using DataPersistence;
using Serialized;
using UnityEngine;
using UnityEngine.Serialization;

namespace Managers
{
    public class TotalMechsManager : MonoBehaviour, IDataPersistence
    {
        //TODO: This list needs to be saved in the save system
        private List<MechCollection> _allMechs = new List<MechCollection>();
        [SerializeField] private MonzManager monzManager;

        public bool CheckAllMechCollection(string newMechName)
        {
            return _allMechs.All(mech => mech.MechName != newMechName);
        }

        public BigDouble AddMechToCollection(PurchaseInfo info)
        {
            _allMechs.Add(new MechCollection(info.mechName, info.totalAmount, 1));
            return TotalValueOfAllMechs();
        }

        public BigDouble UpdateMechInCollection(PurchaseInfo purchaseInfo)
        {
            var index = 0;
            for (; index < _allMechs.Count; index++)
            {
                var mech = _allMechs[index];
                if (mech.MechName != purchaseInfo.mechName) continue;
                mech.totalMechs = purchaseInfo.totalAmount;
                break;
            }

            return TotalValueOfAllMechs();
        }
        public BigDouble UpdateMechInCollection(UpgradeInfo upgradeInfo)
        {
            var index = 0;
            for (; index < _allMechs.Count; index++)
            {
                var mech = _allMechs[index];
                if (mech.MechName != upgradeInfo.mechName) continue;
                mech.totalUpgrades = upgradeInfo.totalAmount;
                break;
            }
            
            return TotalValueOfAllMechs();
        }

        private BigDouble TotalValueOfAllMechs()
        {
            BigDouble totalValue = default;
            var index = 0;
            for (; index < _allMechs.Count; index++)
            {
                var mech = _allMechs[index];
                totalValue += mech.totalMechs * mech.totalUpgrades;
            }

            return totalValue;
        }
        
        public void LoadData(GameData data)
        {
            _allMechs = data.allMechsSaved;
        }

        public void SaveData(ref GameData data)
        {
            data.allMechsSaved = _allMechs;
        }
    }
    [Serializable]
    public class MechCollection
    {
        public readonly string MechName;
        public BigDouble totalMechs;
        public BigDouble totalUpgrades;

        public MechCollection(string mechName, BigDouble totalMechs, BigDouble totalUpgrades)
        {
            MechName = mechName;
            this.totalMechs = totalMechs;
            this.totalUpgrades = totalUpgrades;
        }
    }
}
