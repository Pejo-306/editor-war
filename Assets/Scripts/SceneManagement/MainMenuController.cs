using UnityEngine;

public class MainMenuController : MonoBehaviour 
{
    public Fader fader;

    public void StartGame(string firstLevelSceneName)
    {
        PersistantGameManager.Instance.Reset();
        GetComponent<NextSceneController>().SetNextSceneParameters();
        fader.FadeOutOfLevel(SceneLoader.GetScenePath(firstLevelSceneName));
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

