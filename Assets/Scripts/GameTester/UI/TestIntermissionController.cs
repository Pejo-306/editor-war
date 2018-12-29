using UnityEngine;

public class TestIntermissionController : MonoBehaviour
{
    public string levelName = "Test level name";
    public string levelDescription = "'Allo 'Allo!";
    public float loadingDuration = 1f;
    public int nextLevelIndex;

	void OnEnable()
    {
        SetSceneParameter("Level Name", levelName);
        SetSceneParameter("Level Description", levelDescription);
        SetSceneParameter("Loading Duration", loadingDuration.ToString());
        SetSceneParameter("Level Index", nextLevelIndex.ToString());
	}

    private void SetSceneParameter(string paramKey, string paramValue)
    {
        SceneLoader sceneLoader = (SceneLoader)FindObjectOfType(typeof(SceneLoader));
        string message = string.Format(
                "TestIntermissionController: Setting parameter '{0}' to '{1}'",
                paramKey, paramValue);

        Debug.Log(message);
        sceneLoader.SetParameter(paramKey, paramValue);
    }
}

