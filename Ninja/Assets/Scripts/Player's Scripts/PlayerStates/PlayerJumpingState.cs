using UnityEngine;

public class PlayerJumpingState : PlayerBaseState
{

    int extraJumps = 2;
    float horizontal;
    float speed = 6.6f;
    float negativeSpeed = 16f;
    float jumpingPower = 8f;
    bool isGrounded;

    public override void EnterState(PlayerStateManager player)
    {
        player.dust.Play();

        player.rb.velocity = Vector2.up * jumpingPower;
        extraJumps--;

        player.animator.Play("Player_Jump");

        horizontal = Input.GetAxisRaw("Horizontal");
        player.rb.velocity = new Vector2(horizontal * speed, player.rb.velocity.y);

        if (horizontal > 0 && player.isFacingRight) player.Flip();
        if (horizontal < 0 && !player.isFacingRight) player.Flip();
    }

    public override void UpdatetState(PlayerStateManager player)
    {
        isGrounded = Physics2D.OverlapCircle(player.groundcheck.position, 0.1f, player.groundLayer);

        horizontal = Input.GetAxisRaw("Horizontal");
        player.rb.velocity = new Vector2(horizontal * speed, player.rb.velocity.y);

        if (horizontal > 0 && player.isFacingRight) player.Flip();
        if (horizontal < 0 && !player.isFacingRight) player.Flip(); 

        if (Input.GetButtonDown("Jump") && extraJumps > 0)
        {
            player.rb.velocity = Vector2.up * jumpingPower;
            extraJumps--;
            horizontal = Input.GetAxisRaw("Horizontal");
            player.rb.velocity = new Vector2(horizontal * speed, player.rb.velocity.y);
        }
        
        if (!Input.GetButton("Jump") && !isGrounded)
        {
            player.rb.velocity += Vector2.down * negativeSpeed * Time.deltaTime;
        }
        
        if (isGrounded && player.rb.velocity.y == 0)
        {
            extraJumps = 2;
            player.ChangeState(player.landState);
        }

    }
}