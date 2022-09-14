using UnityEngine;

public class PlayerLandingState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        player.dust.Play();
        player.ChangeState(player.iddleState);
    }

    public override void UpdatetState(PlayerStateManager player)
    {
    }

}
