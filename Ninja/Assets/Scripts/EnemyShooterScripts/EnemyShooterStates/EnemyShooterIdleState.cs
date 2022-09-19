using UnityEngine;

public class EnemyShooterIdleState : EnemyShooterBaseState
{
    public EnemyShooterIdleState(EnemyShootherStateManager currentContext, EnemyShooterStateFactory enemyShooterStateFactory)
    : base(currentContext, enemyShooterStateFactory) { }

    public override void EnterState()
    {
        _context.Animator.Play("Player_Iddle");
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
            SwitchState(_enemyShooterStateFactory.Moving());
        }
    }
}
