using UnityEngine;

public class MainMenuController : MonoBehaviour 
{
    public void StartGame(string firstLevelSceneName)
    {
        string scene = SceneLoader.scenesPath + firstLevelSceneName;

        Fader.Instance.FadeOutOfLevel(scene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

