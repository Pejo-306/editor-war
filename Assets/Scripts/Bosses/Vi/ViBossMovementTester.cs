using UnityEngine;

public class ViBossMovementTester : MonoBehaviour
{
    public ViBossMovement vi;
    
    public void ApplyMovement()
    {
        vi.nextMovement.Execute(transform, vi.motionUnit); 
    }

    public void RevertMovement()
    {
        vi.nextMovement.ExecuteOpposite(transform, vi.motionUnit); 
        vi.nextMovement = null;
    }
}

