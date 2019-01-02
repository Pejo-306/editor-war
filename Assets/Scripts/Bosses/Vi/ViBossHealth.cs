using System.Collections.Generic;
using UnityEngine;

public class ViBossHealth : MonoBehaviour
{
    public int health = 100;

    public void Damage(int damage = 1)
    {
        health -= damage;
    }

    public void ComponentReceiveHit(Dictionary<string, object> parameters)
    {
        Damage((int)parameters["damage"]);
    }
}

