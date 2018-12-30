using System;
using UnityEngine;

/*
 * required scene parameters:
 * "Level Index": int
 */
public class ContinueScreenController : MonoBehaviour
{
    public void Continue()
    {
        foreach (var param in SceneLoader.Instance.GetSceneParameters())
        {
            Debug.Log("key: " + param.Key + " value: " + param.Value);
        }
        int levelIndex = Int32.Parse(SceneLoader.Instance.GetParameter("Level Index"));

        Fader.Instance.FadeOutOfLevel(levelIndex);
    }

    public void GiveUp(string nextSceneName)
    {
        string scene = SceneLoader.scenesPath + nextSceneName;

        Fader.Instance.FadeOutOfLevel(scene);
    }
}

