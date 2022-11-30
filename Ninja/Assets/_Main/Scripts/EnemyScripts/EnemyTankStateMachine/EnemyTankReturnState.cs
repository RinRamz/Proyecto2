using UnityEngine;

namespace Ninja
{
    public class EnemyTankReturnState : EnemyTankBaseState
    {
        public EnemyTankReturnState(EnemyTankStateManager currentContext, EnemyTankStateFactory enemyTankStateFactory)
        : base(currentContext, enemyTankStateFactory) { }

        public override void EnterState()
        {
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
                SwitchState(_enemyTankStateFactory.Idle());
            }
        }
    }
}
