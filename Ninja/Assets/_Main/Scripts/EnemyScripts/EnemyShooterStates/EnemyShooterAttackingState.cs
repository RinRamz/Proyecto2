using TMPro;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace Ninja
{
    public class EnemyShooterAttackingState : EnemyShooterBaseState
    {
        public EnemyShooterAttackingState(EnemyShootherStateManager currentContext, EnemyShooterStateFactory enemyShooterStateFactory)
        : base(currentContext, enemyShooterStateFactory) { }

        public override void EnterState()
        {
            _context.Animator.Play("EnemyShooter_Attack");
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
                SwitchState(_enemyShooterStateFactory.Moving());
            }
            if (_context.ReceivedDamage)
            {
                SwitchState(_enemyShooterStateFactory.Damaged());
            }
        }
    }
}
