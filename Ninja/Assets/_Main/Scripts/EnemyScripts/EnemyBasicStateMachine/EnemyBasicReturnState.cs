using UnityEngine;

namespace Ninja
{
    public class EnemyBasicReturnState : EnemyBasicBaseState
    {
        public EnemyBasicReturnState(EnemyBasicStateManager currentContext, EnemyBasicStateFactory enemyBasicStateFactory)
        : base(currentContext, enemyBasicStateFactory) { }

        public override void EnterState()
        {
            _context.Animator.Play("Moving_EnemyBasic");
        }

        public override void UpdatetState()
        {
            CheckIfSwitchStates();
            _context.EnemyActions.ReturnPos(_context.transform, _context.InitialPos, _context.Rigidbody2D, _context.MovementSpeed);
        }

        public override void ExitState()
        {
        }

        public override void CheckIfSwitchStates()
        {
            if (_context.InitialPos.x == _context.transform.position.x )
            {
                SwitchState(_enemyBasicStateFactory.Idle());
            }
        }
    }
}
