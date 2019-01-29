using UnityEngine;

/*
 * Detail the behaviour of Vi's movement tester.
 *
 * The movement tester is an invisible light copy of Vi with the latter's
 * physical dimensions. The tester preemptively applies movement commands,
 * testing whether they may be also applied to the boss itself. If the copy
 * collides with an invisible wall the movement command is nullified.
 */
public class ViMovementTester : MonoBehaviour
{
    // Vi - a reference to the boss.
    public ViMovement vi;

    // The confining movement field of the boss. The latter may not venture
    // outside of the field.
    public MovementField movementField;
    
    /*
     * Preemptively execute Vi's next movement command.
     *
     * The command is executed on the previous update cycle that Vi would
     * apply its movement command.
     */
    public void ApplyMovement()
    {
        FreeMovementField();
        vi.nextMovement.Execute(transform, vi.motionUnit); 
    }

    /*
     * Revert the effects of Vi's next movement command.
     *
     * The movement tester is returned to its pre-applied movement command
     * position. The command itself is nullified and thus - never executed
     * on Vi.
     */
    public void RevertMovement()
    {
        LockMovementField();
        vi.nextMovement.ExecuteOpposite(transform, vi.motionUnit); 
        vi.nextMovement = null;
    }

    /*
     * Allow the movement field to continue following its assigned 
     * object to be followed.
     */
    private void FreeMovementField()
    {
        movementField.GetComponent<GameObjectFollower>().ContinueFollowing();
    }

    /*
     * Deter the movement field from following its assigned 
     * object to be followed.
     */
    private void LockMovementField()
    {
        movementField.GetComponent<GameObjectFollower>().StopFollowing();
    }
}

