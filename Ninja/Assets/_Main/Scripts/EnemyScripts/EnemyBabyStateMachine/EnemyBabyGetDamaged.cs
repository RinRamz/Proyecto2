using UnityEngine;

namespace Ninja
{
    public class EnemyBabyGetDamaged : EnemyBabyBaseState
    {
        public EnemyBabyGetDamaged(EnemyBabyStateManager currentContext, EnemyBabyStateFactory enemyBabyStateFactory)
        : base(currentContext, enemyBabyStateFactory) { }

        public override void EnterState()
        {
            if (_context.IsCrit)
            {
                _context.Hp = _context.EnemyActions.GetDamaged(Mathf.RoundToInt(_context.PlayerStateManager.Damage * 1.5f), _context.Hp, _context.CritText, _context.IsCrit, _context.transform, _context.PlayerPos);
            }
            else
            {
                _context.Hp = _context.EnemyActions.GetDamaged(_context.PlayerStateManager.Damage, _context.Hp, _context.CritText, _context.IsCrit, _context.transform, _context.PlayerPos);
            }

            if (_context.Hp <= 0)
            {
                _context.EnemyActions.CheckIfDied(_context.Hp, _context.gameObject, _context.Animator, "Death_EnemyBaby");
                _context.enabled = false;
            }
            else
            {
                _context.Animator.Play("Damaged_EnemyBaby");
            }
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
            if (!_context.ReceivedDamaged)
            {
                SwitchState(_enemyBabyStateFactory.Attacking());
            }
        }
    }
}
