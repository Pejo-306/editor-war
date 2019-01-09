using UnityEngine;

public class ViDestructionParticle : MonoBehaviour
{
    public float destructionDelayTime = 0.666f;

	void Start()
    {
	    Destroy(gameObject, destructionDelayTime);	
	}
}

