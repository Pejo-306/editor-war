using UnityEngine;

public class PersistantGameManager : MonoBehaviour 
{
    public static PersistantGameManager Instance { get; private set; }

    public int continues = 3;
    public string continueSceneName = "Continue";
    public string gameOverSceneName = "GameOver";

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

    public void GameOver()
    {
        string nextSceneName = (continues > 0) ? continueSceneName : gameOverSceneName;
        var levelSceneController = (LevelSceneController)FindObjectOfType(
                typeof(LevelSceneController));

        levelSceneController.ChangeScene(nextSceneName);
    }

    public void UseContinue()
    {
        continues--;
    }
}

