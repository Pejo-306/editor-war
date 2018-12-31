using UnityEngine;

public class TestPlayerHealth : MonoBehaviour 
{
    public GameObject player;
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
            Invoke("DamagePlayer", 1);
            isInvoked = true;
        }
    }

    private void DamagePlayer()
    {
        player.GetComponent<PlayerHealth>().Damage();
        isInvoked = false;
    }
}

