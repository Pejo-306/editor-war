using System;
using System.Globalization;
using UnityEngine;

public class PlayerDeathScreenContoller : MonoBehaviour
{
    public Fader fader;
    public float delayTime = 4f;

    void OnEnable()
    {
        var playerDeathAnimation = GameObject.FindWithTag("Player");
        var nextSceneController = GetComponent<NextSceneController>();
        string nextSceneName = SceneLoader.Instance.GetParameter("Next Scene");

        playerDeathAnimation.transform.position = GetPreviousPlayerPosition();
        nextSceneController.SetParameter("Level Index", 
                SceneLoader.Instance.GetParameter("Level Index"));
        fader.FadeOutAfterDelay(SceneLoader.GetScenePath(nextSceneName), delayTime);
    }

    private Vector2 GetPreviousPlayerPosition()
    {
        string[] coordsStr = SceneLoader.Instance.GetParameter("Player Position").Split(
                new char[] { ',' }, 2, StringSplitOptions.None);
        float[] coords = new float[2];

        for (int i = 0; i < coordsStr.Length; ++i)
        {
            coords[i] = float.Parse(coordsStr[i], CultureInfo.InvariantCulture.NumberFormat);
        }
        return new Vector2(coords[0], coords[1]);
    }
}

