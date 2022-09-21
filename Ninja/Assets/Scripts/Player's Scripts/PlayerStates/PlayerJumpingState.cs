using UnityEngine;

public class PlayerJumpingState : PlayerBaseState
{

    public PlayerJumpingState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory)
    : base ( currentContext, playerStateFactory) {}

    public override void EnterState()
    {
        _context.Animator.Play("Player_Jump");
        _context.Dust.Play();
        _context.Jump();
    }

    public override void UpdatetState()
    {
        CheckIfSwitchStates();
        if (_context.InputManager.IsJumpPressed() && _context.ExtraJumps > 0)
        {
            _context.Jump();
        }
        
        /*
        if (!_context.InputManager.IsJumpHold() && !_context.IsGrounded)
        {
            _context.Rigidbody2D.velocity += Vector2.down * _context.NegativeJumpingSpeed * Time.deltaTime;
        }
         */
         
        
        _context.Move();
        _context.Flip();
    }
    public override void ExitState()
    {
        _context.ExtraJumps = 2;
    }
    public override void CheckIfSwitchStates()
    {
        if (_context.IsGrounded && _context.Rigidbody2D.velocity.y == 0)
        {
            SwitchState(_playerStateFactory.Landing());
        }
    }

}
