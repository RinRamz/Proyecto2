using UnityEngine;

namespace Ninja
{
    public class EnemyShootherStateManager : MonoBehaviour
    {
        private EnemyManager _enemyActions = default;
        private EnemyShootherStateManager _stateManager = default;
        private EnemyShooterBaseState _currentState = default;
        private EnemyShooterStateFactory _states = default;

        [SerializeField] private float _hp = 85f;
        [SerializeField] private LayerMask _playerLayer = default;
        [SerializeField] private GameObject _bullet = default;
        [SerializeField] private Transform _player = default;

        private Animator _animator = default;
        private Rigidbody2D _rigidBody2D = default;
        private float _sightRange = 7.5f;
        private float _attackRange = 5.5f;
        private float _movementSpeed = 4.5f;
        private float _attackSpeed = 1f;
        private float _nextAttackTime = 0f;
        private bool _inRangeofSight = false;
        private bool _inRangeofAttack = false;

        //Getters and Setters 
        public EnemyShooterBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }
        public EnemyManager EnemyActions => _enemyActions;
        public EnemyShootherStateManager StateManager => _stateManager;
        public Transform PlayerPos => _player;
        public Rigidbody2D Rigidbody2D => _rigidBody2D;
        public GameObject Bullet => _bullet;
        public Animator Animator => _animator;
        public float NextAttackTime { get { return _nextAttackTime; } set { _nextAttackTime = value; } }
        public bool InRangeOfSight { get { return _inRangeofSight; } set { _inRangeofSight = value; } }
        public bool InRangeOfAttack { get { return _inRangeofAttack; } set { _inRangeofSight = value; } }
        public float AttackSpeed => _attackSpeed;
        public float MovementSpeed => _movementSpeed;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _rigidBody2D = GetComponent<Rigidbody2D>();
            _enemyActions = GetComponent<EnemyManager>();

            _states = new EnemyShooterStateFactory(this);
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
                _hp = _enemyActions.GetDamaged(Mathf.RoundToInt(damage * 1.75f), _hp);
            }
        }
    }
}
