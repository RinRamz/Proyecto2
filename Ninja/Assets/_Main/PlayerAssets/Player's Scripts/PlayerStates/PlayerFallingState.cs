using UnityEngine;

namespace Ninja
{
    public class PlayerFallingState : PlayerBaseState
    {
        public PlayerFallingState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory)
        : base(currentContext, playerStateFactory) { }

        public override void EnterState()
        {
            _context.Animator.Play("Player_Fall");
        }

        public override void UpdatetState()
        {
            CheckIfSwitchStates();
            _context.Move();
            _context.Flip();
        }
        
        public override void ExitState()
        {
        }
        
        public override void CheckIfSwitchStates()
        {
            if (_context.IsGrounded)
            {
                SwitchState(_playerStateFactory.Landing());
            }

            if (_context.IsDamaged)
            {
                SwitchState(_playerStateFactory.Damaged());
            }
        }
    }
}
