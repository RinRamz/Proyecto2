using UnityEngine;

namespace Ninja
{
    public class EnemyShooterPatrollingState : EnemyShooterBaseState
    {
        public EnemyShooterPatrollingState(EnemyShootherStateManager currentContext, EnemyShooterStateFactory enemyShooterStateFactory)
        : base(currentContext, enemyShooterStateFactory) { }

        public override void EnterState()
        {
            Vector3 scale = _context.transform.localScale;
            scale.x = _context.MoveDistance > 0 ? -1f : 1f;
            _context.transform.localScale = scale;
        }

        public override void UpdatetState()
        {
            CheckIfSwitchStates();
            _context.EnemyActions.Patrol(_context.transform, _context.Rigidbody2D, _context.MovementSpeed, _context.MoveDistance);
        }

        public override void ExitState()
        {
        }

        public override void CheckIfSwitchStates()
        {
            if (_context.InRangeOfSight)
            {
                SwitchState(_enemyShooterStateFactory.Moving());
            }

            if (!_context.ShouldPatrol && !_context.InRangeOfSight)
            {
                SwitchState(_enemyShooterStateFactory.Idle());
            }
        }
    }
}
