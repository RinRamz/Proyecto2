using UnityEngine;

public abstract class EnemyShooterBaseState
{
    public abstract void EnterState(EnemyShootherStateManager enemyShooter);
    public abstract void UpdatetState(EnemyShootherStateManager enemyShooter);
}
