using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSceneController : MonoBehaviour
{
    public Fader fader;

    public void ChangeScene(string nextScenePath, bool fadeOut = true)
    {
        var nextSceneController = GetComponent<NextSceneController>();

        nextSceneController.SetParameter("Level Index", 
                SceneManager.GetActiveScene().buildIndex.ToString());
        nextSceneController.SetNextSceneParameters();
        fader.fadeOut = fadeOut;
        fader.FadeOutOfLevel(nextScenePath);
    }
}

