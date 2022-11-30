using UnityEngine;

namespace Ninja
{
    public class EnemyBabyThrowState : EnemyBabyBaseState
    {
        public EnemyBabyThrowState(EnemyBabyStateManager currentContext, EnemyBabyStateFactory enemyBabyStateFactory)
        : base(currentContext, enemyBabyStateFactory) { }

        public override void EnterState()
        {
            _context.Animator.Play("Throw_EnemyBaby");
            _context.Rigidbody2D.velocity = Vector2.up * 8f;
        }

        public override void UpdatetState()
        {
            CheckIfSwitchStates();
        }

        public override void ExitState()
        {
        }

        public override void CheckIfSwitchStates()
        {
            if (_context.transform.position.y > (_context.InitialPos.y + 3))
            {
                SwitchState(_enemyBabyStateFactory.Fall());
            }
        }
    }
}
