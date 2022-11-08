namespace Ninja
{
    public class PlayerDamagedState : PlayerBaseState
    {
        public PlayerDamagedState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory)
        : base(currentContext, playerStateFactory) { }

        public override void EnterState()
        {
            _context.Animator.Play("Player_Damaged");
            
            if (_context.Hp <= 0)
            {
                _context.Die();
            }
        }

        public override void UpdatetState()
        {
            CheckIfSwitchStates();
            _context.Animator.Play("Player_Damaged");
        }

        public override void ExitState()
        {
        }
        
        public override void CheckIfSwitchStates()
        {
            if (!_context.IsDamaged)
            {
                SwitchState(_playerStateFactory.Idle());
            }
            else if (_context.IsAttackPressed && _context.CanAttackAgain)
            {
                SwitchState(_playerStateFactory.Attacking());
            }
            else if (_context.IsDenfencePressed)
            {
                SwitchState(_playerStateFactory.Defending());
            }
        }
    }
}
