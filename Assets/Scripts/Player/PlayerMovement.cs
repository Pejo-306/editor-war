using UnityEngine;

/*
 * Game logic for the main player's movement
 */
public class PlayerMovement : MonoBehaviour 
{
    public float horizontalMovementSpeed = 16f;

    public float verticalMovementSpeed = 10f;

    private Rigidbody2D rb2D;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    /*
     * Determine the horizontal and vertical velocity.
     * Move the player with the calculated speed.
     */
    void FixedUpdate()
    {
        float horizontalAxisInput = Input.GetAxisRaw("Horizontal");
        float verticalAxisInput = Input.GetAxisRaw("Vertical");
        Vector2 velocity = new Vector2(0, 0);

        // Set horizontal movement speed.
        if (horizontalAxisInput == 1)
        {
            velocity[0] = horizontalMovementSpeed;  // right
        }
        else if (horizontalAxisInput == -1) 
        {
            velocity[0] = -horizontalMovementSpeed;  // left
        }

        // Set vertical movement speed.
        if (verticalAxisInput == 1)
        {
            velocity[1] = verticalMovementSpeed;  // up
        }
        else if (verticalAxisInput == -1) 
        {
            velocity[1] = -verticalMovementSpeed;  // down
        }
        rb2D.MovePosition(rb2D.position + velocity * Time.fixedDeltaTime);
    }
}

