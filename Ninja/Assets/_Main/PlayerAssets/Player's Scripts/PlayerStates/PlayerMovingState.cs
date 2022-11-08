namespace Ninja
{
    public class PlayerMovingState : PlayerBaseState
    {
        public PlayerMovingState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory)
        : base(currentContext, playerStateFactory) { }

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
            if (_context.Input == 0f)
            {
                SwitchState(_playerStateFactory.Idle());
            }

            if (_context.IsJumpPressed)
            {
                SwitchState(_playerStateFactory.Jump());
            }

            if (_context.IsDamaged)
            {
                SwitchState(_playerStateFactory.Damaged());
            }
        }
    }
}
