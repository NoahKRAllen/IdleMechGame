using System.Collections.Generic;
using BreakInfinity;
using Managers;
using MechMenuScripts;
using UnityEngine;

namespace DataPersistence
{
    [System.Serializable]
    public class GameData
    {
        public BigDouble totalMonzSaved;
        public BigDouble monzPerCycleSaved;
        // public List<MechSlotSaveObject> mechSlotsSaved;
        public List<MechCollection> allMechsSaved;
        public GameData()
        {
            Debug.Log($"Initializing Game Data");
            totalMonzSaved = 0;
            monzPerCycleSaved = 0;
        }
    }
}
