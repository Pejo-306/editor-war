using System.Collections.Generic;
using UnityEngine;

public class ViBossHealth : EntityHealth 
{
    public void ComponentReceiveHit(Dictionary<string, object> parameters)
    {
        Damage((int)parameters["damage"]);
    }
}

