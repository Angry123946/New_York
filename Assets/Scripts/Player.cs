
using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    float movex;
    float movey;
    Vector2 move;
    Vector2 mousepos;
    [SerializeField] Camera cam;
    public int hp=10;


	private void Update()
    {
        
		void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.tag == "zombie")
			{
                StartCoroutine(wait());

                IEnumerator wait()
                {
					hp = hp - 2;
                    Debug.Log(hp);
					yield return new WaitForSeconds(2);
                }
			}
		}

		movex = Input.GetAxisRaw("Horizontal");
        movey = Input.GetAxisRaw("Vertical");
        move = new Vector2(movex, movey);
        mousepos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        rb.velocity= move * speed;
        Vector2 lookdir = mousepos-rb.position;
        float angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
