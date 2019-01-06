using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float shotsPerSecond = 10f;
    public GameObject shooter;
    public GameObject projectilePrefab;
    public Transform spawnPosition;
    public GameObject target;
    public float staticShootingAngle = 0f;
    public float randomArcAngle = 0f;

    private float nextShotTime = 0f;
    private Vector2 projectileDirection;

    void FixedUpdate()
    {
        float rotZ;
        float randomRotZ = Random.Range(-(randomArcAngle / 2), randomArcAngle / 2);
        Vector2 directionDifference;

        if (target != null)
        {
            directionDifference = target.transform.position - spawnPosition.position;
            rotZ = Mathf.Atan2(directionDifference.y, directionDifference.x) * Mathf.Rad2Deg;
            rotZ -= 90;
        }
        else
        {
            rotZ = staticShootingAngle;
        }
        projectileDirection = Quaternion.Euler(0f, 0f, rotZ + randomRotZ) * spawnPosition.up;
    }

    public virtual GameObject Shoot()
    {
        float cooldown = 1 / shotsPerSecond;
        GameObject projectile;

        if (Time.time > nextShotTime)
        {
            projectile = Instantiate(projectilePrefab, spawnPosition.position, 
                    spawnPosition.rotation);
            projectile.GetComponent<Projectile>().direction = projectileDirection;

            Physics2D.IgnoreCollision(projectile.GetComponent<Collider2D>(),
                    shooter.GetComponent<Collider2D>());
            nextShotTime = Time.time + cooldown;
            return projectile;
        }
        return null;
    }
}

