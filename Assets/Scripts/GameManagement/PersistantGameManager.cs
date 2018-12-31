using UnityEngine;

public class PersistantGameManager : MonoBehaviour 
{
    public static PersistantGameManager Instance { get; private set; }

    public int continues = 3;
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
        var levelSceneController = (LevelSceneController)FindObjectOfType(
                typeof(LevelSceneController));
        var nextSceneController = levelSceneController.GetComponent<NextSceneController>();
        string nextSceneName = (leftoverContinues > 0) ? SceneManagementConstants.continueSceneName 
            : SceneManagementConstants.gameOverSceneName;

        nextSceneController.SetParameter("Next Scene", nextSceneName);
        levelSceneController.ChangeScene(SceneManagementConstants.playerDeathSceneName);
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

