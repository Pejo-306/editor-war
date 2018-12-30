using UnityEngine;

public class GameWinScreenController : MonoBehaviour
{
    public string mainMenuSceneName;
    public float delayTime;

    void OnEnable()
    {
        Fader.Instance.FadeOutAfterDelay(SceneLoader.GetScenePath(mainMenuSceneName), delayTime);
    }
}

