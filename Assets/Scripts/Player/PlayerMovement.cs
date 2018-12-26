using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    public float horizontalMovementSpeed = 16f;
    public float verticalMovementSpeed = 10f;
    private Rigidbody2D rb2D;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float horizontalAxisInput = Input.GetAxisRaw("Horizontal");
        float verticalAxisInput = Input.GetAxisRaw("Vertical");
        Vector2 velocity = new Vector2(0, 0);

        if (horizontalAxisInput == 1)
        {
            velocity[0] = horizontalMovementSpeed;
        }
        else if (horizontalAxisInput == -1) 
        {
            velocity[0] = -horizontalMovementSpeed;
        }
        if (verticalAxisInput == 1)
        {
            velocity[1] = verticalMovementSpeed;
        }
        else if (verticalAxisInput == -1) 
        {
            velocity[1] = -verticalMovementSpeed;
        }
        rb2D.MovePosition(rb2D.position + velocity * Time.fixedDeltaTime);
    }
}

