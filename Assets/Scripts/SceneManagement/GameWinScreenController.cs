using UnityEngine;

public class GameWinScreenController : MonoBehaviour
{
    public Fader fader;
    public float delayTime;

    void OnEnable()
    {
        string nextScene = SceneLoader.GetScenePath(SceneManagementConstants.mainMenuSceneName);

        fader.FadeOutAfterDelay(nextScene, delayTime);
    }
}

