namespace Ninja
{
    public class EnemyTankStateFactory
    {
        EnemyTankStateManager _context;

        public EnemyTankStateFactory(EnemyTankStateManager currentContext)
        {
            _context = currentContext;
        }

        public EnemyTankBaseState Idle()
        {
            return new EnemyTankIdleState(_context, this);
        }

        public EnemyTankBaseState Moving()
        {
            return new EnemyTankMovingState(_context, this);
        }

        public EnemyTankBaseState Attacking()
        {
            return new EnemyTankAttackingState(_context, this);
        }

        public EnemyTankBaseState Patrolling()
        {
            return new EnemyTankPatrollingState(_context, this);
        }

        public EnemyTankBaseState Return()
        {
            return new EnemyTankReturnState(_context, this);
        }

        public EnemyTankBaseState Damaged()
        {
            return new EnemyTankGetDamaged(_context, this);
        }
    }
}
