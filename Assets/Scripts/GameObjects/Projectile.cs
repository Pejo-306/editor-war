using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float duration = 2f;
    public float velocity = 15f;
    [HideInInspector]
    public Vector2 direction;
    public GameObject destructionVFX;
    public float destructionVFXDuration;

    private Rigidbody2D rb2D;

	void Start() 
    {
        rb2D = GetComponent<Rigidbody2D>();
        Destroy(gameObject, duration);
	}

    void FixedUpdate()
    {
        Vector2 relativeOffset = direction * velocity * Time.fixedDeltaTime;

        rb2D.MovePosition(rb2D.position + relativeOffset);
    }

    void OnDestroy()
    {
        GameObject vfxInstance;
        Vector2 vfxPosition;

        if (destructionVFX != null)
        {
            vfxPosition = new Vector2(GetComponent<BoxCollider2D>().size.x +
                    transform.position.x, transform.position.y);
            vfxInstance = Instantiate(destructionVFX, vfxPosition, Quaternion.identity);
            Destroy(vfxInstance, destructionVFXDuration);
        }
    }
}

