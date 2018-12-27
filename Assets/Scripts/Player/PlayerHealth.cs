using UnityEngine;

public class PlayerHealth : MonoBehaviour 
{
    public int health = 4;
    public float invincibilityTime = 2f;  // in seconds
    private SpriteFlasher spriteFlasher;
    private bool isInvincible = false;

    void Start()
    {
        spriteFlasher = GetComponent<SpriteFlasher>();
    }

    public void Damage(int damage = 1)
    {
        if (!isInvincible)
        {
            health -= damage;

            Debug.Log("Player health: " + health);
            if (health <= 0)
            {
                // TODO: game should end here
                Debug.Log("Player is dead");
            }
            else
            {
                isInvincible = true;
                spriteFlasher.StartFlashing();
                Invoke("RemoveInvincibility", invincibilityTime);
                spriteFlasher.Invoke("StopFlashing", invincibilityTime);
            }
        }
        else
        {
            Debug.Log("Player is invincible");
        }
    }

    private void RemoveInvincibility()
    {
        isInvincible = false;
        Debug.Log("Player is not invincible");
    }
}

