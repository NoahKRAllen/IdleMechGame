using System;
using BreakInfinity;
using ButtonScripts;
using DataPersistence;
using TMPro;
using UnityEngine;

namespace MechMenuScripts
{
    public class MechSlotSaveObject : MonoBehaviour, IDataPersistence
    {
        public MechSlot mechSlot;
        public bool isUnlocked;
        public bool isMechSelected;
        public string mechName;

        public void RebuildButton()
        {
            Debug.LogWarning($"TODO: make RebuildButton build from save data in {mechSlot.gameObject.name}", gameObject);
        }

        private void OnEnable()
        {
            if (!mechSlot)
            {
                mechSlot = GetComponent<MechSlot>();
                isUnlocked = mechSlot.IsButtonLocked();
                isMechSelected = mechSlot.GetMechSelected();
                mechName = mechSlot.name;
            }
        }

        public void LoadData(GameData data)
        {
            // Debug.LogWarning($"Implement LoadData for {mechSlot.gameObject.name}", gameObject);
            // _monzBigDoubleHolder = data.totalMonzSaved;
            // _monzPerCycle = data.monzPerCycleSaved;
            // UpdateStartMoneyText();
        }

        public void SaveData(ref GameData data)
        {
            // Debug.LogWarning($"Implement SaveData for {mechSlot.gameObject.name}", gameObject);
            // data.mechSlot = _monzBigDoubleHolder;
            // data.monzPerCycleSaved = _monzPerCycle;
        }
    }
}
