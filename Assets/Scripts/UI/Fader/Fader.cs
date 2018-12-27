using UnityEngine;
using UnityEngine.SceneManagement;

public class Fader : MonoBehaviour
{
    public static Fader Instance { get; private set; }

    public Animator animator;
    private string nextLevelName;

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

    public void OnFadeInComplete()
    {
        animator.ResetTrigger("FadeIn");
    }

    public void OnFadeOutComplete()
    {
        animator.ResetTrigger("FadeOut");
        SceneManager.LoadScene(nextLevelName);
    }
}

