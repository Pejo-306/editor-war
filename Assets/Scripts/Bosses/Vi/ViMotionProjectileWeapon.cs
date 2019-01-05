using UnityEngine;

public class ViMotionProjectileWeapon : Weapon
{
    public int minCount = 1;
    public int maxCount = 3;
    public float motionUnit = 0.5f;

    public override GameObject Shoot()
    {
        GameObject projectile = base.Shoot();

        if (projectile != null)
        {
            projectile.GetComponent<ViMotionProjectile>().InstantiateMovement(
                    minCount, maxCount, motionUnit);
        }
        return projectile;
    }
}

