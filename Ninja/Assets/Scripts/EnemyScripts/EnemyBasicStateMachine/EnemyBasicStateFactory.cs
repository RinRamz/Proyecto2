public class EnemyBasicStateFactory
{
    EnemyBasicStateManager _context;

    public EnemyBasicStateFactory(EnemyBasicStateManager currentContext)
    {
        _context = currentContext;
    }

    public EnemyBasicBaseState Idle()
    {
        return new EnemyBasicIdleState(_context, this);
    }

    public EnemyBasicBaseState Moving()
    {
        return new EnemyBasicMovingState(_context, this);
    }

    public EnemyBasicBaseState Attacking()
    {
        return new EnemyBasicAttackingState(_context, this);
    }

    public EnemyBasicBaseState Patrolling()
    {
        return new EnemyBasicPatrollingState(_context, this);
    }

    public EnemyBasicBaseState Damaged()
    {
        return new EnemyBasicGetDamaged(_context, this);
    }
}