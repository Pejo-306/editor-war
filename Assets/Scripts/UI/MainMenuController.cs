using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour 
{
    private static string scenePath = "Scenes/";

    public Fader fader;
    public List<SceneLoader.SceneParameter> nextSceneParameters;

    public void StartGame(string firstLevelSceneName)
    {
        string scene = scenePath + firstLevelSceneName;

        fader.setNextSceneParameters(nextSceneParameters);
        fader.FadeOutOfLevel(scene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

