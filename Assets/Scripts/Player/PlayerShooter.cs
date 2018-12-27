using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    private Weapon weapon;

	void Start()
    {
        weapon = GetComponent<Weapon>();	
	}
	
	void Update()
    {
	    if (Input.GetButton("Fire"))
        {
            weapon.Shoot();
        }
	}
}

