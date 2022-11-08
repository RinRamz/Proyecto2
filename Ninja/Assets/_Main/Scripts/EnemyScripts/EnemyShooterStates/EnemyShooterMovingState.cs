using TMPro;

namespace Ninja
{
    public class EnemyShooterMovingState : EnemyShooterBaseState
    {
        public EnemyShooterMovingState(EnemyShootherStateManager currentContext, EnemyShooterStateFactory enemyShooterStateFactory)
        : base(currentContext, enemyShooterStateFactory) { }

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
            if (!_context.InRangeOfSight)
            {
                SwitchState(_enemyShooterStateFactory.Return());
            }
            else if (!_context.InRangeOfAttack)
            {
                SwitchState(_enemyShooterStateFactory.Return());
            }

            if (_context.InRangeOfAttack)
            {
                SwitchState(_enemyShooterStateFactory.Attacking());
            }
        }
    }
}
