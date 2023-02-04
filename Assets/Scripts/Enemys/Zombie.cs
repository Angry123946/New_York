using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Zombie : MonoBehaviour
{
	public Transform player;
	Enemy zombie = new Enemy();

    private void Start()
    {
		player.Find("Player");
        zombie.name = "Zombie";
        zombie.health = 10;
        zombie.id = 0;
        zombie.speed = 2;
    }
    private void Update()
    {
		if (zombie.health <= 0)
		{
			Debug.Log("I m die");
			Destroy(gameObject);
		}

		Vector3 direction = player.position - transform.position;
		direction = direction.normalized;
		transform.position += direction * zombie.speed * Time.deltaTime;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "bullet")
		{
			zombie.Whyushootme(4);
		}
	}

}
