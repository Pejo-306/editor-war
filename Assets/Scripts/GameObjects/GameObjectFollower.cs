using UnityEngine;

/*
 * Component behaviour to follow another game object.
 *
 * Game objects which include this component will constantly follow a 
 * designated target object. This class implements the logic to determine the
 * direction in which the follower has to move to close the gap between it and
 * its target. Furthermore, the follower may be told to follow its target only
 * vertically or horizontally. How the follower object actually performs the
 * movement is left to be implemented by a subclass.
 */
public abstract class GameObjectFollower : MonoBehaviour
{
    // The game object which is to be followed.
    public GameObject targetObject;

    // Should the game object follow its target on the 'x' axis.
    public bool followXAxis = false;

    // Should the game object follow its target on the 'y' axis.
    public bool followYAxis = false;

    // The moving direction in order to follow the target object. Both x and y
    // values can be in the set {-1; 0; 1}.
    protected Vector2 direction = Vector2.zero;

    // Is the game object currently following its target.
    private bool isFollowing = true;

    /*
     * Move the follower towards its target.
     *
     * Firstly, the direction in which the follower should move in is determined.
     * The direction is represented as a Vector2 which can hold values in the
     * following set {-1; 0; 1}. The method only sets the following direction
     * for an axis if designated via the 'followXAxis' and 'followYAxis'
     * variables. Afterwards, the follower is moved in the recently determined
     * direction, closing the distance between it and its target.
     */
    void FixedUpdate()
    {
        float distanceToTarget;

        if (isFollowing)
        {
            if (followXAxis)
            {
                // Determine direction to follow on the 'x' axis.
                distanceToTarget = targetObject.transform.position.x - transform.position.x;
                if (distanceToTarget > 0)
                {
                    direction.x = 1;
                }
                else if (distanceToTarget < 0)
                {
                    direction.x = -1;
                }
                else
                {
                    direction.x = 0;
                }
            }
            else
            {
                direction.x = 0;
            }
            if (followYAxis)
            {
                // Determine direction to follow on the 'y' axis.
                distanceToTarget = targetObject.transform.position.y - transform.position.y;
                if (distanceToTarget > 0)
                {
                    direction.y = 1;
                }
                else if (distanceToTarget < 0)
                {
                    direction.y = -1;
                }
                else
                {
                    direction.y = 0;
                }
            }
            else
            {
                direction.y = 0;
            }
            MoveFollower();
        }
        else
        {
            StopFollower();
        }
    }

    /*
     * Allow the follower to continue following its target.
     */
    public void ContinueFollowing()
    {
        isFollowing = true;
    }

    /*
     * Deter the follower from following its target.
     */
    public void StopFollowing()
    {
        isFollowing = false;
    }

    /*
     * Move the follower in the specified direction.
     */
    protected abstract void MoveFollower();

    /*
     * Stop the follower's movement.
     */
    protected abstract void StopFollower();
}

