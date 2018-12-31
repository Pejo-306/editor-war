using UnityEngine;

public class TestContinueButton : MonoBehaviour
{
    public int nextLevelIndex;

    void OnEnable()
    {
        TestingStatics.SetSceneParameter(GetType().Name, "Level Index", nextLevelIndex.ToString()); 
    }
}

