using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public int damage;
    public string tagToHit;
    public bool destroyDamageDealer = true;
    public bool onTrigger = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!onTrigger && collision.gameObject.CompareTag(tagToHit))
        {
            if (destroyDamageDealer)
            {
                Destroy(gameObject);
            }

            ApplyDamage(collision.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (onTrigger && collider.gameObject.CompareTag(tagToHit))
        {
            if (destroyDamageDealer)
            {
                Destroy(gameObject);
            }

            ApplyDamage(collider.gameObject);
        }
    }

    private void ApplyDamage(GameObject affectedObject)
    {
        var hitReceiver = affectedObject.GetComponent<HitReceiver>();

        if (hitReceiver)
        {
            hitReceiver.AddCalledMethodParameter("damage", damage);
            hitReceiver.ReceiveHit();
        }
    }
}

