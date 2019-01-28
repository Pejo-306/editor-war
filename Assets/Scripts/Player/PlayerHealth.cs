using System.Collections;
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
        spriteFlasher.enabled = false;
        StartCoroutine(StartDeathAnimation(delay));
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

    /*
     * Start the death animation after some delay.
     */
    private IEnumerator StartDeathAnimation(float delay = 1f)
    {
        yield return new WaitForSeconds(delay);
        GetComponent<Animator>().SetTrigger("isDead");
    }
}

