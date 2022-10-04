namespace Ninja
{
    public class EnemyBasicAttackingState : EnemyBasicBaseState
    {
        public EnemyBasicAttackingState(EnemyBasicStateManager currentContext, EnemyBasicStateFactory enemyBasicStateFactory)
        : base(currentContext, enemyBasicStateFactory) { }

        public override void EnterState()
        {
            _context.EnemyActions.AttackMelee(_context.NextAttackTime, _context.AttackSpeed, _context.Animator);
        }

        public override void UpdatetState()
        {
            CheckIfSwitchStates();
            _context.EnemyActions.AttackMelee(_context.NextAttackTime, _context.AttackSpeed, _context.Animator);
        }

        public override void ExitState()
        {
        }

        public override void CheckIfSwitchStates()
        {
            if (!_context.InRangeOfAttack)
            {
                SwitchState(_enemyBasicStateFactory.Moving());
            }
            if (_context.ReceivedDamaged)
            {
                SwitchState(_enemyBasicStateFactory.Damaged());
            }
        }
    }
}
