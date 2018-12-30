using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fader : MonoBehaviour
{
    public Animator animator;
    public bool fadeIn = true;
    public bool fadeOut = true;
    private string nextLevelName;
    private int nextLevelIndex = -1;

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
        if (fadeIn)
        {
            animator.SetTrigger("FadeIn");
            if (animator.gameObject.activeSelf)
            {
                animator.Play("FadeIn");
            }
        }
    }

    public void FadeOutOfLevel(string levelName)
    {
        nextLevelName = levelName;
        if (fadeOut)
        {
            animator.SetTrigger("FadeOut");
            if (animator.gameObject.activeSelf)
            {
                animator.Play("FadeOut");
            }
        }
        else
        {
            LoadNextScene();
        }
    }

    public void FadeOutOfLevel(int levelIndex)
    {
        nextLevelIndex = levelIndex;
        if (fadeOut)
        {
            animator.SetTrigger("FadeOut");
            if (animator.gameObject.activeSelf)
            {
                animator.Play("FadeOut");
            }
        }
        else
        {
            LoadNextScene();
        }
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
        LoadNextScene();
    }

    private void LoadNextScene()
    {
        if (nextLevelIndex == -1)  // load next scene by name
        {
            SceneLoader.Instance.Load(nextLevelName);
        }
        else  // load next scene by index
        {
            SceneLoader.Instance.Load(nextLevelIndex);
        }
        nextLevelIndex = -1;
    }
}

