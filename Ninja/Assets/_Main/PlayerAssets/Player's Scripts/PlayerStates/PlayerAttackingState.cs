namespace Ninja
{
    public class PlayerAttackingState : PlayerBaseState
    {
        public PlayerAttackingState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory)
        : base(currentContext, playerStateFactory) { }

        public override void EnterState()
        {
            _context.StartCoroutine(_context.AttackTimer());
            _context.Animator.Play("Player_Attack");
            _context.IsAttacking = true;
            _context.IsInFirstAttack = true;
        }

        public override void UpdatetState()
        {
            CheckIfSwitchStates();
            if (_context.IsAttackPressed && !_context.IsInFirstAttack)
            {
                _context.Animator.Play("Player_Attack2");
                _context.IsInSecondAttack = true;
            }
        }

        public override void ExitState()
        {
        }

        public override void CheckIfSwitchStates()
        {
            if (!_context.IsAttacking)
            {
                SwitchState(_playerStateFactory.Idle());
            }

            if (_context.IsDamaged)
            {
                SwitchState(_playerStateFactory.Damaged());
            }
        }
    }
}
