using UnityEngine;

public class PlayerIddleState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        player.animator.Play("Player_Iddle");
    }

    public override void UpdatetState(PlayerStateManager player)
    {
        if (Input.GetAxisRaw("Horizontal") > 0 || Input.GetAxisRaw("Horizontal") < 0)
        {
            player.ChangeState(player.movingState);
        }
        else if (Input.GetButtonDown("Jump"))
        {
            player.ChangeState(player.jumpState);
        }
        else if (Input.GetButtonDown("Fire1"))
        {
            player.ChangeState(player.attackingState);
        }
    }
}
