using UnityEngine;

namespace Ninja
{
    public class EnemyTankIdleState : EnemyTankBaseState
    {
        public EnemyTankIdleState(EnemyTankStateManager currentContext, EnemyTankStateFactory enemyTankStateFactory)
        : base(currentContext, enemyTankStateFactory) { }

        public override void EnterState()
        {
            _context.Animator.Play("Idle_EnemyTank");
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
            if (_context.InRangeOfSight)
            {
                SwitchState(_enemyTankStateFactory.Moving());
            }

            if (_context.ShouldPatrol && !_context.InRangeOfSight)
            {
                SwitchState(_enemyTankStateFactory.Patrolling());
            }
        }
    }
}
