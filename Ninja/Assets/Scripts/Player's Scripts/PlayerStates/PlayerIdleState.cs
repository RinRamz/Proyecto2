using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public PlayerIdleState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory)
    : base(currentContext, playerStateFactory) { }

    public override void EnterState()
    {
        _context.Animator.Play("Player_Iddle");
    }

    public override void UpdatetState()
    {
        CheckIfSwitchStates();
    }
    public override void ExitState()
    {
    }
    public override void CheckIfSwitchStates()
    {
        if (_context.HorizontalInput.x < 0 || _context.HorizontalInput.x > 0)
        {
            SwitchState(_playerStateFactory.Moving());
        }
        else if (_context.InputManager.IsJumpPressed())
        {
            SwitchState(_playerStateFactory.Jump());
        }
        else if (_context.InputManager.IsAttackPressed())
        {
            SwitchState(_playerStateFactory.Attacking());
        }
    }
}
