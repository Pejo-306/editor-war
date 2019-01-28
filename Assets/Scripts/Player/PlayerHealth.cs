using System.Collections.Generic;
using UnityEngine;

/*
 * Player's health component.
 * Flashes the player's sprite on hit.
 */
public class PlayerHealth : EntityHealth 
{
    public SpriteFlasher spriteFlasher;

    void Awake()
    {
        spriteFlasher = (spriteFlasher == null) ? GetComponent<SpriteFlasher>() : spriteFlasher;
    }

    /*
     * Trigger player death animation.
     */
    public void PlayDeathAnimation(float delay = 1f)
    {
        GetComponent<Animator>().SetTrigger("isDead");
        spriteFlasher.enabled = false;
    }

    /*
     * Reset trigger for player death animation.
     */
    public void OnPlayerDeathAnimationEnd()
    {
        GetComponent<Animator>().ResetTrigger("isDead");
        GetComponent<SpriteRenderer>().enabled = false;
    }

    /*
     * Trigger game over.
     */
    protected override void OnEntityDeath()
    {
        PersistantGameManager.Instance.GameOver();
    }

    /*
     * Flash the player on hit.
     */
    protected override void OnEntityHit()
    {
        spriteFlasher.StartFlashing();
        spriteFlasher.Invoke("StopFlashing", invincibilityTime);
    }

    public void ComponentReceiveHit(Dictionary<string, object> parameters)
    {
        Damage((int)parameters["damage"]);
    }

}

