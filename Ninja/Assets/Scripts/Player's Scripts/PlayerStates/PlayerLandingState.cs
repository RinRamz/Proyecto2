using UnityEngine;

public class PlayerLandingState : PlayerBaseState
{
    public PlayerLandingState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory)
    : base ( currentContext, playerStateFactory) {}


    public override void EnterState()
    {
        _context.Dust.Play();
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
        if (_context.HorizontalInput.x == 0f)
        {
            SwitchState(_playerStateFactory.Idle());
        }
        else if (_context.HorizontalInput.x < 0 || _context.HorizontalInput.x > 0)
        {
            SwitchState(_playerStateFactory.Moving());
        }
    }
}
