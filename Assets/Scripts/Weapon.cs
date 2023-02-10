using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    public float force=20f;

    private void Update()
    {      
        if (Input.GetMouseButtonUp(0))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        GameObject bullett = Instantiate(bullet, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullett.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * force, ForceMode2D.Impulse);
    }
}
