using UnityEngine;

public class PersistantGameManager : MonoBehaviour 
{
    public static PersistantGameManager Instance { get; private set; }

    private void Awake()
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

