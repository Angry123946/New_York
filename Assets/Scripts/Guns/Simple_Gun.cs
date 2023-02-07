using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simple_Gun : MonoBehaviour
{
    
    public GameObject bullet;
    Gun gun = new Gun();

    private void Start()
    {
        gun.name = "Pistol";
        gun.magazine = 6;
        gun.maxbullet = 155;
        gun.speed = 1;
        gun.force = 10;
        gun.bullets = 30;
        bullet = gun.bullet;
        
    }

    private void FixedUpdate()
    {
		if (Input.GetMouseButtonUp(0))
		{
			gun.Shoot();
		}
        
        
        if(Input.GetKey(KeyCode.R))
        {
            Reload();
        }
        
	}

   
    void Reload()
    {

		if (gun.bullets > 6)
		{
			gun.magazine = 6;
			gun.bullets = gun.bullets - 6;
		}
		else
		{
			gun.magazine = gun.bullets;
			gun.bullets = 0;
		}

	}
}
