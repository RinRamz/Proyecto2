using UnityEngine;

namespace Ninja
{
    public class EnemyTankPatrollingState : EnemyTankBaseState
    {
        public EnemyTankPatrollingState(EnemyTankStateManager currentContext, EnemyTankStateFactory enemyTankStateFactory)
        : base(currentContext, enemyTankStateFactory) { }

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
                SwitchState(_enemyTankStateFactory.Moving());
            }

            if (!_context.ShouldPatrol && !_context.InRangeOfSight)
            {
                SwitchState(_enemyTankStateFactory.Idle());
            }
        }
    }
}
