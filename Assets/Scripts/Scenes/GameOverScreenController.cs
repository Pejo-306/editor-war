using UnityEngine;

public class GameOverScreenController : MonoBehaviour
{
    public string mainMenuName;
    public float delayTime;

    void Start()
    {
        string scene = SceneLoader.scenesPath + mainMenuName;

        Fader.Instance.FadeOutAfterDelay(scene, delayTime);
    }
}

