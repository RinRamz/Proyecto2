using UnityEngine;
public class PlayerStateManager : MonoBehaviour
{
    private PlayerBaseState _currentState = default;
    private PlayerStateFactory _states = default;

    private ParticleSystem _dust = default;
    private Rigidbody2D _rigidbody2D = default;
    private Animator _animator = default;
    private int _damage = 20;
    private bool _isFacingRight = default;
    private bool _isAttackHold = default;
    private bool _isAttackPressed = default;
    private bool _isJumpPressed = default;
    private bool _isAttacking = false;
    private bool _isInFirstAttack = false;
    private bool _isInSecondAttack = false;
    private int _extraJumps = 2;
    private float _movementSpeed = 8f;
    private float _negativeJumpingSpeed = 16f;
    private float _jumpingPower = 8f;
    private bool _isGrounded = default;
    private float _input = default;
    [SerializeField] private Transform _groundCheck = default;
    [SerializeField] private LayerMask _groundLayer = default;

    //Getters and Setters
    public PlayerBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }
    public ParticleSystem Dust => _dust;
    public Rigidbody2D Rigidbody2D => _rigidbody2D;
    public Animator Animator => _animator;
    public bool IsAttackHold => _isAttackHold;
    public bool IsAttackPressed => _isAttackPressed;
    public bool IsJumpPressed => _isJumpPressed;
    public bool IsAttacking { get { return _isAttacking; } set { _isAttacking = value; } }
    public bool IsInSecondAttack { get { return _isInSecondAttack; } set { _isInSecondAttack = value; } }
    public bool IsInFirstAttack { get { return _isInFirstAttack; } set { _isInFirstAttack = value; } }
    public int ExtraJumps { get { return _extraJumps; } set { _extraJumps = value; } }
    public float MovementSpeed => _movementSpeed;
    public float NegativeJumpingSpeed => _negativeJumpingSpeed;
    public float JumpingPower => _jumpingPower;
    public int Damage => _damage;
    public bool IsGrounded { get { return _isGrounded; } set { _isGrounded = value; } }
    public float Input => _input;

    private void Awake()
    {
        _dust = GetComponentInChildren<ParticleSystem>();
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        
        _states = new PlayerStateFactory(this);
        _currentState = _states.Idle();
        _currentState.EnterState();
        
    }
    private void Update()
    {
        _currentState.UpdatetState();

        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, 0.1f, _groundLayer);
    }

    public void Flip()
    {
        if (_input > 0 && _isFacingRight || _input < 0 && !_isFacingRight)
        {
            _isFacingRight = !_isFacingRight;
            transform.Rotate(0f, 180f, 0f);
        }
    }

    public void Move()
    {
        _rigidbody2D.velocity = new Vector2(_input * _movementSpeed, _rigidbody2D.velocity.y);
    }


    public void JumpButtonPressed()
    {
        _isJumpPressed = true;
    }

    public void JumpButtonRealesed()
    {
        _isJumpPressed = false;
    }

    public void AttackButtonPressed()
    {
        _isAttackPressed = true;
    }

    public void AttackButtonHold()
    {
        _isAttackHold = true;
    }

    public void AttackButtonRealesed()
    {
        _isAttackPressed = false;
        _isAttackHold = false;
    }

    public void Jump()
    {
        _rigidbody2D.velocity = Vector2.up * _jumpingPower;
        _extraJumps--;
    }

    public void FinishCombo()
    {
        _isAttacking = false;
        _isInFirstAttack = false;
        _isInSecondAttack = false;   
    }

    public void StartCombo()
    {
        _isInFirstAttack = false;
    }

    public void MoveLeft()
    {
        _input = -1;
    }

    public void MoveRight()
    {
        _input = 1;
    }

    public void ResetLeft()
    {
        _input = _input == -1 ? 0f : _input;
    }

    public void ResetRight()
    {
        _input = _input == 1 ? 0f : _input;
    }
}
