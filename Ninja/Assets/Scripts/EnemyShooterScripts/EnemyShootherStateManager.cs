using UnityEngine;

public class EnemyShootherStateManager : MonoBehaviour
{
    public EnemyShooterBaseState currentState;
    public EnemyShooterAttackingState attackingState = new();
    public EnemyShooterIdleState idleState = new();
    public EnemyShooterMovingState movingState = new();
    public EnemyShooterPatrollingState patrollingState = new();

    public Animator animator;
    public LayerMask playerLayer;
    public Transform player;
    public Rigidbody2D rb;

    public float sightRange;
    public float attackRange;
    public float speed;
    private void Awake()
    {
        currentState = idleState;
        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdatetState(this);
    }

    public void changeState(EnemyShooterBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
}
