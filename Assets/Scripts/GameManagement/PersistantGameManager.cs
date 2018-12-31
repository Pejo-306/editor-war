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
        var player = GameObject.FindWithTag("Player");
        var levelSceneController = (LevelSceneController)FindObjectOfType(
                typeof(LevelSceneController));
        var nextSceneController = levelSceneController.GetComponent<NextSceneController>();
        string playerPosition = string.Format("{0:n3},{1:n3}", 
                player.transform.position.x, player.transform.position.y);
        string nextSceneName;

        if (leftoverContinues > 0)
        {
            nextSceneName = SceneManagementConstants.continueSceneName;
        }
        else
        {
            nextSceneName = SceneManagementConstants.gameOverSceneName;
        }
        nextSceneController.SetParameter("Next Scene", nextSceneName);
        nextSceneController.SetParameter("Player Position", playerPosition);
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

