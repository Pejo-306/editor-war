using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public int damage;
    public string tagToHit;

    void OnCollisionEnter2D(Collision2D collision)
    {
        HitReceiver hitReceiver;

        if (collision.gameObject.CompareTag(tagToHit))
        {
            Destroy(gameObject);

            hitReceiver = collision.gameObject.GetComponent<HitReceiver>();
            if (hitReceiver)
            {
                hitReceiver.AddCalledMethodParameter("damage", damage);
                hitReceiver.ReceiveHit();
            }
        }
    }
}

