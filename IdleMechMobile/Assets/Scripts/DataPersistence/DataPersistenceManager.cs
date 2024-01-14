using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;

namespace DataPersistence
{
    public class DataPersistenceManager : MonoBehaviour
    {
        [Header("File Storage Config")] 
        [SerializeField] private string fileName;
        
        
        
        private GameData _gameData;
        private List<IDataPersistence> _dataPersistenceObjects;
        private FileDataHandler _dataHandler;
        public static DataPersistenceManager Instance { get; private set; }
        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("Attempting to create more than one Data Persistence Manager in the Scene");
            }

            Instance = this;
        }

        private void Start()
        {
            _dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
            _dataPersistenceObjects = FindAllDataPersistenceObjects();
            LoadGame();
        }
        

        public void NewGame()
        {
            _gameData = new GameData();
        }

        public void LoadGame()
        {
            // TODO: Load any saved data from a file using the data handler
            _gameData = _dataHandler.Load();
            
            if (_gameData == null)
            {
                Debug.Log("No saved data found. Initializing data to defaults");
                NewGame();
            }

            foreach (var dataPersistenceObj in _dataPersistenceObjects)
            {
                dataPersistenceObj.LoadData(_gameData);
            }

            //TODO: remove this, load game will not be selectable if there is no game data found
            // TODO: Push the loaded data to all other scripts that need it
        }

        public void SaveGame()
        {
            //TODO: Pass gameData to the other scripts so that they can update it
            foreach (var dataPersistenceObj in _dataPersistenceObjects)
            {
                dataPersistenceObj.SaveData(ref _gameData);
            }

            //TODO: save that data to a file using the data handler
            _dataHandler.Save(_gameData);
        }

        private void OnApplicationQuit()
        {
            SaveGame();
        }

        private List<IDataPersistence> FindAllDataPersistenceObjects()
        {
            var dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>()
                .OfType<IDataPersistence>();

            return new List<IDataPersistence>(dataPersistenceObjects);
        }
    }
}
