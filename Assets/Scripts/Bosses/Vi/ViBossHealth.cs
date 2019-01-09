using System.Collections.Generic;
using UnityEngine;

public class ViBossHealth : EntityHealth 
{
    public override void Damage(int damage = 1)
    {
        base.Damage(damage);
        if (health <= 0)
        {
            GetComponent<ViDeath>().PlayDeathAnimation();
        }
    }

    public void ComponentReceiveHit(Dictionary<string, object> parameters)
    {
        Damage((int)parameters["damage"]);
    }
}

