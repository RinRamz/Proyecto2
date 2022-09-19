using TMPro.EditorUtilities;
using UnityEngine;

public class EnemyShooterAttackingState : EnemyShooterBaseState
{
    public EnemyShooterAttackingState(EnemyShootherStateManager currentContext, EnemyShooterStateFactory enemyShooterStateFactory)
    : base(currentContext, enemyShooterStateFactory) { }
    public override void EnterState()
    {
        _context.Animator.Play("Player_Iddle");
        _context.Attack();
    }

    public override void UpdatetState()
    {
        CheckIfSwitchStates();
        _context.Attack();
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
    }
}
