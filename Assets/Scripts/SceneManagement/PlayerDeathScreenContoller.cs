using UnityEngine;

public class PlayerDeathScreenContoller : MonoBehaviour
{
    public Fader fader;
    public float delayTime = 4f;

    void OnEnable()
    {
        var nextSceneController = GetComponent<NextSceneController>();
        string nextSceneName = SceneLoader.Instance.GetParameter(
                PersistantGameManager.nextSceneParameterKey);

        nextSceneController.SetParameter("Level Index", 
                SceneLoader.Instance.GetParameter("Level Index"));
        fader.FadeOutAfterDelay(SceneLoader.GetScenePath(nextSceneName), delayTime);
    }
}

