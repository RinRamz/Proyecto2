using UnityEngine;
public class EnemyManager : Singleton<EnemyManager> 
{
    public void Move(Transform _currentPos, Transform _playerPos, Rigidbody2D _rigidbody2D, float _movementSpeed)
    {
        Vector2 target = new Vector2(_playerPos.position.x, _rigidbody2D.position.y);
        Vector2 newPos = Vector2.MoveTowards(_currentPos.position, target, _movementSpeed * Time.fixedDeltaTime);
        _rigidbody2D.MovePosition(newPos);
    }

    public float AttackRanged(float _nextAttackTime, float _attackSpeed, GameObject _bullet)
    {
        if (Time.time >= _nextAttackTime)
        {
            Instantiate(_bullet, transform.position, Quaternion.identity);
            _nextAttackTime = Time.time + 1f / _attackSpeed;
        }
        return _nextAttackTime;
    }

    public float AttackMelee(float _nextAttackTime, float _attackSpeed, Animator _animator)
    {
        if (Time.time >= _nextAttackTime)
        {
            _animator.Play("Attack_EnemyBasic");
            _nextAttackTime = Time.time + 1f / _attackSpeed;
        }
        return _nextAttackTime;
    }

    public float GetDamaged(int _damage, float _hp)
    {
        _hp -= _damage;
        return _hp;
    }

    public void CheckIfDied(float _hp, GameObject gameObject)
    {
        if (_hp <= 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            return;
        }
    }
}
