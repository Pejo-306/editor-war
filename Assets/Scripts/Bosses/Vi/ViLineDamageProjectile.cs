using UnityEngine;

public class ViLineDamageProjectile : MonoBehaviour
{
    public GameObject damageLinePrefab;
    public string tagToHit;
    public float minTriggerDelayTime = 0.5f;
    public float maxTriggerDelayTime = 1.5f;
    public Animator animator;
    public float preDestructionVFXDuration = 0.5f;

    void Start()
    {
        float triggerDelayTime = Random.Range(minTriggerDelayTime, maxTriggerDelayTime);

        Invoke("StartPreDestructionVFX", triggerDelayTime - preDestructionVFXDuration);
        Invoke("SpawnDamageLine", triggerDelayTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(tagToHit))
        {
            SpawnDamageLine();
        }
    }

    private void StartPreDestructionVFX()
    {
        animator.SetTrigger("StartExplosion");
    }

    private void SpawnDamageLine()
    {
        Destroy(gameObject);
        Instantiate(damageLinePrefab, transform.position, transform.rotation);
    }
}

