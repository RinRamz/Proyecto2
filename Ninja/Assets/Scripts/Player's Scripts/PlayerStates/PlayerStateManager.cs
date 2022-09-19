using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{

    private PlayerBaseState _currentState = default;
    private PlayerStateFactory _states = default;

    private ParticleSystem _dust = default;
    private Rigidbody2D _rigidbody2D = default;
    private Animator _animator = default;
    private bool _isFacingRight;
    private int _damage = 20;
    private bool _isAttacking = false;
    private bool _isInSecondAttack = false;
    private int _extraJumps = 2;
    private float _horizontalInput;
    private float _movementSpeed = 8f;
    private float _negativeJumpingSpeed = 16f;
    private float _jumpingPower = 8f;
    private bool _isGrounded = true;
    [SerializeField] private Transform _groundCheck = default;
    [SerializeField] private LayerMask _groundLayer = default;

    //Getters and Setters
    public PlayerBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }
    public ParticleSystem Dust { get { return _dust; } }
    public Rigidbody2D Rigidbody2D { get { return _rigidbody2D; } }
    public Animator Animator { get { return _animator; } }
    public bool IsAttacking { get { return _isAttacking; } set { _isAttacking = value; } }
    public bool IsInSecondAttack { get { return _isInSecondAttack; } set { _isInSecondAttack = value; } }
    public int ExtraJumps { get { return _extraJumps; } set { _extraJumps = value; } }
    public float HorizontalInput { get { return _horizontalInput; } }
    public float MovementSpeed { get { return _movementSpeed; } }
    public float NegativeJumpingSpeed { get { return _negativeJumpingSpeed; } }
    public float JumpingPower { get { return _jumpingPower; } } 
    public int Damage { get { return _damage; } }
    public bool IsGrounded { get { return _isGrounded; } set { _isGrounded = value; } }

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
        _horizontalInput = Input.GetAxisRaw("Horizontal");

    }

    public void Flip()
    {
        if (_horizontalInput > 0 && _isFacingRight || _horizontalInput < 0 && !_isFacingRight)
        {
            _isFacingRight = !_isFacingRight;
            transform.Rotate(0f, 180f, 0f);
        }
    }

    public void Move()
    {
        _rigidbody2D.velocity = new Vector2(_horizontalInput * _movementSpeed, Rigidbody2D.velocity.y);
    }
    public void FinishCombo()
    {
        _isAttacking = false;
        _isInSecondAttack = false;
    }
}
