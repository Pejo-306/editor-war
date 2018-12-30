using UnityEngine;

public class MainMenuController : MonoBehaviour 
{
    public void StartGame(string firstLevelSceneName)
    {
        Fader.Instance.FadeOutOfLevel(SceneLoader.GetScenePath(firstLevelSceneName));
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

