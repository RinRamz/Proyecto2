using UnityEngine;

namespace Ninja
{
    public class EnemyShooterGetDamaged : EnemyShooterBaseState
    {
        public EnemyShooterGetDamaged(EnemyShootherStateManager currentContext, EnemyShooterStateFactory enemyShooterStateFactory)
        : base(currentContext, enemyShooterStateFactory) { }

        public override void EnterState()
        {
            _context.Animator.Play("GetDamaged_EnemyBasic");
            _context.Rigidbody2D.velocity = new Vector2(_context.PushForce, 2f);
            if (_context.IsCrit)
            {
                _context.Hp = _context.EnemyActions.GetDamaged(Mathf.RoundToInt(_context.PlayerStateManager.Damage * 1.5f), _context.Hp);
            }
            else
            {
                _context.Hp = _context.EnemyActions.GetDamaged(_context.PlayerStateManager.Damage, _context.Hp);
            }
        }

        public override void UpdatetState()
        {
            CheckIfSwitchStates();  
        }

        public override void ExitState()
        {
            _context.Rigidbody2D.velocity = new Vector2(0f, 0f);
            _context.transform.position = new Vector2(_context.transform.position.x, -3.689086f);
        }

        public override void CheckIfSwitchStates()
        {
            if (!_context.ReceivedDamage)
            {
                SwitchState(_enemyShooterStateFactory.Attacking());
            }
        }

    }
}