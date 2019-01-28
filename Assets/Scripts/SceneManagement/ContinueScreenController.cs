using System;
using UnityEngine;

/*
 * required scene parameters:
 * "Level Index": int
 */
public class ContinueScreenController : MonoBehaviour
{
    public Fader fader;

    public void Continue()
    {
        int levelIndex = Int32.Parse(SceneLoader.Instance.GetParameter("Level Index"));

        PersistantGameManager.Instance.UseContinue();
        fader.FadeOutOfLevel(levelIndex);
    }

    public void GiveUp(string nextScenePath)
    {
        fader.FadeOutOfLevel(nextScenePath);
    }
}

