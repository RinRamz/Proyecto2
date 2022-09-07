using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shooter : EnemyManager
{

    private void Awake()
    {
        HP = MaxHP;
    }
    // Update is called once per frame
    void Update()
    {
    }

    public override void Attack()
    {

    }

    public override void getDamaged(int damage)
    {
        HP -= damage;

        if (HP <= 0)
        {
            Die();
        }
    }

    public override void Die()
    {
        Debug.Log("Died");
    }
}
