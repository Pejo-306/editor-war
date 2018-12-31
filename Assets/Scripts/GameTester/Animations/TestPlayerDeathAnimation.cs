using UnityEngine;

public class TestPlayerDeathAnimation : MonoBehaviour
{
    public string nextSceneName;
    public int levelIndex;
    public Vector2 playerPosition;

    void OnEnable()
    {
        string testName = GetType().Name;
        string positionString = string.Format("{0:n3},{1:n3}", playerPosition.x, playerPosition.y);

        TestingStatics.SetSceneParameter(testName, "Next Scene", nextSceneName);
        TestingStatics.SetSceneParameter(testName, "Level Index", levelIndex.ToString());
        TestingStatics.SetSceneParameter(testName, "Player Position", positionString);
    }
}

