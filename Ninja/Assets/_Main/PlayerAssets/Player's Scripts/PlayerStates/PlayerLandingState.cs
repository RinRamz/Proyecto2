namespace Ninja
{
    public class PlayerLandingState : PlayerBaseState
    {
        public PlayerLandingState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory)
        : base(currentContext, playerStateFactory) { }

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
            if (_context.Input == 0f)
            {
                SwitchState(_playerStateFactory.Idle());
            }
            else if (_context.Input < 0 || _context.Input > 0)
            {
                SwitchState(_playerStateFactory.Moving());
            }
        }
    }
}
