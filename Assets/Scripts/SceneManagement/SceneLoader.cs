﻿using System.Collections;
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

    public static string GetScenePath(string sceneName)
    {
        return SceneManagementConstants.scenesPath + sceneName;
    }

    public void Load(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Load(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public Dictionary<string, string> GetSceneParameters()
    {
        return parameters;
    }

    public string GetParameter(string paramKey)
    {
        return (parameters == null) ? "" : parameters[paramKey];
    }

    public void SetParameter(string paramKey, string paramValue)
    {
        if (parameters == null)
        {
            parameters = new Dictionary<string, string>();
        }

        if (!parameters.ContainsKey(paramKey))
        {
            parameters.Add(paramKey, paramValue);
        }
        else
        {
            parameters[paramKey] = paramValue;
        }
    }

    public void SetAllParameters(Dictionary<string, string> parameters)
    {
        this.parameters = new Dictionary<string, string>(parameters);
    }

    public void SetAllParameters(List<SceneParameter> parameters)
    {
        if (this.parameters != null)
        {
            this.parameters.Clear();
        }
        foreach (SceneParameter parameter in parameters)
        {
            SetParameter(parameter.paramKey, parameter.paramValue);
        }
    }
}

