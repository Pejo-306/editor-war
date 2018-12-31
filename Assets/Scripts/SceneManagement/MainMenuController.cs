using UnityEngine;

public class MainMenuController : MonoBehaviour 
{
    public Fader fader;
    public string firstLevelSceneName;

    public void StartGame()
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

