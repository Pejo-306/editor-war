using UnityEngine;

public class PlayerHealth : MonoBehaviour 
{
    public int health = 4;
    public float invincibilityTime = 2f;  // in seconds
    public SpriteFlasher spriteFlasher;
    private bool isInvincible = false;

    void Awake()
    {
        spriteFlasher = (spriteFlasher == null) ? GetComponent<SpriteFlasher>() : spriteFlasher;
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
                PersistantGameManager.Instance.GameOver();
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

