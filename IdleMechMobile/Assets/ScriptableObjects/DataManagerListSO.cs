using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataManagerList", menuName = "IdleMech/DataManagerList")]
public class DataManagerList : ScriptableObject
{
    public List<GameObject> dataManagers = new List<GameObject>();

    private void OnValidate()
    {
        // TODO: validate that all of the data managers have a IDataManager interface implemented, warning at editor if not
    }
    
}
