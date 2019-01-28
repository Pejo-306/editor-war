using UnityEngine;

public class PersistantGameManager : MonoBehaviour 
{
    [System.Serializable]
    public struct GameOverOptions
    {
        public string playerTag;

        public string playerControlsGroupName;

        public string levelUITag;

        public string backgroundTag;

        public Sprite backgroundSprite;

        public float delayBeforeDeath;

        public float delayAfterDeath;
    }

    public static PersistantGameManager Instance { get; private set; }

    public int continues = 3;

    public GameOverOptions gameOverOptions;

    private int leftoverContinues;

    private bool triggeredGameOver = false;

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

    public void GameWin()
    {
        var levelSceneController = (LevelSceneController)FindObjectOfType(
                typeof(LevelSceneController));

        levelSceneController.ChangeScene(ProjectPaths.gameWinSceneRPath);
    }

    public void GameOver()
    {
        float delayBeforeSceneSwitch;

        if (!triggeredGameOver)
        { 
            delayBeforeSceneSwitch = gameOverOptions.delayBeforeDeath + gameOverOptions.delayAfterDeath;
            SetupPlayerDeathScene();
            Invoke("SwitchToNextSceneAfterPlayerDeath", delayBeforeSceneSwitch);
            triggeredGameOver = true;
        }
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

    private void SetupPlayerDeathScene()
    {
        var background = GameObject.FindWithTag(gameOverOptions.backgroundTag);
        var player = GameObject.FindWithTag(gameOverOptions.playerTag);
        var levelUI = GameObject.FindGameObjectsWithTag(gameOverOptions.levelUITag);

        // Play the player's death animation.
        player.GetComponent<PlayerHealth>().PlayDeathAnimation(gameOverOptions.delayBeforeDeath);
        player.GetComponent<ComponentController>()
            .DisableComponents(gameOverOptions.playerControlsGroupName);

        // Disable UI elements of the level.
        foreach (var UIElement in levelUI)
        {
            UIElement.SetActive(false);
        }

        background.GetComponent<SpriteRenderer>().sprite = gameOverOptions.backgroundSprite;
    }

    private void SwitchToNextSceneAfterPlayerDeath()
    {
        var levelSceneController = (LevelSceneController)FindObjectOfType(
                typeof(LevelSceneController));
        string nextSceneName = (leftoverContinues > 0) ? ProjectPaths.continueSceneRPath
                                                       : ProjectPaths.gameOverSceneRPath;

        triggeredGameOver = false;
        levelSceneController.ChangeScene(nextSceneName);
    }
}

