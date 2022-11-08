using UnityEngine;
using System.Collections;

namespace Ninja
{
    public class PlayerStateManager : MonoBehaviour
    {
        //State machine
        private PlayerBaseState _currentState = default;
        private PlayerStateFactory _states = default;

        //Animator
        private Animator _animator = default;

        //Lose canvas
        [SerializeField] private GameObject _loseCanvas = default;
        [SerializeField] private GameObject _mainCanvas = default;

        //HP
        [SerializeField] private float _hp = 100;

        //Damaged variables
        private bool _isDamaged = false;

        //Movement/Jumping variables
        private bool _isFacingRight = default;
        private bool _isJumpPressed = default;
        [SerializeField] private int _extraJumps = 2;
        private bool _canJumpAgain = default;
        private float _negativeJumpingSpeed = 16f;
        private bool _isGrounded = default;
        private ParticleSystem _dust = default;
        private Rigidbody2D _rigidbody2D = default;
        private float _movementSpeed = 8f;
        private float _jumpingPower = 8.7f;
        private float _input = default;
        [SerializeField] private Transform _groundCheck = default;
        [SerializeField] private LayerMask _groundLayer = default;

        //Attacking variables
        private bool _isAttackPressed = default;
        private bool _isAttacking = false;
        private bool _isInFirstAttack = false;
        private bool _isInSecondAttack = false;
        private bool _canAttackAgain = true;
        private int _damage = 20;
        private float _critChance = 100f;

        //Defending variables
        private bool _isDenfencePressed = false;

        //Getters and Setters
        public PlayerBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }
        public ParticleSystem Dust => _dust;
        public Rigidbody2D Rigidbody2D => _rigidbody2D;
        public Animator Animator => _animator;
        public bool CanAttackAgain => _canAttackAgain;
        public bool CanJumpAgain { get { return _canJumpAgain; } set { _canJumpAgain = value; } }
        public bool IsAttackPressed => _isAttackPressed;
        public bool IsDamaged => _isDamaged;
        public bool IsJumpPressed => _isJumpPressed;
        public bool IsDenfencePressed => _isDenfencePressed;
        public bool IsAttacking { get { return _isAttacking; } set { _isAttacking = value; } }
        public bool IsInSecondAttack { get { return _isInSecondAttack; } set { _isInSecondAttack = value; } }
        public bool IsInFirstAttack { get { return _isInFirstAttack; } set { _isInFirstAttack = value; } }
        public int ExtraJumps { get { return _extraJumps; } set { _extraJumps = value; } }
        public float MovementSpeed => _movementSpeed;
        public float NegativeJumpingSpeed => _negativeJumpingSpeed;
        public float JumpingPower => _jumpingPower;
        public float CritChance => _critChance;
        public int Damage => _damage;
        public bool IsGrounded { get { return _isGrounded; } set { _isGrounded = value; } }
        public float Input => _input;
        public float Hp => _hp;

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
        }

        private void FixedUpdate()
        {
            _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, 0.1f, _groundLayer);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("EnemyAttackCollider") && !IsDenfencePressed)
            {
                _isDamaged = true;
                float _damage = collision.GetComponent<EnemyCombatManager>().Damage;
                GetDamaged(_damage);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("EnemyAttackCollider"))
            {
                _isDamaged = false;
            }
        }


        public void GetDamaged(float damage)
        {
            _hp -= damage;
        }

        public void Die()
        {
            Time.timeScale = 0f;
            _loseCanvas.SetActive(true);
            _mainCanvas.SetActive(false);
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

        public void AbleToJumpAgain()
        {
            _canJumpAgain = true;
        }

        public void AttackButtonPressed()
        {
            _isAttackPressed = true;
        }

        public void AttackButtonRealesed()
        {
            _isAttackPressed = false;
        }   
        
        public void DefenceButtonPressed()
        {
            _isDenfencePressed = true;
        }

        public void DefenceButtonRealesed()
        {
            _isDenfencePressed = false;
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

        public IEnumerator AttackTimer()
        {
            _canAttackAgain = false;
            yield return new WaitForSeconds(2f);
            _canAttackAgain = true;
        }
    }
}
