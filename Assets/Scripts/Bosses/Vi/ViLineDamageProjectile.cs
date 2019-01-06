using UnityEngine;

public class ViLineDamageProjectile : MonoBehaviour
{
    public GameObject damageLinePrefab;
    public string tagToHit;
    public float minTriggerDelayTime = 0.5f;
    public float maxTriggerDelayTime = 1.5f;

    void Start()
    {
        float triggerDelayTime = Random.Range(minTriggerDelayTime, maxTriggerDelayTime);

        Invoke("SpawnDamageLine", triggerDelayTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(tagToHit))
        {
            SpawnDamageLine();
        }
    }

    private void SpawnDamageLine()
    {
        Destroy(gameObject);
        Instantiate(damageLinePrefab, transform.position, transform.rotation);
    }
}

