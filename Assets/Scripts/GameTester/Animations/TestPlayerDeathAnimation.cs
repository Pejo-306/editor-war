using UnityEngine;

public class TestPlayerDeathAnimation : MonoBehaviour
{
    public string nextSceneName;
    public int levelIndex;
    public Vector2 playerPosition;

    void OnEnable()
    {
        string positionString = string.Format("{0:n3},{1:n3}", playerPosition.x, playerPosition.y);

        SetSceneParameter("Next Scene", nextSceneName);
        SetSceneParameter("Level Index", levelIndex.ToString());
        SetSceneParameter("Player Position", positionString);
    }

    private void SetSceneParameter(string paramKey, string paramValue)
    {
        var sceneLoader = (SceneLoader)FindObjectOfType(typeof(SceneLoader));
        string message = string.Format(
                "TestPlayerDeathAnimation: Setting parameter '{0}' to '{1}'",
                paramKey, paramValue);

        Debug.Log(message);
        sceneLoader.SetParameter(paramKey, paramValue);
    }
}

