using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FactorySlotModel : MonoBehaviour
{
    public UnityEvent OnModelChanged;
    public string FactorySlotName { get; private set; }
    public FactorySlotTypes FactorySlotType { get; private set; }
    
    public enum FactorySlotTypes
    {
        None,
        LightMechFactory,
        MediumMechFactory,
        HeavyMechFactory,
        HeavyWeaponFactory,
        HeavyArmorFactory,
        LightWeaponFactory,
        LightArmorFactory
    };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual void OnOnModelChanged()
    {
        OnModelChanged?.Invoke();
    }
}
