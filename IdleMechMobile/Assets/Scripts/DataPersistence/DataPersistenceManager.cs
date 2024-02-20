using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;
using UnityEngine.SceneManagement;

namespace DataPersistence
{
    public class DataPersistenceManager : Singleton<DataPersistenceManager>
    {
        [Header("File Storage Config")] 
        [SerializeField] private string fileName;
        
        private GameData _gameData;
        private List<IDataPersistence> _dataPersistenceObjects;
        private FileDataHandler _dataHandler;

        // private static UnityEngine.Events.UnityAction<Scene, LoadSceneMode> LoadAfterSceneLoad;

        private void Start()
        {
            Debug.Log($"DPM: In DataPersistenceManager Start");
            _dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
            _dataPersistenceObjects = FindAllDataPersistenceObjects();
            LoadGame();
        }
        

        public void NewGame()
        {
            _gameData = new GameData();
            // TODO: some reasonable defaults here, perhaps pulled from a scriptable object?
        }

        public void LoadGame()
        {
            // TODO: Load any saved data from a file using the data handler
            _gameData = _dataHandler.Load();
            
            if (_gameData == null)
            {
                Debug.Log("DPM: No saved data found. Initializing data to defaults");
                NewGame();
            }
            // using this delegate to wait until we know the scene is done loading
            // LoadAfterSceneLoad = (scene, LoadSceneMode) =>
            // {
            //     Debug.Log($"Scene {scene.name} loaded. Loading data...");
            //     foreach (var dataPersistenceObj in _dataPersistenceObjects)
            //     {
            //         dataPersistenceObj.LoadData(_gameData);
            //     }
            //
            //     // clear the scene loader
            //     SceneManager.sceneLoaded -= LoadAfterSceneLoad;
            //     LoadAfterSceneLoad = null;
            // };
            foreach (var dataPersistenceObj in _dataPersistenceObjects)
            {
                Debug.Log($"DPM: loading data for {dataPersistenceObj.GetType().Name} ", gameObject);
                dataPersistenceObj.LoadData(_gameData);
            }
            
            // add the LoadAFterSceneLoad listener to get fired after all Start, Awakes, etc of scene events
            // SceneManager.sceneLoaded += LoadAfterSceneLoad;
            
        }

        public void SaveGame()
        {
            //Pass gameData to the other scripts so that they can update it
            foreach (var dataPersistenceObj in _dataPersistenceObjects)
            {
                dataPersistenceObj.SaveData(ref _gameData);
            }

            //save that data to a file using the data handler
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
