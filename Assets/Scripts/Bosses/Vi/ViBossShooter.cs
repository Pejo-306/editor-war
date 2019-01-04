using UnityEngine;

public class ViBossShooter : MonoBehaviour
{
    private Weapon weapon;
    private bool isShooting;

	void Start()
    {
		weapon = GetComponent<Weapon>();
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

