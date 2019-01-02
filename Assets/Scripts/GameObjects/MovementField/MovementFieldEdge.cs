using UnityEngine;

public class MovementFieldEdge : MonoBehaviour
{
    public MovementField movementField;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject == movementField.objectToContain)
        {
            movementField.objectToContain.BroadcastMessage("RevertMovement");
        }
    }
}

