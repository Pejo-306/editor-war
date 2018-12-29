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
    public float additionalDelayTime;

	void Awake()
    {
		Dictionary<string, string> parameters = SceneLoader.Instance.GetSceneParameters();
        float loadingDuration = float.Parse(parameters["Loading Duration"], 
                CultureInfo.InvariantCulture.NumberFormat);
        int levelIndex = Int32.Parse(parameters["Level Index"]);

        levelNameText.textToDisplay = parameters["Level Name"];
        levelDescriptionTextBox.text = parameters["Level Description"];
        loadingBar.duration = loadingDuration; 

        StartCoroutine(LoadLevelAfterDelay(levelIndex, loadingDuration));
	}

    IEnumerator LoadLevelAfterDelay(int levelIndex, float loadingTime)
    {
        yield return new WaitForSeconds(loadingTime + additionalDelayTime);
        Fader.Instance.FadeOutOfLevel(levelIndex);
    }
}

