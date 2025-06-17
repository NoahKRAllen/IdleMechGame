using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class GameSaveData
{
    // Mission-specific data (resets per mission)
    public float currentCurrency;
    public Dictionary<string, int> CurrentUpgrades = new Dictionary<string, int>();
    public Dictionary<string, int> UnitCounts = new Dictionary<string, int>();
    
    // Meta progression data (persists across missions)
    public float totalMetaCurrency;
    public Dictionary<string, int> MetaUpgrades = new Dictionary<string, int>();
    public List<string> completedMissions = new List<string>();
    public string currentMission = "Tutorial_Base";
    
    // Time tracking
    public long lastSaveTime;
    public float totalPlayTime;
    
    // Player progression
    public int playerLevel;
    public int prestigeLevel;
    
    public GameSaveData()
    {
        lastSaveTime = DateTime.Now.ToBinary();
        currentCurrency = 0f;
        totalMetaCurrency = 0f;
        totalPlayTime = 0f;
        playerLevel = 1;
        prestigeLevel = 0;
    }
}

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { get; private set; }
    
    private GameSaveData _currentSave;
    private string _saveFilePath;
    private const string SAVE_FILENAME = "mercenary_save.json";
    
    [Header("Auto Save Settings")]
    public float autoSaveInterval = 30f; // Save every 30 seconds
    private float _autoSaveTimer;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeSaveSystem();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void InitializeSaveSystem()
    {
        _saveFilePath = Path.Combine(Application.persistentDataPath, SAVE_FILENAME);
        LoadGame();
    }
    
    private void Update()
    {
        // Auto-save timer
        _autoSaveTimer += Time.deltaTime;
        if (_autoSaveTimer >= autoSaveInterval)
        {
            SaveGame();
            _autoSaveTimer = 0f;
        }
    }
    
    public void SaveGame()
    {
        try
        {
            _currentSave.lastSaveTime = DateTime.Now.ToBinary();
            string jsonData = JsonUtility.ToJson(_currentSave, true);
            File.WriteAllText(_saveFilePath, jsonData);
            
            // Backup to PlayerPrefs as failsafe
            PlayerPrefs.SetString("BackupSave", jsonData);
            PlayerPrefs.Save();
            
            Debug.Log("Game saved successfully");
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to save game: {e.Message}");
        }
    }
    
    public void LoadGame()
    {
        try
        {
            if (File.Exists(_saveFilePath))
            {
                string jsonData = File.ReadAllText(_saveFilePath);
                _currentSave = JsonUtility.FromJson<GameSaveData>(jsonData);
                Debug.Log("Game loaded successfully");
            }
            else if (PlayerPrefs.HasKey("BackupSave"))
            {
                // Try backup save
                string backupData = PlayerPrefs.GetString("BackupSave");
                _currentSave = JsonUtility.FromJson<GameSaveData>(backupData);
                Debug.Log("Loaded from backup save");
            }
            else
            {
                // Create new save
                _currentSave = new GameSaveData();
                Debug.Log("Created new save file");
            }
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to load game: {e.Message}");
            _currentSave = new GameSaveData();
        }
    }
    
    // Mission Management
    public void StartNewMission(string missionName)
    {
        // Save current mission progress to meta-currency
        ConvertCurrencyToMeta();
        
        // Reset mission-specific data
        _currentSave.currentCurrency = 0f;
        _currentSave.CurrentUpgrades.Clear();
        _currentSave.UnitCounts.Clear();
        _currentSave.currentMission = missionName;
        
        SaveGame();
    }
    
    public void CompleteMission(string missionName)
    {
        if (!_currentSave.completedMissions.Contains(missionName))
        {
            _currentSave.completedMissions.Add(missionName);
        }
        ConvertCurrencyToMeta();
        SaveGame();
    }
    
    private void ConvertCurrencyToMeta()
    {
        // Convert current currency to meta-currency with some conversion rate
        float conversionRate = 0.1f; // Adjust based on your game balance
        _currentSave.totalMetaCurrency += _currentSave.currentCurrency * conversionRate;
    }
    
    // Upgrade Management
    public void AddUpgrade(string upgradeId, int amount = 1)
    {
        if (_currentSave.CurrentUpgrades.ContainsKey(upgradeId))
        {
            _currentSave.CurrentUpgrades[upgradeId] += amount;
        }
        else
        {
            _currentSave.CurrentUpgrades[upgradeId] = amount;
        }
    }
    
    public void AddMetaUpgrade(string upgradeId, int amount = 1)
    {
        if (_currentSave.MetaUpgrades.ContainsKey(upgradeId))
        {
            _currentSave.MetaUpgrades[upgradeId] += amount;
        }
        else
        {
            _currentSave.MetaUpgrades[upgradeId] = amount;
        }
    }
    
    public int GetUpgradeLevel(string upgradeId)
    {
        return _currentSave.CurrentUpgrades.ContainsKey(upgradeId) ? _currentSave.CurrentUpgrades[upgradeId] : 0;
    }
    
    public int GetMetaUpgradeLevel(string upgradeId)
    {
        return _currentSave.MetaUpgrades.ContainsKey(upgradeId) ? _currentSave.MetaUpgrades[upgradeId] : 0;
    }
    
    // Unit Management
    public void AddUnit(string unitType, int amount)
    {
        if (_currentSave.UnitCounts.ContainsKey(unitType))
        {
            _currentSave.UnitCounts[unitType] += amount;
        }
        else
        {
            _currentSave.UnitCounts[unitType] = amount;
        }
    }
    
    public int GetUnitCount(string unitType)
    {
        return _currentSave.UnitCounts. ContainsKey(unitType) ? _currentSave.UnitCounts[unitType] : 0;
    }
    
    // Currency Management
    public void AddCurrency(float amount)
    {
        _currentSave.currentCurrency += amount;
    }
    
    public bool SpendCurrency(float amount)
    {
        if (_currentSave.currentCurrency >= amount)
        {
            _currentSave.currentCurrency -= amount;
            return true;
        }
        return false;
    }
    
    public void AddMetaCurrency(float amount)
    {
        _currentSave.totalMetaCurrency += amount;
    }
    
    public bool SpendMetaCurrency(float amount)
    {
        if (_currentSave.totalMetaCurrency >= amount)
        {
            _currentSave.totalMetaCurrency -= amount;
            return true;
        }
        return false;
    }
    
    // Getters for other systems
    public GameSaveData GetSaveData() => _currentSave;
    public float GetCurrentCurrency() => _currentSave.currentCurrency;
    public float GetMetaCurrency() => _currentSave.totalMetaCurrency;
    public string GetCurrentMission() => _currentSave.currentMission;
    public DateTime GetLastSaveTime() => DateTime.FromBinary(_currentSave.lastSaveTime);
    
    // Mobile-specific save triggers
    private void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus)
        {
            SaveGame();
        }
    }
    
    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            SaveGame();
        }
    }
    
    private void OnApplicationQuit()
    {
        SaveGame();
    }
}