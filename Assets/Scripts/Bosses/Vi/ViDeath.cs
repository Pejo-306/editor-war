using UnityEngine;

public class ViDeath : MonoBehaviour
{
    public GameObject[] deathParticles;
    public float delayAfterDeath = 3f;
    public float particlesPerSecond = 6;
    public MonoBehaviour[] bossComponents;
    public GameObject[] bossWeaponObjects;

    private BoxCollider2D viBoxCollider;
    private bool isPlayingAnimation = false;
    private bool canSpawnParticle = true;
    private float particleDelay;

    void Start()
    {
        viBoxCollider = GetComponent<BoxCollider2D>();
        particleDelay = 1 / particlesPerSecond;
    }

    void Update()
    {
        if (isPlayingAnimation && canSpawnParticle)
        {
            foreach (var deathParticle in deathParticles)
            {
                Instantiate(deathParticle, PickRandomSpawnPoint(), transform.rotation);
            }
            Invoke("AllowParticleSpawn", particleDelay);
            canSpawnParticle = false;
        }
    }

    public void PlayDeathAnimation()
    {
        if (!isPlayingAnimation)
        {
            PersistantGameManager.Instance.Invoke("GameWin", delayAfterDeath);
            isPlayingAnimation = true;
            foreach (var component in bossComponents)
            {
                component.enabled = false;
            }
            foreach (var weaponObject in bossWeaponObjects)
            {
                weaponObject.SetActive(false);
            }
        }
    }

    private void AllowParticleSpawn()
    {
        canSpawnParticle = true;
    }

    private Vector3 PickRandomSpawnPoint()
    {
        float halfWidth = viBoxCollider.size.x / 2;
        float halfHeight = viBoxCollider.size.y / 2;
        float horizontalOffset = Random.Range(-halfWidth, halfWidth);
        float verticalOffset = Random.Range(-halfHeight, halfHeight);
        Vector3 offset = new Vector3(horizontalOffset, verticalOffset, 0);

        return transform.position + offset; 
    }
}

