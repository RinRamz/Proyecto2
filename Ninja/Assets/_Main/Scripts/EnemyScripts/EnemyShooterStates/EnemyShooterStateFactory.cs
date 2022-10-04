namespace Ninja
{
    public class EnemyShooterStateFactory
    {
        EnemyShootherStateManager _context;

        public EnemyShooterStateFactory(EnemyShootherStateManager currentContext)
        {
            _context = currentContext;
        }

        public EnemyShooterBaseState Idle()
        {
            return new EnemyShooterIdleState(_context, this);
        }

        public EnemyShooterBaseState Moving()
        {
            return new EnemyShooterMovingState(_context, this);
        }

        public EnemyShooterBaseState Attacking()
        {
            return new EnemyShooterAttackingState(_context, this);
        }

        public EnemyShooterBaseState Patrolling()
        {
            return new EnemyShooterPatrollingState(_context, this);
        }
    }
}
