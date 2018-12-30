﻿using UnityEngine;

public class GameOverScreenController : MonoBehaviour
{
    public string mainMenuSceneName;
    public float delayTime;

    void OnEnable()
    {
        Fader.Instance.FadeOutAfterDelay(SceneLoader.GetScenePath(mainMenuSceneName), delayTime);
    }
}

