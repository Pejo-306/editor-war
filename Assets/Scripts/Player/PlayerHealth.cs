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

