using TMPro;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace Ninja
{
    public class EnemyBabyAttackingState : EnemyBabyBaseState
    {
        public EnemyBabyAttackingState(EnemyBabyStateManager currentContext, EnemyBabyStateFactory enemyBabyStateFactory)
        : base(currentContext, enemyBabyStateFactory) { }

        public override void EnterState()
        {
            _context.Animator.Play("Attack_EnemyBaby");
            _context.AudioSource.clip = _context.AudioClips[1];
            _context.AudioSource.Play();
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
            if (_context.ReceivedDamaged)
            {
                SwitchState(_enemyBabyStateFactory.Damaged());
            }
        }
    }
}
