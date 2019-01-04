using UnityEngine;

public class MovementFieldFollowerReceiver : MonoBehaviour 
{
    public float followSpeed = 1f;

    private Rigidbody2D rb2D;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    public void MoveObjectFollowerInDirection(Vector2 direction)
    {
        rb2D.AddForce(direction * followSpeed, ForceMode2D.Force);
    }

    public void StopObjectFollowerMovement()
    {
        rb2D.velocity = Vector2.zero;
    }
}

