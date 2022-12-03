using TMPro;
using UnityEngine;

namespace Ninja
{
    public class EnemyBasicAttackingState : EnemyBasicBaseState
    {
        public EnemyBasicAttackingState(EnemyBasicStateManager currentContext, EnemyBasicStateFactory enemyBasicStateFactory)
        : base(currentContext, enemyBasicStateFactory) { }

        public override void EnterState()
        {
            _context.Animator.Play("Attack_EnemyBasic");
        }

        public override void UpdatetState()
        {
            CheckIfSwitchStates();
        }

        public override void ExitState()
        {
            _context.AudioSource.Pause();
        }

        public override void CheckIfSwitchStates()
        {
            if (!_context.InRangeOfAttack)
            {
                SwitchState(_enemyBasicStateFactory.Moving());
            }
            else if (_context.ReceivedDamaged)
            {
                SwitchState(_enemyBasicStateFactory.Damaged());
            }
        }
    }
}
