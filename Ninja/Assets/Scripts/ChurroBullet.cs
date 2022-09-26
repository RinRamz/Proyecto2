using UnityEngine;

public class ChurroBullet : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D = default;
    private Transform _playerPos = default;
    private float _speed = 20f;
    private Vector2 _target = default;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerPos = GameObject.FindWithTag("Player").transform;
        _target = new Vector2(_playerPos.position.x, _playerPos.position.y);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(_rigidbody2D.position, _target, _speed * Time.deltaTime);
        if (transform.position.x == _target.x && transform.position.y == _target.y) Destroy(gameObject);
    }
}
