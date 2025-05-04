using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybehavior : MonoBehaviour
{
    public float speed = 2.0f;
    public Transform pointA;
    public Transform pointB;

    private Vector3 targetPosition;
    private SpriteRenderer spriteRenderer;
    private Animator anim;
    private bool grounded = true;

    void Start()
    {
        targetPosition = pointB.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Hedefe do�ru hareket
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Hedefe ula�t�ysa y�n de�i�tir
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            if (targetPosition == pointA.position)
                targetPosition = pointB.position;
            else
                targetPosition = pointA.position;

            spriteRenderer.flipX = !spriteRenderer.flipX; // Y�n de�i�tirirken sprite'� �evir
        }
    }
    
}
