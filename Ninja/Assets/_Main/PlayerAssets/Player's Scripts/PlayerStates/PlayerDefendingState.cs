namespace Ninja
{
    public class PlayerDefendingState : PlayerBaseState
    {
        public PlayerDefendingState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory)
        : base(currentContext, playerStateFactory) { }

        public override void EnterState()
        {
            _context.Animator.Play("Player_Defense");
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
            if (!_context.IsDenfencePressed)
            {
                SwitchState(_playerStateFactory.Idle());
            }
        }
    }
}
