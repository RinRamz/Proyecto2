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
        if (_context.HorizontalInput < 0 || _context.HorizontalInput > 0)
        {
            SwitchState(_playerStateFactory.Moving());
        }
        else if (Input.GetButtonDown("Jump"))
        {
            SwitchState(_playerStateFactory.Jump());
        }
        else if (Input.GetButtonDown("Fire1"))
        {
            SwitchState(_playerStateFactory.Attacking());
        }
    }
}
