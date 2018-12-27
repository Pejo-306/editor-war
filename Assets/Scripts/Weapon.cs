using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int shotsPerSecond = 10;
    public GameObject projectile;
    public Transform spawnPosition;
    private float nextShotTime;

    public void Shoot()
    {
        float cooldown = 1 / (float)shotsPerSecond;

        if (Time.time > nextShotTime)
        {
            var newProjectile = Instantiate(projectile, spawnPosition.position, 
                    spawnPosition.rotation);
            Physics2D.IgnoreCollision(newProjectile.GetComponent<Collider2D>(),
                    GetComponent<Collider2D>());
            nextShotTime = Time.time + cooldown;
        }
    }
}

