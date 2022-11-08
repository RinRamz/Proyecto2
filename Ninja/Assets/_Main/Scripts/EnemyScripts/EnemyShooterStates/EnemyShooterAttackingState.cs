using TMPro;

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
