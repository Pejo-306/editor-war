using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    public int horizontalMovementSpeed = 16;
    public int verticalMovementSpeed = 10;

	private void Update() 
    {
        float horizontalAxisInput = Input.GetAxisRaw("Horizontal");
        float verticalAxisInput = Input.GetAxisRaw("Vertical");

        if (horizontalAxisInput == 1)
        {
            transform.Translate(Vector2.right * horizontalMovementSpeed * Time.deltaTime);
        }
        else if (horizontalAxisInput == -1) {
            transform.Translate(Vector2.left * horizontalMovementSpeed * Time.deltaTime);
        }

        if (verticalAxisInput == 1)
        {
            transform.Translate(Vector2.up * verticalMovementSpeed * Time.deltaTime);
        }
        else if (verticalAxisInput == -1) {
            transform.Translate(Vector2.down * verticalMovementSpeed * Time.deltaTime);
        }
	}
}

