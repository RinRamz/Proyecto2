namespace Ninja
{
    public class EnemyShooterMovingState : EnemyShooterBaseState
    {
        public EnemyShooterMovingState(EnemyShootherStateManager currentContext, EnemyShooterStateFactory enemyShooterStateFactory)
        : base(currentContext, enemyShooterStateFactory) { }

        public override void EnterState()
        {
            _context.Animator.Play("Player_Run");
        }

        public override void UpdatetState()
        {
            CheckIfSwitchStates();
            _context.EnemyActions.Move(_context.transform, _context.PlayerPos, _context.Rigidbody2D, _context.MovementSpeed);
        }

        public override void ExitState()
        {
        }

        public override void CheckIfSwitchStates()
        {
            if (!_context.InRangeOfSight)
            {
                SwitchState(_enemyShooterStateFactory.Idle());
            }
            else if (_context.InRangeOfAttack)
            {
                SwitchState(_enemyShooterStateFactory.Attacking());
            }
        }
    }
}
