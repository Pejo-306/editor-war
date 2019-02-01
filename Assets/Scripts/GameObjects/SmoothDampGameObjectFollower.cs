using System;
using UnityEngine;

/*
 * Follow another game object by smoothly sliding towards it.
 *
 * This follower implementation adds a stop zone. When the follower reaches
 * the zone's border, the former stops following its target object.
 */
public class SmoothDampGameObjectFollower : GameObjectFollower
{
    // The following speed.
    public float followSpeed = 1f;

    // Range of stop zone. Follower stops following its target when within
    // 1/2 of this range.
    public float stopZoneRange = 0.1f;

    // Velocity of follower. This should not be set mannually.
    private Vector2 velocity = Vector2.zero;
    
    /*
     * Smoothly slither towards the target object.
     */
    protected override void MoveFollower()
    {
        float distanceToTarget;
        Vector2 targetPosition;

        distanceToTarget = targetObject.transform.position.x - transform.position.x;
        if (Math.Abs(distanceToTarget) > stopZoneRange / 2)
        {
            // Follow target if outside of stop zone.
            targetPosition.x = direction.x * Math.Abs(targetObject.transform.position.x);
        }
        else
        {
            // Stop following target on this axis.
            targetPosition.x = transform.position.x;
            StopFollower();
        }
        distanceToTarget = targetObject.transform.position.y - transform.position.y;
        if (Math.Abs(distanceToTarget) > stopZoneRange / 2)
        {
            // Follow target if outside of stop zone.
            targetPosition.y = direction.y * Math.Abs(targetObject.transform.position.y);
        }
        else
        {
            // Stop following target on this axis.
            targetPosition.y = transform.position.y;
            StopFollower();
        }
        transform.position = Vector2.SmoothDamp(transform.position, targetPosition, 
                ref velocity, 1 / followSpeed);
    }

    /*
     * Stop following target by nullifying follower's velocity.
     */
    protected override void StopFollower()
    {
        velocity = Vector2.zero;
    }
}

