using UnityEngine;

public class EnemyBasicStateManager : MonoBehaviour
{
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
    public EnemyBasicBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }
    public Animator Animator { get { return _animator; } }
    public bool InRangeOfSight { get { return _inRangeofSight; } set { _inRangeofSight = value; } }
    public bool InRangeOfAttack { get { return _inRangeofAttack; } set { _inRangeofSight = value; } }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidBody2D = GetComponent<Rigidbody2D>();

        _states = new EnemyBasicStateFactory(this);
        _currentState = _states.Idle();
        _currentState.EnterState();
    }

    private void Update()
    {
        _currentState.UpdatetState();
        _inRangeofSight = Physics2D.OverlapCircle(transform.position, _sightRange, _playerLayer);
        _inRangeofAttack = Physics2D.OverlapCircle(transform.position, _attackRange, _playerLayer);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Attack1Collider"))
        {
            int damage = collision.GetComponentInParent<PlayerStateManager>().Damage;
            GetDamaged(damage);
        }
        else if (collision.CompareTag("Attack2Collider"))
        {
            int damage = collision.GetComponentInParent<PlayerStateManager>().Damage;
            GetDamaged(Mathf.RoundToInt(damage * 1.5f));
        }
    }

    public void Move()
    {
        Vector2 target = new Vector2(_player.position.x, _rigidBody2D.position.y);
        Vector2 newPos = Vector2.MoveTowards(transform.position, target, _movementSpeed * Time.fixedDeltaTime);
        _rigidBody2D.MovePosition(newPos);
    }

    public void Attack()
    {
        if (Time.time >= _nextAttackTime)
        {
            _animator.Play("Attack_EnemyBasic");
            _nextAttackTime = Time.time + 1f / _attackSpeed;
        }
    }

    public void GetDamaged(int damage)
    {
        _hp -= damage;
    }

    public void Die()
    {
        if (_hp <= 0)
        {
            Debug.Log("Died" + name);
        }
    }
}
