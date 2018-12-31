using UnityEngine;

public class PersistantGameManager : MonoBehaviour 
{
    public static PersistantGameManager Instance { get; private set; }
    public const string nextSceneParameterKey = "Next Scene";

    public int continues = 3;
    public string playerDeathSceneName = "PlayerDeath";
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
        var nextSceneController = levelSceneController.GetComponent<NextSceneController>();

        nextSceneController.SetParameter(nextSceneParameterKey, nextSceneName);
        levelSceneController.ChangeScene(playerDeathSceneName);
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

