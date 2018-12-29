using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntermissionController : MonoBehaviour
{
    public TextTypewriterEffect levelNameText;
    public Text levelDescriptionTextBox;
    public FakeLoadingBar loadingBar;
    public float additionalDelayTime;

	void Awake()
    {
		Dictionary<string, string> parameters = SceneLoader.Instance.GetSceneParameters();
        float loadingDuration = float.Parse(parameters["loadingDuration"], 
                CultureInfo.InvariantCulture.NumberFormat);
        int levelIndex = Int32.Parse(parameters["levelIndex"]);

        levelNameText.textToDisplay = parameters["levelName"];
        levelDescriptionTextBox.text = parameters["levelDescription"];
        loadingBar.duration = loadingDuration; 

        StartCoroutine(LoadLevelAfterDelay(levelIndex, loadingDuration));
	}

    IEnumerator LoadLevelAfterDelay(int levelIndex, float loadingTime)
    {
        yield return new WaitForSeconds(loadingTime + additionalDelayTime);
        Fader.Instance.FadeOutOfLevel(levelIndex);
    }
}

