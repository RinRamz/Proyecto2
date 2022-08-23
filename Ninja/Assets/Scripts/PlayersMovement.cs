using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersMovement : MonoBehaviour
{
    private float horizontal;
    public float speed = 8f;
    public float jumpingPower = 16f;
    private bool isFacingRight;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundcheck;
    [SerializeField] private LayerMask groundLayer;
    void Update()
    {
        //Asign the horizontal variable to the input value of the horizontal axis
        horizontal = Input.GetAxisRaw("Horizontal"); 

        Flip();

        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }
        
    }

    private void FixedUpdate()
    {
        //We multiply the input value from horizontal axis by a variable speed float, y velocity stays the same.
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        //OverlapCircle basically creates a circle that checks if it is colliding with anything, in the codeline we especify to filter to check objects on the ground layer
        return Physics2D.OverlapCircle(groundcheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal > 0 || !isFacingRight && horizontal < 0)
        {
            isFacingRight = !isFacingRight;
            Vector3 localscale = transform.localScale;
            localscale.x *= -1f;
            transform.localScale = localscale;
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpingPower);
    }

}

