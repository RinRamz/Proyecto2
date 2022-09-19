using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyShooterMovingState : EnemyShooterBaseState
{
    public EnemyShooterMovingState(EnemyShootherStateManager currentContext, EnemyShooterStateFactory enemyShooterStateFactory)
    : base(currentContext, enemyShooterStateFactory) { }


    public override void EnterState()
    {
        _context.Animator.Play("Player_Run");
    }

    public override void UpdatetState()
    {
        CheckIfSwitchStates();
        _context.Move();
    }

    public override void ExitState()
    {
    }

    public override void CheckIfSwitchStates()
    {
        if (!_context.InRangeOfSight)
        {
            SwitchState(_enemyShooterStateFactory.Idle());
        }
        else if (_context.InRangeOfAttack)
        {
            SwitchState(_enemyShooterStateFactory.Attacking());
        }
    }
}
