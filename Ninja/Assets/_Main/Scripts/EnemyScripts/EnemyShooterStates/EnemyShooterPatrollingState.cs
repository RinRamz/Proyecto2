namespace Ninja
{
    public class EnemyShooterPatrollingState : EnemyShooterBaseState
    {
        public EnemyShooterPatrollingState(EnemyShootherStateManager currentContext, EnemyShooterStateFactory enemyShooterStateFactory)
        : base(currentContext, enemyShooterStateFactory) { }
        public override void EnterState()
        {
        }

        public override void UpdatetState()
        {
        }

        public override void ExitState()
        {
        }

        public override void CheckIfSwitchStates()
        {
        }
    }
}
