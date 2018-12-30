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
        int levelIndex = Int32.Parse(SceneLoader.Instance.GetParameter("Level Index"));

        PersistantGameManager.Instance.UseContinue();
        Fader.Instance.FadeOutOfLevel(levelIndex);
    }

    public void GiveUp(string nextSceneName)
    {
        Fader.Instance.FadeOutOfLevel(SceneLoader.GetScenePath(nextSceneName));
    }
}

