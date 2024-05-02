using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MothershipName", menuName = "IdleMech/Mothership")]
public class MothershipSO : ScriptableObject
{
    public string mothershipName;
    public int factoryMechSlots;
    public GameObject factoryMechPrefab;
}
