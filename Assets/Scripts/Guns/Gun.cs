using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;


public class Gun : MonoBehaviour
{
	public string name;
    public int magazine;
    public int speed;
    public int maxbullet;
    public int force;
    public int bullets;
	public Transform firePoint;
	public GameObject bullet;
	private float lastShootTime;
	

	public void Shoot()
    {

		float shootDelay = 1.0f / speed;
		float nextShootTime = lastShootTime + shootDelay;
		float timeNow = Time.time;

		if (nextShootTime > timeNow)
		{
			return; 
		}

		
		lastShootTime = timeNow;
		if (magazine <= 0)
		{
			return;
		}
		magazine--;
		

		GameObject bullett = Instantiate(bullet, firePoint.position, firePoint.rotation);
		Rigidbody2D rb = bullett.GetComponent<Rigidbody2D>();
		rb.AddForce(firePoint.up * force, ForceMode2D.Impulse);
	}
}
    

