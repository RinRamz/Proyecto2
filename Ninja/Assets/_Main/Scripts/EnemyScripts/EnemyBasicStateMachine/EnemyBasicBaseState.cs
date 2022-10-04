namespace Ninja
{
    public abstract class EnemyBasicBaseState
    {
        protected EnemyBasicStateManager _context;
        protected EnemyBasicStateFactory _enemyBasicStateFactory;
        
        public EnemyBasicBaseState(EnemyBasicStateManager currentContext, EnemyBasicStateFactory enemyBasicStateFactory)
        {
            _context = currentContext;
            _enemyBasicStateFactory = enemyBasicStateFactory;
        }
        
        public abstract void EnterState();
        
        public abstract void UpdatetState();
        
        public abstract void ExitState();
        
        public abstract void CheckIfSwitchStates();

        protected void SwitchState(EnemyBasicBaseState newState)
        {
            ExitState();
            newState.EnterState();

            _context.CurrentState = newState;
        }
    }
}
