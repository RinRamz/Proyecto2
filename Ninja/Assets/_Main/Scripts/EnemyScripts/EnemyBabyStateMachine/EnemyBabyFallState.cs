using UnityEngine;

namespace Ninja
{
    public class EnemyBabyFallState : EnemyBabyBaseState
    {
        public EnemyBabyFallState(EnemyBabyStateManager currentContext, EnemyBabyStateFactory enemyBabyStateFactory)
        : base(currentContext, enemyBabyStateFactory) { }

        public override void EnterState()
        {
            _context.Animator.Play("Fall_EnemyBaby");
            _context.Rigidbody2D.velocity = Vector2.down * 10f;
        }

        public override void UpdatetState()
        {
            CheckIfSwitchStates();
        }

        public override void ExitState()
        {
            _context.Rigidbody2D.velocity = Vector2.zero;
        }

        public override void CheckIfSwitchStates()
        {
            if (_context.IsGrounded)
            {
                SwitchState(_enemyBabyStateFactory.Attacking());
            }
        }
    }
}
