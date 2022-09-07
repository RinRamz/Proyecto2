using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    Animator animator;
  
    public bool isAttacking;
    public int combo;

    int damage = 20;

    private void Awake()
    {
        isAttacking = false;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Combos();
    }
    public void Combos()
    {
        if (Input.GetButtonDown("Fire1") && !isAttacking)
        {
            isAttacking = true;
            animator.SetTrigger("isAttacking" + combo);
        }
    }

    public void startCombo()
    {
        isAttacking = false;
        if (combo < 2)
        {
            combo++;
        }
    }

    public void finishCombo()
    {
        isAttacking = false;
        combo = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemies"))
        {
            if (combo == 0)
            {
                collision.GetComponent<Enemy_Shooter>().getDamaged(damage);
            }
            else if (combo == 1)
            {
                collision.GetComponent<Enemy_Shooter>().getDamaged(Mathf.RoundToInt(damage * 1.5f));
            }
        }
        
    }
}
