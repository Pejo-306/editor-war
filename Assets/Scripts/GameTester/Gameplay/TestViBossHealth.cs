using UnityEngine;

public class TestViBossHealth : MonoBehaviour {
    public GameObject viBoss;
    public int damage = 10;
    public float delayTime = 1f;
    private bool isInvoked = false;

	void Start()
    {
		string message;

        if (viBoss == null)
        {
            message = "Vi boss is not provided";
        }
        else if (viBoss.GetComponent<ViBossHealth>() == null)
        {
            message = "ViBossHealth component isn't attached to 'Vi boss'";
        }
        else
        {
            message = "OK";
        }
        TestingStatics.DebugMessage(GetType().Name, message);
	}
	
	void Update() 
    {
		if (!isInvoked)
        {
            Invoke("DamageVi", delayTime);
            isInvoked = true;
        }
	}

    private void DamageVi()
    {
        TestingStatics.DebugMessage(GetType().Name, "Damaging Vi boss");
        viBoss.GetComponent<ViBossHealth>().Damage(damage);
        isInvoked = false;
    }
}
