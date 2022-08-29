using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersMovement : MonoBehaviour
{
    private float horizontal;
    private bool isFacingRight;
    private bool isGrounded;
    private int extraJumps;

    public float jumpingPower;
    public float speed;
    public int extraJumpsValue;

    [SerializeField] private Animator animator;
    [SerializeField] private ParticleSystem dust;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundcheck;
    [SerializeField] private LayerMask groundLayer;

    private void Start()
    {
        extraJumps = extraJumpsValue;
    }
    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        Jump();

        if(isGrounded)
        {
            Instantiate(dust, groundcheck);
        }
    }

    private void FixedUpdate()
    {
        //Asign the horizontal variable to the input value of the horizontal axis
        horizontal = Input.GetAxisRaw("Horizontal");

        //OverlapCircle basically creates a circle that checks if it is colliding with anything, in the codeline we especify to filter to check objects on the ground layer
        isGrounded = Physics2D.OverlapCircle(groundcheck.position, 0.1f, groundLayer);

        //We multiply the input value from horizontal axis by a variable speed float, y velocity stays the same.
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        Flip();

        if (isGrounded && rb.velocity.y == 0)
        {
            extraJumps = extraJumpsValue;
            animator.SetBool("isJumping", false);
        }
    }
    private void Flip()
    {
        if (isFacingRight && horizontal > 0f || !isFacingRight && horizontal < 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localscale = transform.localScale;
            localscale.x *= -1;
            transform.localScale = localscale;
            if (isGrounded)
            {
                dust.Play();
            }
        }
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpingPower;
            animator.SetBool("isJumping", true);
            extraJumps--;
            dust.Play();
        }
        else if (Input.GetButtonDown("Jump") && extraJumps == 0)
        {
            rb.velocity = Vector2.up * jumpingPower;
            extraJumps--;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(isGrounded && rb.velocity.y == 0 && extraJumps < extraJumpsValue)
        {
            dust.Play();
        }
    }
}

