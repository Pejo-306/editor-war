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
}

