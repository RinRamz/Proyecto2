namespace Ninja
{
    public class PlayerStateFactory
    {
        PlayerStateManager _context;

        public PlayerStateFactory(PlayerStateManager currentContext)
        {
            _context = currentContext;
        }

        public PlayerBaseState Idle()
        {
            return new PlayerIdleState(_context, this);
        }
        
        public PlayerBaseState Jump()
        {
            return new PlayerJumpingState(_context, this);
        }

        public PlayerBaseState Landing()
        {
            return new PlayerLandingState(_context, this);
        }

        public PlayerBaseState Moving()
        {
            return new PlayerMovingState(_context, this);
        }

        public PlayerBaseState Attacking()
        {
            return new PlayerAttackingState(_context, this);
        }
        
        public PlayerBaseState Fall()
        {
            return new PlayerFallingState(_context, this);
        }

        public PlayerBaseState Defending()
        {
            return new PlayerDefendingState(_context, this);
        }
        
        public PlayerBaseState Damaged()
        {
            return new PlayerDamagedState(_context, this);
        }
    }
}
