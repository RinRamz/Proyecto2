using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasicIdleState : EnemyBasicBaseState
{
    public EnemyBasicIdleState(EnemyBasicStateManager currentContext, EnemyBasicStateFactory enemyBasicStateFactory)
    : base(currentContext, enemyBasicStateFactory) { }


    public override void EnterState()
    {
        _context.Animator.Play("Idle_EnemyBasic");
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
            SwitchState(_enemyBasicStateFactory.Moving());
        }
    }
}
