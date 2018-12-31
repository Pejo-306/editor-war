using UnityEngine;

public class PersistantStaticMembers : MonoBehaviour
{
    public static PersistantStaticMembers Instance { get; private set; }

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

