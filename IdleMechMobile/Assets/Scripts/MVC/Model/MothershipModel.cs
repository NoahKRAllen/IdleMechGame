using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

// data and business logic for factory slots, mothership upgrades, planet location
// persistence for Mothership factory slots
public class MothershipModel : MonoBehaviour
{
    public UnityEvent OnModelChanged;
    private PlanetModel currentPlanet;
    private FactorySlotModel[] factorySlots;
    // TODO: private MothershipUpgradeModel[] upgrades;
    
}
