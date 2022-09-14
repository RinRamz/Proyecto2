using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerAttackingState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        player.animator.Play("Player_Attack");
        player.isAttacking = true;
    }

    public override void UpdatetState(PlayerStateManager player)
    {
        if (Input.GetButtonDown("Fire1"))
        {
            player.animator.Play("Player_Attack2");
        }
        
        if (!player.isAttacking)
        {
            player.ChangeState(player.iddleState);
        }
    }

   
}
