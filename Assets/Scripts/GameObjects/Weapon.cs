using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float shotsPerSecond = 10f;
    public GameObject shooter;
    public GameObject projectilePrefab;
    public Transform spawnPosition;
    public GameObject target;

    private float nextShotTime = 0f;
    private Vector2 projectileDirection = new Vector2(0, 1);

    void FixedUpdate()
    {
        float rotZ;

        if (target != null)
        {
            projectileDirection = target.transform.position - spawnPosition.position;
            rotZ = Mathf.Atan2(projectileDirection.y, projectileDirection.x) * Mathf.Rad2Deg;
            projectileDirection = Quaternion.Euler(0f, 0f, rotZ - 90) * spawnPosition.up;
        }
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

