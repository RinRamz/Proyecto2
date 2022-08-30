using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    Animator animator;

    public bool isAttacking;
    int numAttacks = 2;

    public float starTimeBtwAttack = 0.3f;
    public float timeBtwAttack = 0f;
    float attackRate = 4f;
    float nextAttackTime = 0f;
    private void Awake()
    {
        isAttacking = false;
        animator = GetComponent<Animator>();
    }
    
    void Update()
    {
       Attack();
    }
    void Attack()
    {

        if (Time.time >= nextAttackTime)
        {
            if (Input.GetButtonDown("Fire1") && numAttacks == 2)
            {
                animator.SetTrigger("isAttacking");
                isAttacking = true;
                numAttacks = 1;
                nextAttackTime = Time.time + 1f / attackRate;
            }
            else if (Input.GetButtonDown("Fire1") && numAttacks == 1)
            {
                animator.SetTrigger("isAttacking2");
                numAttacks = 0;
            }

            if(isAttacking)
            {
                timeBtwAttack -= Time.deltaTime;
            }
            else
            {
                timeBtwAttack = starTimeBtwAttack;
            }

            if (timeBtwAttack <= 0)
            {
                animator.SetBool("isAttacking", false);
                animator.SetBool("isAttacking2", false);
                isAttacking = false;
                numAttacks = 2;
            }


        }

    }
}
