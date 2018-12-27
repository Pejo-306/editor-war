using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour 
{
    public Fader fader;
    private static string scenePath = "Scenes/";

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

