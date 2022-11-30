namespace Ninja
{
    public class EnemyBabyStateFactory
    {
        EnemyBabyStateManager _context;

        public EnemyBabyStateFactory(EnemyBabyStateManager currentContext)
        {
            _context = currentContext;
        }

        public EnemyBabyBaseState Attacking()
        {
            return new EnemyBabyAttackingState(_context, this);
        }

        public EnemyBabyBaseState Damaged()
        {
            return new EnemyBabyGetDamaged(_context, this);
        }
        
        public EnemyBabyBaseState Throw()
        {
            return new EnemyBabyThrowState(_context, this);
        }
        
        public EnemyBabyBaseState Fall()
        {
            return new EnemyBabyFallState(_context, this);
        }
    }
}
