using UnityEngine;

public class TestIntermissionController : MonoBehaviour
{
    public string levelName = "Test level name";
    public string levelDescription = "'Allo 'Allo!";
    public float loadingDuration = 1f;
    public int nextLevelIndex;

	void OnEnable()
    {
        string testName = GetType().Name;

        TestingStatics.SetSceneParameter(testName, "Level Name", levelName);
        TestingStatics.SetSceneParameter(testName, "Level Description", levelDescription);
        TestingStatics.SetSceneParameter(testName, "Loading Duration", loadingDuration.ToString());
        TestingStatics.SetSceneParameter(testName, "Level Index", nextLevelIndex.ToString());
	}
}

