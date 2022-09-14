using Microsoft.Win32.SafeHandles;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerMovingState : PlayerBaseState
{
    float horizontal;
    float speed = 8;
    public override void EnterState(PlayerStateManager player)
    {
        player.animator.Play("Player_Run");
        
        if (horizontal > 0 && player.isFacingRight) player.Flip();
        if (horizontal < 0 && !player.isFacingRight) player.Flip();
    }

    public override void UpdatetState(PlayerStateManager player)
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        player.rb.velocity = new Vector2(horizontal * speed, player.rb.velocity.y);

        if (horizontal > 0 && player.isFacingRight) player.Flip();
        if (horizontal < 0 && !player.isFacingRight) player.Flip();

        if (horizontal == 0f)
        {
            player.ChangeState(player.iddleState);
        }

        if (Input.GetButtonDown("Jump"))
        {
            player.ChangeState(player.jumpState);
        }
    }

}
