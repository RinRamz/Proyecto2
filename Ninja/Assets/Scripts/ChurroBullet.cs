using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ChurroBullet : MonoBehaviour
{
    Rigidbody2D rb;
    Transform playerPos;
    float _speed = 20f;
    Vector2 target;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerPos = GameObject.FindWithTag("Player").transform;
        target = new Vector2(playerPos.position.x, playerPos.position.y);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(rb.position, target, _speed * Time.deltaTime);
        DestroyBullet();
    }

    void DestroyBullet()
    {
        if (transform.position.x == target.x && transform.position.y == target.y) Destroy(gameObject);
    }

 
}
