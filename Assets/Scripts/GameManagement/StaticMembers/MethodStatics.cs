using System.Collections.Generic;
using UnityEngine;

/*
 * Define several static methods used throughout the project.
 */
public static class MethodStatics
{
    [System.Serializable]
    public struct MethodParameter
    {
        public string name;

        public object val;

        public MethodParameter(string name, object val)
        {
            this.name = name;
            this.val = val;
        }
    }

    public static void ParseMethodParametersToDictionary(IEnumerable<MethodParameter> collection,
            Dictionary<string, object> methodParametersDictionary)
    {
        foreach (var parameter in collection)
        {
            if (methodParametersDictionary.ContainsKey(parameter.name))
            {
                methodParametersDictionary[parameter.name] = parameter.val;
            }
            else
            {
                methodParametersDictionary.Add(parameter.name, parameter.val);
            }
        }
    }

    public static float GetScreenHeight()
    {
        return Camera.main.orthographicSize * 2f;
    }

    public static float GetScreenWidth()
    {
        return Camera.main.orthographicSize * 2f * Screen.width / Screen.height;
    }
}

