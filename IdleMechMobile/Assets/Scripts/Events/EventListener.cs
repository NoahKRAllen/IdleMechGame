using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

[System.Serializable]
public class UnityGameObjectEvent : UnityEvent<GameObject> { }

public class EventListener : MonoBehaviour
{
    public Event gameObjectEvent;
    public UnityGameObjectEvent response = new UnityGameObjectEvent();

    private void OnEnable()
    {
        gameObjectEvent.Register(this);
    }

    private void OnDisable()
    {
        gameObjectEvent.Unregister(this);
    }

    public void OnEventOccurs(GameObject go)
    {
        response.Invoke(go);
    }
}
