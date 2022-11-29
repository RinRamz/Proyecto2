namespace Ninja
{
    public class EnemyTankMovingState : EnemyTankBaseState
    {
        public EnemyTankMovingState(EnemyTankStateManager currentContext, EnemyTankStateFactory enemyTankStateFactory)
        : base(currentContext, enemyTankStateFactory) { }

        public override void EnterState()
        {
        }

        public override void UpdatetState()
        {
            CheckIfSwitchStates();
            _context.EnemyActions.Move(_context.transform, _context.PlayerPos, _context.Rigidbody2D, _context.MovementSpeed);
            _context.EnemyActions.Flip(_context.transform, _context.PlayerPos);
        }

        public override void ExitState()
        {
        }

        public override void CheckIfSwitchStates()
        {
            if (_context.InRangeOfAttack)
            {
                SwitchState(_enemyTankStateFactory.Attacking());
            }
            
            if (!_context.InRangeOfSight && !_context.InRangeOfAttack)
            {
                SwitchState(_enemyTankStateFactory.Return());
            }
        }
    }
}
