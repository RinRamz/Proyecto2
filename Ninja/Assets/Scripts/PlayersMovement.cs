using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersMovement : MonoBehaviour
{
    private float horizontal;
    public float jumpingPower = 16f;
    public float speed;
    public int jumpCount = 0;

    public Animator animator;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundcheck;
    [SerializeField] private LayerMask groundLayer;
    void Update()
    {
        //Asign the horizontal variable to the input value of the horizontal axis
        horizontal = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(horizontal));


        if (Input.GetButtonDown("Jump") && IsGrounded() || Input.GetButtonDown("Jump") && !IsGrounded() && jumpCount < 1)
        {
            Jump();
            return;
        }

        if (IsGrounded())
        {
            jumpCount = 0;
        }




    }

    private void FixedUpdate()
    {
        //We multiply the input value from horizontal axis by a variable speed float, y velocity stays the same.
        if (IsGrounded())
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(horizontal * 4f, rb.velocity.y);
        }
    }

    private bool IsGrounded()
    {
        //OverlapCircle basically creates a circle that checks if it is colliding with anything, in the codeline we especify to filter to check objects on the ground layer
        return Physics2D.OverlapCircle(groundcheck.position, 0.2f, groundLayer);
    }

    private void Jump()
    {
        jumpCount++;
        rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
    }

}

