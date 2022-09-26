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
        if (_context.HorizontalInput.x == 0f)
        {
            SwitchState(_playerStateFactory.Idle());
        }

        if (_context.InputManager.IsJumpPressed())
        {
            SwitchState(_playerStateFactory.Jump());
        }
    }
}
