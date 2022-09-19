using Microsoft.Win32.SafeHandles;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerMovingState : PlayerBaseState
{
    public PlayerMovingState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory)
    : base (currentContext, playerStateFactory) {}

public override void EnterState()
    {
        _context.Animator.Play("Player_Run");
        _context.Flip();
        _context.Move();
    }

    public override void UpdatetState()
    {
        CheckIfSwitchStates();
        _context.Flip();
        _context.Move();
    }
    public override void ExitState()
    {
    }
    public override void CheckIfSwitchStates()
    {
        if (_context.HorizontalInput == 0f)
        {
            SwitchState(_playerStateFactory.Idle());
        }

        if (Input.GetButtonDown("Jump"))
        {
            SwitchState(_playerStateFactory.Jump());
        }

        if (Input.GetButtonDown("Fire1"))
        {
            SwitchState(_playerStateFactory.Attacking());
        }
    }
}
