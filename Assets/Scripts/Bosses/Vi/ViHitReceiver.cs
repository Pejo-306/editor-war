using UnityEngine;

/// <summary>
/// Component which describes Vi receiving a hit.
/// </summary>
/// <remarks>
/// Should only be added to Vi's game object.
/// </remarks>
public class ViHitReceiver : HitReceiver
{
    /// <summary>
    /// Damage Vi boss.
    /// </summary>
    /// <param name="args">
    /// Variable-length list of parameters. Should contain damage amount 
    /// as first argument.
    /// </param>
    public override void ReceiveHit(params object[] args)
    {
        int damage = (int)args[0];

        GetComponent<ViHealth>().Damage(damage);
    }
}
