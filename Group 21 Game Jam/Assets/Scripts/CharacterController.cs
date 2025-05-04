using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float jumpForce = 5.0f;
    public float speed = 3.0f;
    private float moveDirection;

    private bool jump;
    private bool grounded = true;

    private Rigidbody2D rigidBody2D;
    private SpriteRenderer spriteRenderer;
    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        // Hareket
        rigidBody2D.velocity = new Vector2(speed * moveDirection, rigidBody2D.velocity.y);

        // Zýplama
        if (jump)
        {
            rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, jumpForce);
            jump = false;
        }
    }

    private void Update()
    {
        // Yalnýzca yerdeyken yön deðiþtirme
        if (grounded)
        {
            if (Input.GetKey(KeyCode.A))
            {
                moveDirection = -1.0f;
                spriteRenderer.flipX = true;
                anim.SetFloat("speed", speed);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                moveDirection = 1.0f;
                spriteRenderer.flipX = false;
                anim.SetFloat("speed", speed);
            }
            else
            {
                moveDirection = 0.0f;
                anim.SetFloat("speed", 0.0f);
            }
        }

        // Zýplama kontrolü
        if (grounded && Input.GetKeyDown(KeyCode.W))
        {
            jump = true;
            grounded = false;

            anim.SetTrigger("jump");
            anim.SetBool("grounded", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Zemin"))
        {
            grounded = true;
            anim.SetBool("grounded", true);
        }
    }
}
