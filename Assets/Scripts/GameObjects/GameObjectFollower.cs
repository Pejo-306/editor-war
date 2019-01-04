using UnityEngine;

public class GameObjectFollower : MonoBehaviour
{
    public GameObject objectToFollow;
    public bool followXAxis = false;
    public bool followYAxis = false;

    private bool isFollowing = true;
    private Vector2 followDirection = new Vector2(0, 0);

    void FixedUpdate()
    {
        if (isFollowing)
        {
            if (followXAxis)
            {
                if (objectToFollow.transform.position.x - transform.position.x > 0)
                {
                    followDirection.x = 1;
                }
                else if (objectToFollow.transform.position.x - transform.position.x < 0)
                {
                    followDirection.x = -1;
                }
                else
                {
                    followDirection.x = 0;
                }
            }
            if (followYAxis)
            {
                if (objectToFollow.transform.position.y - transform.position.y > 0)
                {
                    followDirection.y = 1;
                }
                else if (objectToFollow.transform.position.y - transform.position.y < 0)
                {
                    followDirection.y = -1;
                }
                else
                {
                    followDirection.y = 0;
                }
            }

            BroadcastMessage("MoveObjectFollowerInDirection", followDirection);
        }
        else
        {
            BroadcastMessage("StopObjectFollowerMovement");
        }
    }

    public void ContinueFollowing()
    {
        isFollowing = true;
    }

    public void StopFollowing()
    {
        isFollowing = false;
    }
}

