using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float duration = 2f;
    public float velocity = 15f;
    [HideInInspector]
    public Vector2 direction;

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
}

