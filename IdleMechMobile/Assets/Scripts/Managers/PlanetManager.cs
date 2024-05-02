using System.Collections;
using System.Collections.Generic;
using DataPersistence;
using Managers;
using UnityEngine;
using UnityEngine.Events;

public class PlanetManager : Singleton<PlanetManager>, IDataPersistence, IDataManager
{
    [SerializeField] PlanetSO planet;

    [SerializeField] private GameObject planetParent;
    // Start is called before the first frame update
    void Start()
    {
        // TODO: load the prefab from the SO and place it under planetParent
        // TODO: load the timer moidifier and update 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadData(GameData data)
    {
        // TODO: if there is any data changeable about a planet, load it here.
    }

    public void SaveData(ref GameData data)
    {
        // throw new System.NotImplementedException();
    }

    public void SubscribeToDataChanged(UnityAction listener)
    {
        // throw new System.NotImplementedException();
    }
}
