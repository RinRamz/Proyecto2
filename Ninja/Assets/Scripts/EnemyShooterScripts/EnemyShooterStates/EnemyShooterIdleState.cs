using UnityEngine;

public class EnemyShooterIdleState : EnemyShooterBaseState
{
    bool inRangeofSight;
    public override void EnterState(EnemyShootherStateManager enemyShooter)
    {
        enemyShooter.animator.Play("Player_Iddle");
    }

    public override void UpdatetState(EnemyShootherStateManager enemyShooter)
    {
        inRangeofSight = Physics2D.OverlapCircle(enemyShooter.transform.position, enemyShooter.sightRange, enemyShooter.playerLayer);

        if (inRangeofSight)
        {
            enemyShooter.changeState(enemyShooter.movingState);
        }
    }
}
