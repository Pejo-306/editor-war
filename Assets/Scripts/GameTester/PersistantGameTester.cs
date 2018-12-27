using UnityEngine;

public class PersistantGameTester : MonoBehaviour
{
    public static PersistantGameTester Instance { get; private set; }

    void Awake()
    {
        // singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

