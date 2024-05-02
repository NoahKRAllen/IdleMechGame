using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Game Event", menuName = "IdleMech/New Event")]
public class Event : ScriptableObject
{
    private List<EventListener> listeners = new List<EventListener>();

    public void Register(EventListener listener)
    {
        // Debug.Log($"Event: Registering {listener}");
        listeners.Add(listener);
    }

    public void Unregister(EventListener listener)
    {
        // Debug.Log($"Event: Unregister {listener}");
        listeners.Remove(listener);
    }

    public void Occurred(GameObject go)
    {
        // Debug.Log($"Event: Occurred on {go.name}, calling his listeners", go);
        for (int i = 0; i < listeners.Count; i++)
        {
            // Debug.Log($"listener: {listeners[i].name} called");
            listeners[i].OnEventOccurs(go);
        }
    }
}
