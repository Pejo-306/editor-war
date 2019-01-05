using UnityEngine;

public class ViMotionProjectileShooter : MonoBehaviour 
{
    public ViMotionProjectileWeapon weapon;

    private bool isShooting;

	void Start()
    {
		isShooting = false;
	}
	
	void Update()
    {
		if (!isShooting)
        {
            weapon.Shoot();
            Invoke("Cooldown", 1 / weapon.shotsPerSecond);
            isShooting = true;
        }
	}

    private void Cooldown()
    {
        isShooting = false;
    }
}
