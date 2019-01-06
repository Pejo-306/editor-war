using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public int damage;
    public string tagToHit;
    public bool destroyDamageDealer = true;

    void OnCollisionEnter2D(Collision2D collision)
    {
        HitReceiver hitReceiver;

        if (collision.gameObject.CompareTag(tagToHit))
        {
            if (destroyDamageDealer)
            {
                Destroy(gameObject);
            }

            hitReceiver = collision.gameObject.GetComponent<HitReceiver>();
            if (hitReceiver)
            {
                hitReceiver.AddCalledMethodParameter("damage", damage);
                hitReceiver.ReceiveHit();
            }
        }
    }
}

