using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

[System.Serializable]
public class Gun : MonoBehaviour
{
    public string name;
    public int magazine;
    public int speed;
    public int maxbullet;
    public int force;
    public int bullets;
	Transform firePoint;
	public GameObject bullet;
    


    private void Awake()
    {
        firePoint.Find("Bullet/FirePoint");
        
    }
    public void Shoot()
    {
		if (magazine > 0)
		{
			StartCoroutine(Shooting());
		}
		magazine--;
	}

    public IEnumerator Shooting()
    {

		GameObject bullett = Instantiate(bullet, firePoint.position, firePoint.rotation);
		Rigidbody2D rb = bullett.GetComponent<Rigidbody2D>();
		rb.AddForce(firePoint.up * force, ForceMode2D.Impulse);
		yield return new WaitForSeconds(speed);
	}
    
}
