using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fader : MonoBehaviour
{
    public static Fader Instance { get; private set; }

    public Animator animator;
    private string nextLevelName;
    private int nextLevelIndex = -1;
    private List<SceneLoader.SceneParameter> nextSceneParameters;

    void Awake()
    {
        // singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += FadeIntoLevel;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= FadeIntoLevel;
    }

    public void FadeIntoLevel(Scene scene, LoadSceneMode mode)
    {
        animator.SetTrigger("FadeIn");
    }

    public void FadeOutOfLevel(string levelName)
    {
        nextLevelName = levelName;
        animator.SetTrigger("FadeOut");
    }

    public void FadeOutOfLevel(int levelIndex)
    {
        nextLevelIndex = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeInComplete()
    {
        animator.ResetTrigger("FadeIn");
    }

    public void setNextSceneParameters(List<SceneLoader.SceneParameter> parameters)
    {
        nextSceneParameters = new List<SceneLoader.SceneParameter>(parameters);
    }

    public void OnFadeOutComplete()
    {
        animator.ResetTrigger("FadeOut");
        if (nextLevelIndex == -1)  // load next scene by name
        {
            SceneLoader.Instance.Load(nextLevelName, nextSceneParameters);
        }
        else  // load next scene by index
        {
            SceneLoader.Instance.Load(nextLevelIndex, nextSceneParameters);
        }
    }
}

