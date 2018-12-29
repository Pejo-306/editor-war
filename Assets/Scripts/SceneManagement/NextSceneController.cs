using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextSceneController : MonoBehaviour
{
    public List<SceneLoader.SceneParameter> nextSceneParameters;

	void Start()
    {
		SceneLoader.Instance.SetAllParameters(nextSceneParameters);
	}
}

