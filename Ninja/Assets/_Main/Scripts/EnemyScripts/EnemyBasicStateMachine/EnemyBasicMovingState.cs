namespace Ninja
{
    public class EnemyBasicMovingState : EnemyBasicBaseState
    {
        public EnemyBasicMovingState(EnemyBasicStateManager currentContext, EnemyBasicStateFactory enemyBasicStateFactory)
        : base(currentContext, enemyBasicStateFactory) { }

        public override void EnterState()
        {
            _context.Animator.Play("Moving_EnemyBasic");
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
                SwitchState(_enemyBasicStateFactory.Attacking());
            }
            
            if (!_context.InRangeOfSight && !_context.InRangeOfAttack)
            {
                SwitchState(_enemyBasicStateFactory.Return());
            }
        }
    }
}
