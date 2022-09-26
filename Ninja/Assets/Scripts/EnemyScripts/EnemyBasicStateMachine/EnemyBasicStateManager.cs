using UnityEditor.TextCore.Text;
using UnityEngine;

public class EnemyBasicStateManager : MonoBehaviour
{
    private EnemyManager _enemyActions = default;
    private EnemyBasicStateManager _stateManager = default;
    private EnemyBasicBaseState _currentState = default;
    private EnemyBasicStateFactory _states = default;

    [SerializeField] private LayerMask _playerLayer = default;
    [SerializeField] private Transform _player = default;

    [SerializeField] private float _hp = 120;
    private Animator _animator = default;
    private Rigidbody2D _rigidBody2D = default;
    private float _sightRange = 6f;
    private float _attackRange = .5f;
    private float _movementSpeed = 4.5f;
    private float _attackSpeed = 1f;
    private float _nextAttackTime = 0f;
    private bool _inRangeofSight = false;
    private bool _inRangeofAttack = false;


    //Getters and Setters 
    public EnemyManager EnemyActions { get { return _enemyActions; } }
    public EnemyBasicStateManager StateManager {  get { return _stateManager; } }
    public EnemyBasicBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }
    public Rigidbody2D Rigidbody2D { get { return _rigidBody2D; } }
    public Transform PlayerPos { get { return _player; } }
    public Animator Animator { get { return _animator; } }
    public float AttackSpeed { get { return _attackSpeed; } }
    public float NextAttackTime { get { return _nextAttackTime; } }
    public float MovementSpeed { get { return _movementSpeed; } }
    public bool InRangeOfSight { get { return _inRangeofSight; } set { _inRangeofSight = value; } }
    public bool InRangeOfAttack { get { return _inRangeofAttack; } set { _inRangeofSight = value; } }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _enemyActions = GetComponent<EnemyManager>();

        _states = new EnemyBasicStateFactory(this);
        _currentState = _states.Idle();
        _currentState.EnterState();
    }

    private void Update()
    {
        _currentState.UpdatetState();
        _inRangeofSight = Physics2D.OverlapCircle(transform.position, _sightRange, _playerLayer);
        _inRangeofAttack = Physics2D.OverlapCircle(transform.position, _attackRange, _playerLayer);
        _enemyActions.CheckIfDied(_hp, gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Attack1Collider"))
        {
            int damage = collision.GetComponentInParent<PlayerStateManager>().Damage;
            _hp = _enemyActions.GetDamaged(damage, _hp);
        }
        else if (collision.CompareTag("Attack2Collider"))
        {
            int damage = collision.GetComponentInParent<PlayerStateManager>().Damage;
            _hp = _enemyActions.GetDamaged(Mathf.RoundToInt(damage * 1.5f), _hp);
        }
    }
}
