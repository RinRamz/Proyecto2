using UnityEngine;

namespace Ninja
{
    public class EnemyBasicStateManager : MonoBehaviour
    {
        private EnemyManager _enemyActions = default;
        private EnemyBasicStateManager _stateManager = default;
        private EnemyBasicBaseState _currentState = default;
        private EnemyBasicStateFactory _states = default;
        private PlayerStateManager _playerStateManager = default;

        [SerializeField] private LayerMask _playerLayer = default;
        [SerializeField] private Transform _player = default;

        [SerializeField] private float _hp = 120;
        private Animator _animator = default;
        private Rigidbody2D _rigidBody2D = default;
        private float _sightRange = 6f;
        private float _attackRange = .6f;
        private float _movementSpeed = 4.5f;
        private float _attackSpeed = 1f;
        private float _nextAttackTime = 0f;
        public float _pushForce = default;
        private bool _inRangeofSight = false;
        private bool _inRangeofAttack = false;
        private bool _receivedDamage = default;
        private bool _isCrit = default;

        //Getters and Setters 
        public EnemyBasicBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }
        public EnemyManager EnemyActions => _enemyActions;
        public EnemyBasicStateManager StateManager => _stateManager;
        public PlayerStateManager PlayerStateManager => _playerStateManager;
        public Rigidbody2D Rigidbody2D => _rigidBody2D;
        public Transform PlayerPos => _player;
        public Animator Animator => _animator;
        public float Hp { get { return _hp; } set { _hp = value; } }
        public float PushForce => _pushForce;
        public bool InRangeOfAttack { get { return _inRangeofAttack; } set { _inRangeofSight = value; } }
        public bool InRangeOfSight { get { return _inRangeofSight; } set { _inRangeofSight = value; } }
        public float AttackSpeed => _attackSpeed;
        public float NextAttackTime => _nextAttackTime;
        public float MovementSpeed => _movementSpeed;
        public bool IsCrit => _isCrit;
        public bool ReceivedDamaged => _receivedDamage;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _rigidBody2D = GetComponent<Rigidbody2D>();
            _enemyActions = EnemyManager.Instance;
            _playerStateManager = FindObjectOfType<PlayerStateManager>();

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
                if (collision.GetComponentInParent<Transform>().position.x > transform.position.x)
                {
                    _pushForce = -4f;
                }
                else
                {
                    _pushForce = 4f;
                }
                _isCrit = Random.Range(0, 100) < _playerStateManager.CritChance;
                _receivedDamage = true;
            }
            else if (collision.CompareTag("Attack2Collider"))
            {
                if (collision.GetComponentInParent<Transform>().position.x > transform.position.x)
                {
                    _pushForce = -4f;
                }
                else
                {
                    _pushForce = 4f;
                }
                _isCrit = Random.Range(0, 100) < (_playerStateManager.CritChance * 1.5);
                _receivedDamage = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Attack1Collider"))
            {
                _receivedDamage = false;
                _isCrit = false;
            }
            else if (collision.CompareTag("Attack2Collider"))
            {
                _receivedDamage = false;
                _isCrit = false;
            }
        }
    }
}
