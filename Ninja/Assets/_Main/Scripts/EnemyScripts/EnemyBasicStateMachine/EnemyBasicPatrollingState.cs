using UnityEngine;

namespace Ninja
{
    public class EnemyBasicPatrollingState : EnemyBasicBaseState
    {
        public EnemyBasicPatrollingState(EnemyBasicStateManager currentContext, EnemyBasicStateFactory enemyBasicStateFactory)
        : base(currentContext, enemyBasicStateFactory) { }

        public override void EnterState()
        {
            _context.Animator.Play("Moving_EnemyBasic");
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
            _context.AudioSource.Pause();
        }

        public override void CheckIfSwitchStates()
        {
            if (_context.InRangeOfSight)
            {
                SwitchState(_enemyBasicStateFactory.Moving());
            }

            if (!_context.ShouldPatrol && !_context.InRangeOfSight)
            {
                SwitchState(_enemyBasicStateFactory.Idle());
            }
        }
    }
}
