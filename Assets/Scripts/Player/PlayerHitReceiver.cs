using UnityEngine;

/// <summary>
/// Component which describes the player receiving a hit.
/// </summary>
/// <remarks>
/// Should only be added to the Player's game object.
/// </remarks>
public class PlayerHitReceiver : HitReceiver
{
    /// <summary>
    /// Damage the player.
    /// </summary>
    /// <param name="args">
    /// Variable-length list of parameters. Should contain damage amount 
    /// as first argument.
    /// </param>
    public override void ReceiveHit(params object[] args)
    {
        int damage = (int)args[0];

        GetComponent<PlayerHealth>().Damage(damage);
    }
}

