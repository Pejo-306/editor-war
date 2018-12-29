using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * required scene parameters:
 * "Loading Duration": float
 * "Level Index": int
 * "Level Name": string
 * "Level Description": string
 */
public class IntermissionController : MonoBehaviour
{
    public TextTypewriterEffect levelNameText;
    public Text levelDescriptionTextBox;
    public FakeLoadingBar loadingBar;
    private int nextLevelIndex;

    void Awake()
    {
		Dictionary<string, string> parameters = SceneLoader.Instance.GetSceneParameters();
        float loadingDuration = float.Parse(parameters["Loading Duration"], 
                CultureInfo.InvariantCulture.NumberFormat);

        levelNameText.textToDisplay = parameters["Level Name"];
        levelDescriptionTextBox.text = parameters["Level Description"];
        loadingBar.duration = loadingDuration; 
        nextLevelIndex = Int32.Parse(SceneLoader.Instance.GetParameter("Level Index"));
    }

    void Start()
    {
        Fader.Instance.FadeOutAfterDelay(nextLevelIndex, loadingBar.duration);
    }
}

