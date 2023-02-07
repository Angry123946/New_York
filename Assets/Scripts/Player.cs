
using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private LayerMask enemy;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;

    private Vector2 move;
    private int invisibilityFrames = 0;

    public int hp;


    private void Update()
    {
        move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void FixedUpdate()
    {
        //Rotation
        RotatePlayer();

        //Movement
        rb.velocity = move * speed;

        CollisionWithEnemyCheck();
    }

    private void RotatePlayer()
    {
        Vector2 lookdir = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - rb.position;
        float angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    private void CollisionWithEnemyCheck()
    {
        if ((GetComponent<BoxCollider2D>().IsTouchingLayers(enemy) == true) && (invisibilityFrames == 0))
        {
            hp = hp - 2;
            invisibilityFrames = 100;
        }

        if (invisibilityFrames > 0) invisibilityFrames--;
    }
}
