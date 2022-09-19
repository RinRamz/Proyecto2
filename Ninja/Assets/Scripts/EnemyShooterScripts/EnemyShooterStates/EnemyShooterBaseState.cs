using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public abstract class EnemyShooterBaseState
{
    protected EnemyShootherStateManager _context;
    protected EnemyShooterStateFactory _enemyShooterStateFactory;
    public EnemyShooterBaseState(EnemyShootherStateManager currentContext, EnemyShooterStateFactory enemyShooterStateFactory)
    {
        _context = currentContext;
        _enemyShooterStateFactory = enemyShooterStateFactory;
    }
    public abstract void EnterState();
    public abstract void UpdatetState();
    public abstract void ExitState();
    public abstract void CheckIfSwitchStates();

    protected void SwitchState (EnemyShooterBaseState newState)
    {
        ExitState();
        newState.EnterState();

        _context.CurrentState = newState;
    }
}
