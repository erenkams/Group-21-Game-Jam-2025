using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float jumpForce = 5.0f;
    public float speed = 3.0f;
    private float moveDirection;

    private bool jump;
    private bool grounded;

    private Rigidbody2D rigidBody2D;
    private SpriteRenderer spriteRenderer;
    private Animator anim;

    [SerializeField] private Transform groundCheck;     // Ayak noktasý
    [SerializeField] private float groundCheckDistance = 0.1f;
    [SerializeField] private LayerMask groundLayer;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Raycast ile yere temas kontrolü
        grounded = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, groundLayer);
        anim.SetBool("grounded", grounded);

        // Hareket sadece yerdeyken
        if (grounded)
        {
            if (Input.GetKey(KeyCode.A))
            {
                moveDirection = -1f;
                spriteRenderer.flipX = true;
                anim.SetFloat("speed", speed);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                moveDirection = 1f;
                spriteRenderer.flipX = false;
                anim.SetFloat("speed", speed);
            }
            else
            {
                moveDirection = 0f;
                anim.SetFloat("speed", 0f);
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                jump = true;
                anim.SetTrigger("jump");
            }
        }
    }

    void FixedUpdate()
    {
        // Yatay hareket
        rigidBody2D.velocity = new Vector2(speed * moveDirection, rigidBody2D.velocity.y);

        // Zýplama
        if (jump)
        {
            rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, jumpForce);
            jump = false;
        }
    }

    void OnDrawGizmosSelected()
    {
        // Raycast'ý sahnede göstermek için
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(groundCheck.position, groundCheck.position + Vector3.down * groundCheckDistance);
        }
    }
}
