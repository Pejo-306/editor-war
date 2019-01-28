using UnityEngine;

/*
 * Define some static members which are useful in testing scripts.
 */
public static class TestingStatics 
{
    /*
     * Set a scene parameter.
     *
     * This method also displays a log message to the console.
     */
    public static void SetSceneParameter(string testName, string paramKey, string paramValue)
    {
        string message = string.Format("Setting parameter '{0}' to '{1}'", paramKey, paramValue);

        DebugMessage(testName, message);
        SceneLoader.Instance.SetParameter(paramKey, paramValue);
    }

    /*
     * Display an debug message to the console.
     *
     * An debug message follows the following format:
     * '<test name>: <debug message>'
     * The formatted message is returned by this method for reference.
     */
    public static string DebugMessage(string testName, string message)
    {
        string finalMessage = string.Format("{0}: {1}", testName, message);

        Debug.Log(finalMessage);
        return finalMessage;
    }
}

