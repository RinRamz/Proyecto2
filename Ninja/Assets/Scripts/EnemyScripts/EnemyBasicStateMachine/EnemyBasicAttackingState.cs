using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyBasicAttackingState : EnemyBasicBaseState
{
    public EnemyBasicAttackingState(EnemyBasicStateManager currentContext, EnemyBasicStateFactory enemyBasicStateFactory)
    : base(currentContext, enemyBasicStateFactory) { }


    public override void EnterState()
    {
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
            SwitchState(_enemyBasicStateFactory.Moving());
        }
    }
}
