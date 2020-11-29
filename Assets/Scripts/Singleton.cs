using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance 
    { 
        get 
        {
            Init();
            return instance;
        } 
    }
    protected bool IsQuitting = false;

    protected static void Init()
    {
        Debug.Log("Singleton initializing...");

        if (instance == null || instance.Equals(null))
        {
            var gameObject = new GameObject();
            gameObject.hideFlags = HideFlags.HideAndDontSave;
            instance = gameObject.AddComponent<T>();
        }
    }

    private void OnApplicationQuit()
    {
        IsQuitting = true;
    }

    private void OnDestroy()
    {
        if (!IsQuitting)
        {
            instance = null;
            Init();
        }
    }
}