using UnityEngine;

public class ViBossMovementTester : MonoBehaviour
{
    public ViBossMovement vi;
    public MovementField movementField;
    
    public void ApplyMovement()
    {
        FreeMovementField();
        vi.nextMovement.Execute(transform, vi.motionUnit); 
    }

    public void RevertMovement()
    {
        LockMovementField();
        vi.nextMovement.ExecuteOpposite(transform, vi.motionUnit); 
        vi.nextMovement = null;
    }

    private void FreeMovementField()
    {
        movementField.GetComponent<GameObjectFollower>().ContinueFollowing();
    }

    private void LockMovementField()
    {
        movementField.GetComponent<GameObjectFollower>().StopFollowing();
    }
}

