using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simple_Gun : MonoBehaviour
{
    public Transform firePoint;
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
    }
    private void Update()
    {
		if (Input.GetMouseButtonUp(0))
		{
			Shoot();
		}
        
        
        if(gun.bullets>=6)
        {
			if (Input.GetKeyUp(KeyCode.R))
			{
				gun.magazine = 6;
				gun.bullets = gun.bullets - 6;

			}
		}
        
	}

    IEnumerator Shooting()
    {
        
		GameObject bullett = Instantiate(bullet, firePoint.position, firePoint.rotation);
		Rigidbody2D rb = bullett.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * gun.force, ForceMode2D.Impulse);
		yield return new WaitForSeconds(gun.speed);

	}    
    void Shoot()
    {
        if(gun.magazine > 0)
        {
			StartCoroutine(Shooting());
		}
		
        gun.magazine--;
	}
}
