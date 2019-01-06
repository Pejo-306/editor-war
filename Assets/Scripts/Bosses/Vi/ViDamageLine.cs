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
        float colliderCoefficient = GetComponent<BoxCollider2D>().size.y;
        float height = MethodStatics.GetScreenHeight() / colliderCoefficient;
        Vector2 centeredPosition = Vector2.zero;

        centeredPosition.x = transform.position.x;
        transform.position = centeredPosition;
        transform.localScale = new Vector2(transform.localScale.x, height);
    }
}

