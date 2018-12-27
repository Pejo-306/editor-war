using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileDuration = 5f;
    public float projectileVelocity = 15f;
    private Rigidbody2D rb2D;

	void Start() 
    {
        rb2D = GetComponent<Rigidbody2D>();
        Destroy(gameObject, projectileDuration);	
	}

    void FixedUpdate()
    {
        Vector2 velocity = new Vector2(0, projectileVelocity);

        rb2D.MovePosition(rb2D.position + velocity * Time.fixedDeltaTime);
    }
}

