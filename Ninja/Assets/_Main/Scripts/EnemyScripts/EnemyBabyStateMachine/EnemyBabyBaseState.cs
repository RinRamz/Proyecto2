namespace Ninja
{
    public abstract class EnemyBabyBaseState
    {
        protected EnemyBabyStateManager _context;
        protected EnemyBabyStateFactory _enemyBabyStateFactory;
        
        public EnemyBabyBaseState(EnemyBabyStateManager currentContext, EnemyBabyStateFactory enemyBabyStateFactory)
        {
            _context = currentContext;
            _enemyBabyStateFactory = enemyBabyStateFactory;
        }
        
        public abstract void EnterState();
        
        public abstract void UpdatetState();
        
        public abstract void ExitState();
        
        public abstract void CheckIfSwitchStates();

        protected void SwitchState(EnemyBabyBaseState newState)
        {
            ExitState();
            newState.EnterState();

            _context.CurrentState = newState;
        }
    }
}
