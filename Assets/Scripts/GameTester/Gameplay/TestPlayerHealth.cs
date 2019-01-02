using UnityEngine;

public class TestPlayerHealth : MonoBehaviour 
{
    public GameObject player;
    public int damage = 1;
    public float delayTime = 1f;
    private bool isInvoked = false;

    void Start()
    {
        string message;

        if (player == null)
        {
            message = "no player provided";    
        }
        else if (player.GetComponent<PlayerHealth>() == null)
        {
            message = "PlayerHealth component isn't attached to 'player'";    
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
            Invoke("DamagePlayer", delayTime);
            isInvoked = true;
        }
    }

    private void DamagePlayer()
    {
        TestingStatics.DebugMessage(GetType().Name, "Damaging Player");
        player.GetComponent<PlayerHealth>().Damage(damage);
        isInvoked = false;
    }
}

