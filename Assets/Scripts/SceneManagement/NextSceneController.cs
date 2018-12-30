using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextSceneController : MonoBehaviour
{
    public List<SceneLoader.SceneParameter> nextSceneParameters;

	public void SetNextSceneParameters()
    {
		SceneLoader.Instance.SetAllParameters(nextSceneParameters);
	}

    public void SetParameter(string paramKey, string paramValue)
    {
        var parameter = new SceneLoader.SceneParameter();
        
        parameter.paramKey = paramKey;
        parameter.paramValue = paramValue;
        nextSceneParameters.Add(parameter);
    }
}

