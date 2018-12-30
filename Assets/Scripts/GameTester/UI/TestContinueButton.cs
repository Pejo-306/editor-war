using UnityEngine;

public class TestContinueButton : MonoBehaviour
{
    public int nextLevelIndex;

    void OnEnable()
    {
        SetSceneParameter("Level Index", nextLevelIndex.ToString()); 
    }

    private void SetSceneParameter(string paramKey, string paramValue)
    {
        SceneLoader sceneLoader = (SceneLoader)FindObjectOfType(typeof(SceneLoader));
        string message = string.Format(
                "TestContinueButton: Setting parameter '{0}' to '{1}'",
                paramKey, paramValue);

        Debug.Log(message);
        sceneLoader.SetParameter(paramKey, paramValue);
    }
}

