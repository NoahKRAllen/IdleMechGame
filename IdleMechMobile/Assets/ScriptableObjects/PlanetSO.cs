using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlanetName", menuName = "IdleMech/Planet")]
[Serializable]
public class PlanetSO : ScriptableObject
{
    public string planetName;
    [TextArea(minLines: 2, maxLines: 4)] public string planetDescription;
    public float planetDifficulty;
    public float timerModifier;
    public GameObject planetPrefab;
}
