using UnityEngine;

public class GameWinScreenController : MonoBehaviour
{
    public Fader fader;
    public float delayTime;

    void OnEnable()
    {
        fader.FadeOutAfterDelay(ProjectPaths.mainMenuSceneRPath, delayTime);
    }
}

