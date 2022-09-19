using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerAttackingState : PlayerBaseState
{
    public PlayerAttackingState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory)
    : base ( currentContext, playerStateFactory) {}

    public override void EnterState()
    {
        _context.Animator.Play("Player_Attack");
        _context.IsAttacking = true;
    }

    public override void UpdatetState()
    {
        CheckIfSwitchStates();
        if (Input.GetButtonDown("Fire1"))
        {
            _context.Animator.Play("Player_Attack2");
        }
    }
    public override void ExitState()
    {
    }
    public override void CheckIfSwitchStates()
    {
        if (!_context.IsAttacking)
        {
            SwitchState(_playerStateFactory.Idle());
        }
    }

}
