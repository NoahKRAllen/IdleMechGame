using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log($"S: Someone tried to get and _instance is null, searching or creating  {typeof(T)}");
                _instance = FindOrCreateInstance();
            }
            return _instance;
        }
    }

    private static T FindOrCreateInstance()
    {
        var Instance = GameObject.FindObjectOfType<T>();
        if (Instance != null)
        {
            Debug.Log($"S: Found and returning instance of {typeof(T)} on gameObject {Instance.gameObject.name}");
            return Instance;
        }
        
        var name = typeof(T).Name + " Singleton";
        var containerGameObject = new GameObject(name);
        var singletonComponent = containerGameObject.AddComponent<T>();
        return singletonComponent;
    }
}