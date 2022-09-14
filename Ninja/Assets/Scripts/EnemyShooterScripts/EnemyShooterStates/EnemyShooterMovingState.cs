using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyShooterMovingState : EnemyShooterBaseState
{
    bool inRangeofSight;

    public override void EnterState(EnemyShootherStateManager enemyShooter)
    {
        enemyShooter.animator.Play("Player_Run");
    }

    public override void UpdatetState(EnemyShootherStateManager enemyShooter)
    {
        inRangeofSight = Physics2D.OverlapCircle(enemyShooter.transform.position, enemyShooter.sightRange, enemyShooter.playerLayer);

        Vector2 target = new Vector2(enemyShooter.player.position.x, enemyShooter.rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(enemyShooter.transform.position, target, enemyShooter.speed * Time.fixedDeltaTime);
        enemyShooter.rb.MovePosition(newPos);

        if(!inRangeofSight)
        {
            enemyShooter.changeState(enemyShooter.idleState);
        }
    }
}
