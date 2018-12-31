using UnityEngine;

public class TestingStatics : MonoBehaviour 
{
    public static void SetSceneParameter(string testName, string paramKey, string paramValue)
    {
        string message = string.Format("Setting parameter '{0}' to '{1}'", paramKey, paramValue);

        DebugMessage(testName, message);
        SceneLoader.Instance.SetParameter(paramKey, paramValue);
    }

    public static string DebugMessage(string testName, string message)
    {
        string finalMessage = string.Format("{0}: {1}", testName, message);

        Debug.Log(finalMessage);
        return finalMessage;
    }
}

