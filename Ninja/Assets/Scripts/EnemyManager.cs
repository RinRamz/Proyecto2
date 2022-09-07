using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyManager : MonoBehaviour
{
    public int HP;
    public int MaxHP;
    public float speed;

    public float damage;

    public abstract void getDamaged(int damage);
    public abstract void Attack();

    public abstract void Die();

}
