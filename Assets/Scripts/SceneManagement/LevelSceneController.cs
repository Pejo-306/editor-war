using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSceneController : MonoBehaviour
{
    public Fader fader;
    public string levelIndexParameterKey = "Level Index";

    public void ChangeScene(string nextSceneName)
    {
        var nextSceneController = GetComponent<NextSceneController>();
        string nextScene = SceneLoader.GetScenePath(nextSceneName);

        nextSceneController.SetParameter(levelIndexParameterKey, 
                SceneManager.GetActiveScene().buildIndex.ToString());
        nextSceneController.SetNextSceneParameters();
        fader.FadeOutOfLevel(nextScene);
    }
}

