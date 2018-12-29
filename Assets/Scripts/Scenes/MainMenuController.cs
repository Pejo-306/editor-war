using UnityEngine;

public class MainMenuController : MonoBehaviour 
{
    private static string scenePath = "Scenes/";

    public void StartGame(string firstLevelSceneName)
    {
        string scene = scenePath + firstLevelSceneName;

        Fader.Instance.FadeOutOfLevel(scene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

