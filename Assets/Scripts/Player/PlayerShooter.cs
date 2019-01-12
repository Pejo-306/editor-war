using UnityEngine;

/*
 * Game logic that allows the player to shoot projectiles.
 */
public class PlayerShooter : MonoBehaviour
{
    public Weapon weapon;

    /*
     * Attemp to shoot a projectile every time the 'Fire' button is pressed.
     */
	void Update()
    {
	    if (Input.GetButton("Fire"))
        {
            weapon.Shoot();
        }
	}
}

