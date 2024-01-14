using System;
using System.Collections.Generic;
using BreakInfinity;
using DataPersistence;
using Managers;
using TMPro;
using UnityEngine;

namespace MechMenuScripts
{
    public class MechSlotsParent : MonoBehaviour, IDataPersistence
    {
        
        //TODO: Need to get someway to link the mechSlots to their selected mech, probably through the totalmechsmanager or something so it can be saved in the save system
        [SerializeField] private List<MechSlotSaveObject> mechSlots;
        
        [SerializeField] private MonzManager monzManager;

        [SerializeField] private MechSelectionScreenManager mechSelectionScreenManager;

        public bool UnlockSlot(BigDouble priceToUnlock)
        {
            return monzManager.TrySpend(priceToUnlock);
        }

        public void UpdateMechSlotText(TextMeshProUGUI textToUpdate, string newText)
        {
            TextManager.UpdateAnyBasicText(textToUpdate, newText);
        }

        private MechSlot _activelyUpdatingMechSlot;
        private string _tempNameHolder;
        private GameObject _overlayScreenHolder;
        public bool mechSelected;
        public void AffectMechSlot(string mechName, GameObject overlayScreen)
        {
            _tempNameHolder = mechName;
            _overlayScreenHolder = overlayScreen;
            mechSelected = true;
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

        public void LoadData(GameData data)
        {
            mechSlots = data.mechSlotsSaved;
            if (mechSlots == null || mechSlots.Count == 0)
            {
                Debug.Log("Refilling emptied mechslotparent list:");
                var foundMechSlots = FindObjectsOfType<MechSlotSaveObject>();
                mechSlots = new List<MechSlotSaveObject>();
                foreach (var e in foundMechSlots)
                {
                    mechSlots.Add(e);
                    mechSlots.Reverse();
                }
            }
            else
            {
                //TODO: Rebuild the buttons to be the way they need to be based on the info in the mechslotsaveobject
                foreach (var slot in mechSlots)
                {
                    slot.RebuildButton();
                }
            }

        }

        public void SaveData(ref GameData data)
        {
            data.mechSlotsSaved = mechSlots;
        }
    }
}
