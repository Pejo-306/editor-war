using UnityEngine;
using UnityEngine.UI;

public class UIFollowObject : MonoBehaviour
{
    public GameObject followedObject;
    public RectTransform movingObject;
    public Vector3 worldOffset;

    void Update()
    {
        MoveUIObject();
    }

    private void MoveUIObject()
    {
        Vector3 worldPosition = followedObject.transform.position + worldOffset;

        movingObject.position = Camera.main.WorldToScreenPoint(worldPosition);
    }
}

