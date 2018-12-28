using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// reference:
// https://forum.unity.com/threads/unity-beginner-loadlevel-with-arguments.180925/

public class SceneLoader : MonoBehaviour
{
    [System.Serializable]
    public struct SceneParameter
    {
        public string paramKey;
        public string paramValue;
    }

    public static SceneLoader Instance { get; private set; }

    private Dictionary<string, string> parameters;

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

    public void Load(string sceneName, Dictionary<string, string> parameters = null)
    {
        this.parameters = (parameters == null) ? new Dictionary<string, string>() : parameters;
        SceneManager.LoadScene(sceneName);
    }

    public void Load(int sceneIndex, Dictionary<string, string> parameters = null)
    {
        this.parameters = (parameters == null) ? new Dictionary<string, string>() : parameters;
        SceneManager.LoadScene(sceneIndex);
    }

    public void Load(string sceneName, string paramKey, string paramValue)
    {
        parameters = new Dictionary<string, string>();
        parameters.Add(paramKey, paramValue);
        SceneManager.LoadScene(sceneName);
    }

    public void Load(int sceneIndex, string paramKey, string paramValue)
    {
        parameters = new Dictionary<string, string>();
        parameters.Add(paramKey, paramValue);
        SceneManager.LoadScene(sceneIndex);
    }

    public void Load(string sceneName, List<SceneParameter> parameters)
    {
        parseParametersList(parameters);
        SceneManager.LoadScene(sceneName);
    }

    public void Load(int sceneIndex, List<SceneParameter> parameters)
    {
        parseParametersList(parameters);
        SceneManager.LoadScene(sceneIndex);
    }


    public Dictionary<string, string> GetSceneParameters()
    {
        return parameters;
    }

    public string GetParam(string paramKey)
    {
        return (parameters == null) ? "" : parameters[paramKey];
    }

    public void SetParam(string paramKey, string paramValue)
    {
        parameters.Add(paramKey, paramValue);
    }

    private void parseParametersList(List<SceneParameter> parameters)
    {
        this.parameters = new Dictionary<string, string>();
        foreach (SceneParameter parameter in parameters)
        {
            this.parameters.Add(parameter.paramKey, parameter.paramValue);
        }
    }
}

