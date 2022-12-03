using UnityEngine;

namespace Ninja
{
    public class EnemyBasicGetDamaged : EnemyBasicBaseState
    {
        public EnemyBasicGetDamaged(EnemyBasicStateManager currentContext, EnemyBasicStateFactory enemyBasicStateFactory)
        : base(currentContext, enemyBasicStateFactory) { }

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
                _context.EnemyActions.CheckIfDied(_context.Hp, _context.gameObject, _context.Animator, "Dead_EnemyBasic");
                _context.enabled = false;
            }
            else
            {
                _context.Animator.Play("GetDamaged_EnemyBasic");
                _context.AudioSource.clip = _context.AudioClips[0];
                _context.AudioSource.Play();
                _context.Rigidbody2D.velocity = new Vector2(_context.PushForce, 2f);
            }
        }

        public override void UpdatetState()
        {
            CheckIfSwitchStates();
        }

        public override void ExitState()
        {
            _context.AudioSource.Pause();
            _context.Rigidbody2D.velocity = new Vector2(0f, 0f);
            _context.transform.position = new Vector2(_context.transform.position.x, _context.InitialPos.y);
        }

        public override void CheckIfSwitchStates()
        {
            if (!_context.ReceivedDamaged)
            {
                SwitchState(_enemyBasicStateFactory.Attacking());
            }
        }
    }
}
