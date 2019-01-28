using UnityEngine;
using System.IO;

public class MainMenuController : MonoBehaviour 
{
    public Fader fader;

    public string intermissionScenePath;

    public void StartGame()
    {
        PersistantGameManager.Instance.Reset();
        GetComponent<NextSceneController>().SetNextSceneParameters();
        fader.FadeOutOfLevel(intermissionScenePath);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

