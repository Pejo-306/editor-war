using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public Weapon weapon;

	void Update()
    {
	    if (Input.GetButton("Fire"))
        {
            weapon.Shoot();
        }
	}
}

