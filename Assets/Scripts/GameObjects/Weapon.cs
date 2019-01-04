using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float shotsPerSecond = 10f;
    public GameObject projectile;
    public Transform spawnPosition;
    public GameObject target;

    private float nextShotTime;
    private Vector2 projectileDirection = new Vector2(0, 1);

    void FixedUpdate()
    {
        float rotZ;

        if (target != null)
        {
            projectileDirection = target.transform.position - spawnPosition.position;
            rotZ = Mathf.Atan2(projectileDirection.y, projectileDirection.x) * Mathf.Rad2Deg;
            projectileDirection = Quaternion.Euler(0f, 0f, rotZ - 90) * transform.up;
        }
    }

    public void Shoot()
    {
        float cooldown = 1 / shotsPerSecond;
        GameObject newProjectile;

        if (Time.time > nextShotTime)
        {
            newProjectile = Instantiate(projectile, spawnPosition.position, 
                    spawnPosition.rotation);
            newProjectile.GetComponent<Projectile>().direction = projectileDirection;
            Physics2D.IgnoreCollision(newProjectile.GetComponent<Collider2D>(),
                    GetComponent<Collider2D>());
            nextShotTime = Time.time + cooldown;
        }
    }
}

