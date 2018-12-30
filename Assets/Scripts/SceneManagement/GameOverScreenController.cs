using UnityEngine;

public class GameOverScreenController : MonoBehaviour
{
    public Fader fader;
    public string mainMenuSceneName;
    public float delayTime;

    void OnEnable()
    {
        fader.FadeOutAfterDelay(SceneLoader.GetScenePath(mainMenuSceneName), delayTime);
    }
}

