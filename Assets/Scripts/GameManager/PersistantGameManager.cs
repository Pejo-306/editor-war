using UnityEngine;

public class PersistantGameManager : MonoBehaviour 
{
    public static PersistantGameManager Instance { get; private set; }

    public int continues = 3;
    public string continueSceneName = "Continue";
    public string gameOverSceneName = "GameOver";
    private int leftoverContinues;

    void Awake()
    {
        // singleton pattern
        if (Instance == null)
        {
            Instance = this;
            Initialize();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GameOver()
    {
        string nextSceneName = (leftoverContinues > 0) ? continueSceneName : gameOverSceneName;
        var levelSceneController = (LevelSceneController)FindObjectOfType(
                typeof(LevelSceneController));

        levelSceneController.ChangeScene(nextSceneName);
    }

    public void Reset()
    {
        leftoverContinues = continues;
    }

    public int GetLeftoverContinues()
    {
        return leftoverContinues;
    }

    public void UseContinue()
    {
        leftoverContinues--;
    }

    private void Initialize()
    {
        leftoverContinues = continues;
    }
}

