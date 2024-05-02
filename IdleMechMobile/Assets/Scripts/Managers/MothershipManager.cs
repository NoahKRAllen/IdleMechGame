using System;
using System.Collections.Generic;
using BreakInfinity;
using DataPersistence;
using Managers;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

namespace MechMenuScripts
{
    // [ExecuteAlways] // makes the buttons execute in editor and play mode
    [ExecuteInEditMode]  // only show buttons in edit mode
    public class MothershipManager : Singleton<MothershipManager>, IDataPersistence
    {
        [SerializeField] private ScriptableObject _mothershipSO;
        
        [SerializeField] public List<MechSlot> mechSlots; // FIXME: Remove the direct awareness of the slots, let the FactorySlotView deal with that.
        private List<GameObject> _factorySlots = new List<GameObject>(); // TODO: create the list of factory slots based on mothership slot size

        private MechSlot _activelyUpdatingMechSlot;
        private string _tempNameHolder;
        private GameObject _overlayScreenHolder;
        public bool mechSelected;  // FIXME: I think this should be per MechSlot, not at the parent level
        
        public UnityEvent OnMothershipChange;  // tell all the subscribers that the mothership has changed and that they should update their models

        public void OnMechFactoryPurchased(GameObject go)
        {
            Debug.Log("MoM: OnMechFactoryPurchased: " + go.name);
            // TODO: Update the mech slots 
        }
        
        private void Awake()
        {
            // TODO: read all the Mothership data from the SO
            // TODO: load the mothership prefab and render it on screen
        }

        public void ClearSelectedMechSlot()
        {
            Debug.Log($"MoM: Clearing selected mech slot data", gameObject);
            _activelyUpdatingMechSlot = null;
            _tempNameHolder = null;
            _overlayScreenHolder = null;
            mechSelected = false;
            OnMothershipChange.Invoke();
        }
        public bool UnlockSlot(BigDouble priceToUnlock)
        {
            return MonzManager.Instance.TrySpend(priceToUnlock); // FIXME: shouldn't be doing unlock 
        }

        public void UpdateMechSlotText(TextMeshProUGUI textToUpdate, string newText)
        {
            TextManager.UpdateAnyBasicText(textToUpdate, newText);
        }

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

        private void LoadData()
        {
            GameData data = new GameData();
            LoadData(data);
        }
        public void LoadData(GameData data)
        {
            Debug.Log($"MoM: Doing LoadData for {gameObject.name}", gameObject);
            OnMothershipChange.Invoke();
            // throw new System.NotImplementedException();
        }

        public void SaveData(ref GameData data)
        {
            Debug.LogWarning($"MoM: SaveData for {gameObject.name}", gameObject);
            // throw new System.NotImplementedException();
        }
    }
}
