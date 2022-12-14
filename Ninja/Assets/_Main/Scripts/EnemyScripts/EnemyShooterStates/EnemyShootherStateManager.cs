using UnityEngine;
using System.Collections;

namespace Ninja
{
    public class EnemyShootherStateManager : MonoBehaviour
    {
        private EnemyManager _enemyActions = default;
        private EnemyShootherStateManager _stateManager = default;
        private EnemyShooterBaseState _currentState = default;
        private EnemyShooterStateFactory _states = default;
        private PlayerStateManager _playerStateManager = default;

        [SerializeField] private EnemyRangeOfSight _enemyRangeOfSight = default;
        [SerializeField] private float _hp = 85f;
        [SerializeField] private LayerMask _playerLayer = default;
        [SerializeField] private GameObject _bullet = default;
        [SerializeField] private Transform _player = default;
        [SerializeField] private GameObject _critText = default;
        [SerializeField] private AudioClip[] _audioClips = default;

        private AudioSource _audioSource = default;
        private Animator _animator = default;
        private Rigidbody2D _rigidBody2D = default;
        private Vector2 _initialPos = default;
        private float _attackRange = 5.5f;
        private float _movementSpeed = 4.5f;
        private float _moveDistance = -6f;
        private bool _inRangeofSight = false;
        private bool _inRangeofAttack = false;
        private bool _receivedDamage = default;
        private bool _isCrit = default;
        private float _pushForce = default;
        private bool _shouldPatrol = true;
        private float _nextAttackTime = 0f;
        private float _attackRate = 1f;

        //Getters and Setters 
        public EnemyShooterBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }
        public AudioSource AudioSource { get { return _audioSource; } set { _audioSource = value; } }
        public AudioClip[] AudioClips => _audioClips;
        public EnemyManager EnemyActions => _enemyActions;
        public EnemyShootherStateManager StateManager => _stateManager;
        public PlayerStateManager PlayerStateManager => _playerStateManager;
        public Transform PlayerPos => _player;
        public Rigidbody2D Rigidbody2D => _rigidBody2D;
        public GameObject CritText => _critText;
        public GameObject Bullet => _bullet;
        public Animator Animator => _animator;
        public Vector2 InitialPos => _initialPos;
        public float Hp { get { return _hp; } set { _hp = value; } }
        public bool IsCrit => _isCrit;
        public bool ReceivedDamage => _receivedDamage;
        public float PushForce => _pushForce;
        public float NextAttackTime { get { return _nextAttackTime; } set { _nextAttackTime = value; } }
        public float AttackRate { get { return _attackRate; } set { _attackRate = value; } }
        public float MoveDistance { get { return _moveDistance; } set { _moveDistance = value; } }
        public bool InRangeOfSight { get { return _inRangeofSight; } set { _inRangeofSight = value; } }
        public bool InRangeOfAttack { get { return _inRangeofAttack; } set { _inRangeofSight = value; } }
        public bool ShouldPatrol => _shouldPatrol;
        public float MovementSpeed => _movementSpeed;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _rigidBody2D = GetComponent<Rigidbody2D>();
            _audioSource = GetComponent<AudioSource>();
            _enemyActions = EnemyManager.Instance;
            _playerStateManager = FindObjectOfType<PlayerStateManager>();
            _initialPos = transform.position;

            _states = new EnemyShooterStateFactory(this);
            _currentState = _states.Idle();
            _currentState.EnterState();
        }

        private void Update()
        {
            _currentState.UpdatetState();
            _inRangeofSight = _enemyRangeOfSight.InRangeofSight;
            _inRangeofAttack = Physics2D.OverlapCircle(transform.position, _attackRange, _playerLayer);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Attack1Collider"))
            {
                if (_player.position.x > transform.position.x)
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
                if (collision.GetComponentInParent<Transform>().position.x < transform.position.x)
                {
                    _pushForce = 4f;
                }
                else
                {
                    _pushForce = -4f;
                }
                _isCrit = Random.Range(0, 100) < (_playerStateManager.CritChance * 1.5);
                _receivedDamage = true;
            }

            if (collision.CompareTag("EnemyWall"))
            {
                _moveDistance = _enemyActions.FlipPatrol(transform, _moveDistance);
                _shouldPatrol = false;
                StartCoroutine(Patrol());
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

        public void PlayAttackSound()
        {
            _audioSource.clip = _audioClips[1];
            _audioSource.Play();
        }

        public void AttackRanged()
        {
            Instantiate(_bullet, transform.position, Quaternion.identity);
        }

        private IEnumerator Patrol()
        {
            yield return new WaitForSeconds(2f);
            _shouldPatrol = true;
        }
    }
}
