using UnityEngine;

public class MainMenuController : MonoBehaviour 
{
    public void StartGame(string firstLevelSceneName)
    {
        GetComponent<NextSceneController>().SetNextSceneParameters();
        Fader.Instance.FadeOutOfLevel(SceneLoader.GetScenePath(firstLevelSceneName));
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

