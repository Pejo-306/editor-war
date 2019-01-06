using UnityEngine;

public class EntityHealth : MonoBehaviour
{
    public int health = 100;

    public virtual void Damage(int damage = 1)
    {
        health -= damage;
    }
}

