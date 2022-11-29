using TMPro;
using UnityEngine;
using System.Collections;

namespace Ninja
{
    public class EnemyBabyStateManager : MonoBehaviour
    {
        private EnemyManager _enemyActions = default;
        private EnemyBabyStateManager _stateManager = default;
        private EnemyBabyBaseState _currentState = default;
        private EnemyBabyStateFactory _states = default;
        private PlayerStateManager _playerStateManager = default;

        [SerializeField] private GameObject _critText = default;
        [SerializeField] private float _hp = 120;
        [SerializeField] private Transform _player = default;
        [SerializeField] private Transform _groundCheck = default;
        [SerializeField] private LayerMask _groundLayer = default;

        private Vector2 _initialPos;
        private Animator _animator = default;
        private Rigidbody2D _rigidBody2D = default;
        private bool _receivedDamage = default;
        private bool _isGrounded = default;
        private bool _isCrit = default;

        //Getters and Setters 
        public EnemyBabyBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }
        public GameObject CritText => _critText;
        public Transform PlayerPos => _player;
        public Animator Animator => _animator;
        public EnemyManager EnemyActions => _enemyActions;
        public EnemyBabyStateManager StateManager => _stateManager;
        public PlayerStateManager PlayerStateManager => _playerStateManager;
        public Rigidbody2D Rigidbody2D => _rigidBody2D;
        public Vector2 InitialPos => _initialPos;
        public float Hp { get { return _hp; } set { _hp = value; } }
        public bool IsGrounded => _isGrounded;
        public bool IsCrit => _isCrit;
        public bool ReceivedDamaged => _receivedDamage;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _rigidBody2D = GetComponent<Rigidbody2D>();
            _enemyActions = EnemyManager.Instance;
            _playerStateManager = FindObjectOfType<PlayerStateManager>();
            _initialPos = transform.position; 

            _states = new EnemyBabyStateFactory(this);
            _currentState = _states.Throw();
            _currentState.EnterState();
        }

        private void Update()
        {
            _currentState.UpdatetState();
            _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, 0.1f, _groundLayer);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Attack1Collider"))
            {
                _isCrit = Random.Range(0, 100) < _playerStateManager.CritChance;
                _receivedDamage = true;
            }
            else if (collision.CompareTag("Attack2Collider"))
            {
               
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
