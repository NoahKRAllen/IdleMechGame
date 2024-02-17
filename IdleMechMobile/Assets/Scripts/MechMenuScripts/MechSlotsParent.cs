using System.Collections.Generic;
using BreakInfinity;
using DataPersistence;
using Managers;
using TMPro;
using UnityEngine;

namespace MechMenuScripts
{
    public class MechSlotsParent : MonoBehaviour
    {
        
        //TODO: Need to get someway to link the mechSlots to their selected mech, probably through the TotalMechManager or something so it can be saved in the save system
        [SerializeField] public List<MechSlot> mechSlots;
        private MechSlot _activelyUpdatingMechSlot;
        private string _tempNameHolder;
        private GameObject _overlayScreenHolder;
        public bool mechSelected;  //FIXME: I think this should be per MechSlot, not at the parent level
        
        private void Awake()
        {
            // TODO: subscribe to data change events in TotalMechsManager
        }

        
        public bool UnlockSlot(BigDouble priceToUnlock)
        {
            return MonzManager.Instance.TrySpend(priceToUnlock);
        }

        public void UpdateMechSlotText(TextMeshProUGUI textToUpdate, string newText)
        {
            TextManager.UpdateAnyBasicText(textToUpdate, newText);
        }

        public void AffectMechSlot(string mechName, GameObject overlayScreen)
        {
            _tempNameHolder = mechName;
            _overlayScreenHolder = overlayScreen;
            mechSelected = true;  //FIXME:  How do I know which child mech slot has been impacted?  
        }

        public string MechSlotRequestInfo(out GameObject overlayScreen)
        {
            overlayScreen = _overlayScreenHolder;
            return _tempNameHolder; 
        }
        
        public void SetActiveMechSlot(MechSlot newMechSlot)
        {
            _activelyUpdatingMechSlot = newMechSlot;
        }

        public MechSlot CheckActiveMechSlot()
        {
            return _activelyUpdatingMechSlot;
        }

        // public void LoadData(GameData data)
        // {
        //     Debug.Log($"Doing LoadData for {gameObject.name}", gameObject);
        //     mechSlots = data.mechSlotsSaved;
        //     if (mechSlots == null || mechSlots.Count == 0 || (mechSlots[0] == null && mechSlots[1] == null && mechSlots[2] == null))
        //     {
        //         Debug.Log("Refilling emptied MechSlowParent list:", gameObject);
        //         var foundMechSlots = FindObjectsOfType<MechSlotSaveObject>();
        //         mechSlots = new List<MechSlotSaveObject>();
        //         foreach (var e in foundMechSlots)
        //         {
        //             mechSlots.Add(e);
        //             mechSlots.Reverse();
        //         }
        //     }
        //     else
        //     {
        //         //TODO: Rebuild the buttons to be the way they need to be based on the info in the MechSlotSaveObjects
        //         foreach (var slot in mechSlots)
        //         {
        //             slot.RebuildButton();
        //         }
        //     }
        //
        // }
        //
        // public void SaveData(ref GameData data)
        // {
        //     data.mechSlotsSaved = mechSlots;
        // }
    }
}
