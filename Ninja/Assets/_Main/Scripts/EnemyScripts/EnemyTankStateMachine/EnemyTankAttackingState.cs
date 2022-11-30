namespace Ninja
{
    public class EnemyTankAttackingState : EnemyTankBaseState
    {
        public EnemyTankAttackingState(EnemyTankStateManager currentContext, EnemyTankStateFactory enemyTankStateFactory)
        : base(currentContext, enemyTankStateFactory) { }

        public override void EnterState()
        {
            _context.Animator.Play("Idle_EnemyTank");
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
            if (!_context.InRangeOfAttack)
            {
                SwitchState(_enemyTankStateFactory.Moving());
            }
            if (_context.ReceivedDamaged)
            {
                SwitchState(_enemyTankStateFactory.Damaged());
            }
        }
    }
}
