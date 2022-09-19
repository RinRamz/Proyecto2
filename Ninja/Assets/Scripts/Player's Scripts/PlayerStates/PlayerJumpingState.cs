using UnityEngine;

public class PlayerJumpingState : PlayerBaseState
{

    public PlayerJumpingState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory)
    : base ( currentContext, playerStateFactory) {}

    public override void EnterState()
    {
        _context.Animator.Play("Player_Jump");
        _context.Dust.Play();
        _context.Rigidbody2D.velocity = Vector2.up * _context.JumpingPower;
        _context.ExtraJumps--;
    }

    public override void UpdatetState()
    {
        CheckIfSwitchStates();
        _context.Move();
        _context.Flip();
        Jump();
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
    public void Jump()
    {
        if (Input.GetButtonDown("Jump") && _context.ExtraJumps > 0)
        {
            _context.Rigidbody2D.velocity = Vector2.up * _context.JumpingPower;
            _context.ExtraJumps--;
        }

        if (!Input.GetButton("Jump") && !_context.IsGrounded)
        {
            _context.Rigidbody2D.velocity += Vector2.down * _context.NegativeJumpingSpeed * Time.deltaTime;
        }
    }
}
