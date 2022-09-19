using System.Diagnostics.Contracts;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class EnemyShootherStateManager : MonoBehaviour
{
    private EnemyShooterBaseState _currentState = default;
    private EnemyShooterStateFactory _states = default;

    private Animator _animator;
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _player;
    private Rigidbody2D _rigidBody2D;
    private float _sightRange = 7f;
    private float _attackRange = 5.5f;
    private float _movementSpeed = 6.6f;
    private float _attackSpeed = 1f;
    private float _nextAttackTime = 0f;
    private bool _inRangeofSight = false;
    private bool _inRangeofAttack = false;

    //Getters and Setters 
    public EnemyShooterBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }
    public Animator Animator { get { return _animator; } }
    public LayerMask PlayerLayer { get { return _playerLayer; } }
    public Transform Player { get { return _player; } }
    public Rigidbody2D Rigidbody2D { get { return _rigidBody2D; } } 
    public GameObject Bullet { get { return _bullet; } }
    public float SightRange {  get { return _sightRange; } set { _sightRange = value; } }
    public float AttackRange { get { return _attackRange; } set { _attackRange = value; } }
    public float MovementSpeed { get { return _movementSpeed; } set { _movementSpeed = value; } }
    public float AttackSpeed { get { return _attackSpeed; } set { _attackSpeed = value; } }
    public float NextAttackTime { get { return _nextAttackTime; } set { _nextAttackTime = value; } }
    public bool InRangeOfSight { get { return _inRangeofSight; } set { _inRangeofSight = value; } }
    public bool InRangeOfAttack { get { return _inRangeofAttack; } set { _inRangeofSight = value; } }
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidBody2D = GetComponent<Rigidbody2D>();
        
        _states = new EnemyShooterStateFactory(this);
        _currentState = _states.Idle();
        _currentState.EnterState();
    }

    private void Update()
    {
        _currentState.UpdatetState();
        _inRangeofSight = Physics2D.OverlapCircle(transform.position, _sightRange, _playerLayer);
        _inRangeofAttack = Physics2D.OverlapCircle(transform.position, _attackRange, _playerLayer);
    }

    public void Move()
    {
        if (_inRangeofSight)
        {
            Vector2 target = new Vector2(_player.position.x, _rigidBody2D.position.y);
            Vector2 newPos = Vector2.MoveTowards(transform.position, target, _movementSpeed * Time.fixedDeltaTime);
            _rigidBody2D.MovePosition(newPos);
        }
    }

    public void Attack()
    {
        if (Time.time >= _nextAttackTime)
        {
            Instantiate(_bullet, transform.position, Quaternion.identity);
            _nextAttackTime = Time.time + 1f / _attackSpeed;
        }
    }

}
