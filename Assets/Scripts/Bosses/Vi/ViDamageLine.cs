using UnityEngine;

public class ViDamageLine : MonoBehaviour
{
    public float destructionDelayTime = 1f;

	void Awake()
    {
        CenterAndScaleDamageLine();
        Destroy(gameObject, destructionDelayTime);
	}

    private void CenterAndScaleDamageLine()
    {
        float colliderCoefficient = GetComponent<BoxCollider2D>().size.x;
        float width = MethodStatics.GetScreenWidth() / colliderCoefficient;
        Vector2 centeredPosition = Vector2.zero;

        centeredPosition.y = transform.position.y;
        transform.position = centeredPosition;
        transform.localScale = new Vector2(width, transform.localScale.y);
    }
}

