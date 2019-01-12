using UnityEngine;

/*
 * Weapon component which allows an object to shoot projectiles.
 */
public class Weapon : MonoBehaviour
{
    private float nextShotTime = 0f;

    private Vector2 projectileDirection;

    // Projectile prefab to spawn.
    public GameObject projectilePrefab;

    // Projectiles' spawn position.
    public Transform spawnPosition;

    // Firing rate storage variable.
    public float firingRate = 10f;

    // Range for a random angle to add to the weapon's shooting direction.
    public float randomArcAngle = 0f;

    // If set, the weapon will shoot toward another game object.
    // Otherwise, the weapon shoots forward.
    [HideInInspector]
    public GameObject target;

    // Angle statically added to the weapon's shooting direction.
    // If target is set, this parameter has no effect.
    [HideInInspector]
    public float staticShootingAngle = 0f;

    /*
     * Calculate the projectiles' direction.
     *
     * If a target is set, the weapon aim's at said target. Otherwise, a static
     * shooting angle dictates the shooting direction of the weapon.
     * Furthermore, a random angle is added to the projectile's direction.
     */
    void FixedUpdate()
    {
        float rotZ;
        float randomRotZ = Random.Range(-(randomArcAngle / 2), randomArcAngle / 2);
        Vector2 directionDifference;

        if (target != null)  // Aim at the set target.
        {
            directionDifference = target.transform.position - spawnPosition.position;
            rotZ = Mathf.Atan2(directionDifference.y, directionDifference.x) * Mathf.Rad2Deg;
            rotZ -= 90;
        }
        else  // Shoot at a static angle.
        {
            rotZ = staticShootingAngle;
        }
        projectileDirection = Quaternion.Euler(0f, 0f, rotZ + randomRotZ) * spawnPosition.up;
    }

    /*
     * Shoot a new projectile.
     *
     * If some cooldown time has not passed since the last projectile's firing time,
     * a new projectile is not shot.
     */
    public virtual GameObject Shoot()
    {
        float cooldown = 1 / firingRate;
        GameObject projectile;

        if (Time.time > nextShotTime)
        {
            // Create a new projectile and sets its moving direction.
            projectile = Instantiate(projectilePrefab, spawnPosition.position, 
                    spawnPosition.rotation);
            projectile.GetComponent<Projectile>().direction = projectileDirection;
            // Ignore physics collisions with the shooter.
            Physics2D.IgnoreCollision(projectile.GetComponent<Collider2D>(),
                    GetComponent<Collider2D>());

            nextShotTime = Time.time + cooldown;
            return projectile;
        }
        return null;
    }
}

