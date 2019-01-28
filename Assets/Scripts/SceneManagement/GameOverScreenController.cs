using UnityEngine;

public class GameOverScreenController : MonoBehaviour
{
    public Fader fader;
    public float delayTime;

    void OnEnable()
    {
        fader.FadeOutAfterDelay(ProjectPaths.mainMenuSceneRPath, delayTime);
    }
}

