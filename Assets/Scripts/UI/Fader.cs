using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fader : MonoBehaviour
{
    public static Fader Instance { get; private set; }

    public Animator animator;
    private string nextLevelName;
    private int nextLevelIndex = -1;

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

    public void FadeOutAfterDelay(string levelName, float delayTime)
    {
        StartCoroutine(LoadLevelAfterDelay(levelName, delayTime));
    }

    public void FadeOutAfterDelay(int levelIndex, float delayTime)
    {
        StartCoroutine(LoadLevelAfterDelay(levelIndex, delayTime));
    }

    IEnumerator LoadLevelAfterDelay(string levelName, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        FadeOutOfLevel(levelName);
    }

    IEnumerator LoadLevelAfterDelay(int levelIndex, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        FadeOutOfLevel(levelIndex);
    }

    public void OnFadeInComplete()
    {
        animator.ResetTrigger("FadeIn");
    }

    public void OnFadeOutComplete()
    {
        animator.ResetTrigger("FadeOut");
        if (nextLevelIndex == -1)  // load next scene by name
        {
            SceneLoader.Instance.Load(nextLevelName);
        }
        else  // load next scene by index
        {
            SceneLoader.Instance.Load(nextLevelIndex);
        }
    }
}

