using UnityEngine;

public class MainMenuController : MonoBehaviour 
{
    private static string scenePath = "Scenes/";

    public Fader fader;

    public void StartGame(string firstLevelSceneName)
    {
        string scene = scenePath + firstLevelSceneName;

        fader.FadeOutOfLevel(scene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

