namespace Ninja
{
    public class EnemyShooterIdleState : EnemyShooterBaseState
    {
        public EnemyShooterIdleState(EnemyShootherStateManager currentContext, EnemyShooterStateFactory enemyShooterStateFactory)
        : base(currentContext, enemyShooterStateFactory) { }

        public override void EnterState()
        {
            _context.Animator.Play("EnemyShooter_Idle");
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
            if (_context.InRangeOfSight)
            {
                SwitchState(_enemyShooterStateFactory.Moving());
            }

            if (_context.ShouldPatrol && !_context.InRangeOfSight)
            {
                SwitchState(_enemyShooterStateFactory.Patrolling());
            }
        }
    }
}
