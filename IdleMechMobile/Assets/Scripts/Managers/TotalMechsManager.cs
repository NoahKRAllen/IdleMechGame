using System;
using System.Collections.Generic;
using System.Linq;
using BreakInfinity;
using ButtonScripts;
using DataPersistence;
using MechMenuScripts;
using Serialized;
using UnityEngine;

namespace Managers
{
    public class TotalMechsManager : Singleton<TotalMechsManager>, IDataPersistence
    {
        private List<MechCollection> _allMechs = new List<MechCollection>();

        public bool CheckAllMechCollection(string newMechName)
        {
            if (_allMechs == null) return false;
            return _allMechs.All(mech => mech.mechName != newMechName);
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
                if (mech.mechName != purchaseInfo.mechName) continue;
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
                if (mech.mechName != upgradeInfo.mechName) continue;
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
            if (data == null)
            {
                Debug.Log($"got null data in LoadData", gameObject);
                return;
            }
            _allMechs = data.allMechsSaved;
            if (_allMechs == null)
            {
                Debug.Log($"had no mechs or upgrades in savedata.  ", gameObject);
                return;
            }
            Debug.Log($"seeing allMechs: total mech slots filled of {_allMechs.Count}");
            if ( _allMechs == null || _allMechs.Count == 0) return;

            // TODO: Update the slots to reflect the mechs loaded
            //   and remove all the IDataPersistence logic on those mechslot and mech slot parent 

            // find all objects of type MechSlot
            // var mechSlotObjects = GameObject.FindObjectsOfType<MechSlot>();
            var mechSlotParent = GameObject.FindObjectOfType<MechSlotsParent>();
            
            // TODO: this is bad practice to directly access, but I want them in the same order as is stored in the Inspector
            // TODO: perhaps bring mech slot parent list into TotalMechsManager and remove mechslotsparent? 
            var mechSlotObjects = mechSlotParent.mechSlots;
            
            var index = 0;

            if (_allMechs.Count != mechSlotObjects.Count())
            {
                Debug.LogWarning($"There are {mechSlotObjects.Count()} mech slots in the scene, but there are {_allMechs.Count} mechs in the save file.", gameObject);
            }

            if (_allMechs.Count > 0)
            {
                // reset monzPerCycleSaved to 0, as we will be adding to it during our load below
                data.monzPerCycleSaved = 0;
            }
            
            MonzManager.Instance.SetLoadBool(true); // tell MonzManager that we are in load process, to not check or deduct monz
            foreach (var mechSlotObject in mechSlotObjects)  // FIXME: switch this to loop over the objects from the save slot instead of the ones in the UI
            {
                // assuming that we have something in the first index slot, assign it to the first mechSlotObject
                Debug.Log($"index: {index}  totalMechs: {_allMechs[index].totalMechs} and count: {_allMechs.Count}");
                if ( _allMechs[index].totalMechs > 0 && _allMechs[index].totalUpgrades > 0 )
                {
                    Debug.Log($"Unlocking MechSlotObject of {mechSlotObject.gameObject.name} due to load data at {index}");
                    //  do logic as CallUnlockSlot() now that he can do it without the monz impact
                    mechSlotObject.CallUnlockSlot();
                    mechSlotObject.PassActiveSlotUp();
                    
                    // and do the selectMechTypeButton logic for the type at index
                    var allSelectMechbuttons = GameObject.FindObjectsOfType<SelectMechTypeButton>(true);
                    var selectedMechTypeButton = allSelectMechbuttons.FirstOrDefault(info =>
                        info.MechName.Contains(_allMechs[index].mechName, StringComparison.OrdinalIgnoreCase));
                    Debug.Log($"setting button of {selectedMechTypeButton.gameObject.name} to enabled and doing CallSelectMech at {index}", gameObject);
                    if (selectedMechTypeButton != null)
                    {
                        selectedMechTypeButton.CallSelectMech();
                        // TODO:  Tell screen manager to enable the right target when I click 
                    }
                    else
                    {
                        Debug.LogWarning($"Could not find a Upgrade Button for {_allMechs[index].mechName}", gameObject);
                    }
                }
                
                // find the purchase info for this mech name size
                var allPurchaseInfos = GameObject.FindObjectsOfType<PurchaseInfo>(includeInactive: true); // note that these are disabled at load time, so I have to find them like this  
                Debug.Log($"looking for {_allMechs[index].mechName}");
                var mechPurchaseInfo  = allPurchaseInfos.FirstOrDefault(info =>
                    info.mechName.Contains(_allMechs[index].mechName, StringComparison.OrdinalIgnoreCase));  // Linq is fun!
                
                // and purchase enough of them to match the totalMechs from our save file
                double _totalMechs = _allMechs[index].totalMechs.ToDouble();
                for (double i = 0; i < _totalMechs; i++)
                {
                    Debug.Log($"{i}: CallPurchaseMech with  {mechPurchaseInfo} and first match mech name was {mechPurchaseInfo.mechName}");
                    UpgradeManager.Instance.CallPurchaseMech(mechPurchaseInfo);
                }

                // repeat for the upgrades
                var allUpgradeInfos = GameObject.FindObjectsOfType<UpgradeInfo>(includeInactive: true);
                var mechUpgradeInfo  = allUpgradeInfos.FirstOrDefault(info =>
                    info.mechName.Contains(_allMechs[index].mechName, StringComparison.OrdinalIgnoreCase));
                double totalUpgrades = _allMechs[index].totalUpgrades.ToDouble();
                for (double i = 0; i < totalUpgrades; i++)
                {
                    Debug.Log($"{i} CalUpgradeMech on {mechUpgradeInfo.mechName}");
                    UpgradeManager.Instance.CallUpgradeMech(mechUpgradeInfo);
                }
                
                if (index + 1 < _allMechs.Count)
                {
                    index++;
                    Debug.Log($"moving forward to check index: {index} with {_allMechs.Count}");
                }
                else
                {
                    // no more mechs recorded in save file, we are done here.
                    Debug.Log($"exiting loop at index: {index} with {_allMechs.Count}");
                    break;
                }
            }
            
            MonzManager.Instance.SetLoadBool(false);  // tell MonzManager that we are done loading!
        }

        public void SaveData(ref GameData data)
        {
            if (data == null) return;
            if (_allMechs == null) return;
            Debug.Log($"In SaveData of TotalMechsManager: {_allMechs.Count}");
            data.allMechsSaved = _allMechs;
        }
    }
    [Serializable]
    public class MechCollection
    {
        public string mechName;
        public BigDouble totalMechs;
        public BigDouble totalUpgrades;

        public MechCollection(string mechName, BigDouble totalMechs, BigDouble totalUpgrades)
        {
            this.mechName = mechName;
            this.totalMechs = totalMechs;
            this.totalUpgrades = totalUpgrades;
        }
    }
}
