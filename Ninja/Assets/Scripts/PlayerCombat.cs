using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    Animator animator;

    public bool isAttacking;
    int numAttacks = 2;

    public float starTimeBtwAttack = 0.3f;
    float timeBtwAttack = 0f;
    float attackRate = 4f;
    float nextAttackTime = 0f;

    public float attackRangeH;
    public float attackRangeW;
    public float attackRange2H;
    public float attackRange2W;

    [SerializeField] private Transform shortSword;
    [SerializeField] private Transform longSword;
    [SerializeField] private LayerMask enemies;

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
                Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(shortSword.position, new Vector2(attackRangeW, attackRangeH),0, enemies);
                Collider2D[] hitEnemies2 = Physics2D.OverlapBoxAll(longSword.position, new Vector2(attackRange2W, attackRange2H), 0, enemies);
                if (hitEnemies.Length <= 0)
                {
                    for (int i = 0; i < hitEnemies2.Length; i++)
                    {
                        Debug.Log("longsword hit");
                    }
                }
                else
                {
                    for (int i = 0; i < hitEnemies.Length; i++)
                    {
                        Debug.Log("shortsword hit");
                    }
                }
                
            }
            else if (Input.GetButtonDown("Fire1") && numAttacks == 1)
            {
                animator.SetTrigger("isAttacking2");
                numAttacks = 0;
            }

            if (isAttacking)
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(shortSword.position, new Vector3(attackRangeW, attackRangeH, 1));
        Gizmos.DrawWireCube(longSword.position, new Vector3(attackRange2W, attackRange2H, 1));
    }

}
