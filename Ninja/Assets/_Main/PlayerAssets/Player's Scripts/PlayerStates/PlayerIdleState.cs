namespace Ninja
{
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
            if (_context.Input < 0 || _context.Input > 0)
            {
                SwitchState(_playerStateFactory.Moving());
            }
            else if (_context.IsJumpPressed)
            {
                SwitchState(_playerStateFactory.Jump());
            }
            else if (_context.IsAttackPressed && _context.CanAttackAgain)
            {
                SwitchState(_playerStateFactory.Attacking());
            }
        }
    }
}
