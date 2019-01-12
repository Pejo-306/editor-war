using UnityEngine;

/*
 * Add health to an entity.
 * Include base game logic for handling damage.
 */
public abstract class EntityHealth : MonoBehaviour
{
    public int health = 100;

    public float invincibilityTime = 2f;  // in seconds

    private bool isInvincible = false;

    /*
     * Damage the entity's health with some passed amount.
     * Delay further damage by some invincibility time.
     */
    public void Damage(int damage = 1)
    {
        if (!isInvincible)
        {
            health -= damage;

            // Trigger entity death.
            if (health <= 0)
            {
                OnEntityDeath();
            }
            isInvincible = true;
            Invoke("RemoveInvincibility", invincibilityTime);
            OnEntityHit();
        }
    }

    /*
     * Actions to be taken on entity's death.
     */
    protected abstract void OnEntityDeath();

    /*
     * Actions to be taken on entity hit.
     */
    protected abstract void OnEntityHit();

    /*
     * Helper method to remove invincibility.
     */
    private void RemoveInvincibility()
    {
        isInvincible = false;
    }
}

