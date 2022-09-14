using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    PlayerBaseState currentState;
    public PlayerIddleState iddleState = new();
    public PlayerJumpingState jumpState = new();
    public PlayerLandingState landState = new();
    public PlayerMovingState movingState = new();
    public PlayerAttackingState attackingState = new();

    public ParticleSystem dust;
    public Rigidbody2D rb;
    public Animator animator;
    public bool isFacingRight;
    public Transform groundcheck;
    public LayerMask groundLayer;
    public bool isAttacking;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        currentState = iddleState;
        currentState.EnterState(this);
    }
    private void Update()
    {
        currentState.UpdatetState(this);
    }
    public void ChangeState(PlayerBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    public void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
    public void FinishCombo()
    {
        isAttacking = false;
    }
}
