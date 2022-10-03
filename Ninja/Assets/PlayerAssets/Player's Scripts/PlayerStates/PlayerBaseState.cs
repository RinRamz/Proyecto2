public abstract class PlayerBaseState
{
    protected PlayerStateManager _context;
    protected PlayerStateFactory _playerStateFactory;
    public PlayerBaseState (PlayerStateManager currentContext, PlayerStateFactory playerStateFactory)
    {
        _context = currentContext;
        _playerStateFactory = playerStateFactory;
    }

    public abstract void EnterState();
    public abstract void UpdatetState();
    public abstract void ExitState();
    public abstract void CheckIfSwitchStates();

    protected void SwitchState(PlayerBaseState newState)
    {
        ExitState();

        newState.EnterState();

        _context.CurrentState = newState;
    }
}
