namespace Ninja
{
    public class PlayerIdleState : PlayerBaseState
    {
        public PlayerIdleState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory)
        : base(currentContext, playerStateFactory) { }

        public override void EnterState()
        {
            _context.Animator.Play("Player_Iddle");
            _context.AudioSource.Pause();
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
            else if (_context.IsDenfencePressed)
            {
                SwitchState(_playerStateFactory.Defending());
            }

            if (_context.IsDamaged)
            {
                SwitchState(_playerStateFactory.Damaged());
            }
        }
    }
}
