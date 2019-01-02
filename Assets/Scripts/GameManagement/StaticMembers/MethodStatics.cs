using System.Collections.Generic;
using UnityEngine;

public class MethodStatics : MonoBehaviour
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
}

