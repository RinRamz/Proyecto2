namespace Ninja
{
    public abstract class EnemyTankBaseState
    {
        protected EnemyTankStateManager _context;
        protected EnemyTankStateFactory _enemyTankStateFactory;
        
        public EnemyTankBaseState(EnemyTankStateManager currentContext, EnemyTankStateFactory enemyTankStateFactory)
        {
            _context = currentContext;
            _enemyTankStateFactory = enemyTankStateFactory;
        }
        
        public abstract void EnterState();
        
        public abstract void UpdatetState();
        
        public abstract void ExitState();
        
        public abstract void CheckIfSwitchStates();

        protected void SwitchState(EnemyTankBaseState newState)
        {
            ExitState();
            newState.EnterState();

            _context.CurrentState = newState;
        }
    }
}
