using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float shotsPerSecond = 10f;
    public GameObject projectile;
    public Transform spawnPosition;
    public GameObject target;

    private float nextShotTime;

    void FixedUpdate()
    {
        float rotZ;
        Vector3 direction;

        if (target != null)
        {
            direction = target.transform.position - spawnPosition.position;
            rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            spawnPosition.rotation = Quaternion.Euler(0f, 0f, rotZ - 90);
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
            Physics2D.IgnoreCollision(newProjectile.GetComponent<Collider2D>(),
                    GetComponent<Collider2D>());
            nextShotTime = Time.time + cooldown;
        }
    }
}

