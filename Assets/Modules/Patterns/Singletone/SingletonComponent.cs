using UnityEngine;

public class SingletonComponent<T> : MonoBehaviour where T : Object
{
    private static T instance;
    private bool isInitialized;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
            }

            if (instance == null)
            {
                Debug.LogWarningFormat("[SingletonComponent] Returning null instance for component of type {0}.",
                    typeof(T));
            }

            return instance;
        }
    }

    protected virtual void Awake()
    {
        SetInstance();
    }

    public static bool Exists()
    {
        return instance != null;
    }

    public bool SetInstance()
    {
        if (instance != null && instance != gameObject.GetComponent<T>())
        {
            Debug.LogWarning("[SingletonComponent] Instance already set for type " + typeof(T));
            return false;
        }

        instance = gameObject.GetComponent<T>();

        return true;
    }
}