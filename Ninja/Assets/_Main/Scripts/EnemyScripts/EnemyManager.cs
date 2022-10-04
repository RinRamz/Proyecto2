using UnityEngine;

namespace Ninja
{
    public class EnemyManager : Singleton<EnemyManager>
    {
        public void Move(Transform currentPos, Transform playerPos, Rigidbody2D rigidbody2D, float movementSpeed)
        {
            Vector2 target = new Vector2(playerPos.position.x, rigidbody2D.position.y);
            Vector2 newPos = Vector2.MoveTowards(currentPos.position, target, movementSpeed * Time.fixedDeltaTime);
            rigidbody2D.MovePosition(newPos);
        }

        public float AttackRanged(float nextAttackTime, float attackSpeed, GameObject bullet)
        {
            if (Time.time >= nextAttackTime)
            {
                Instantiate(bullet, transform.position, Quaternion.identity);
                nextAttackTime = Time.time + 1f / attackSpeed;
            }
            return nextAttackTime;
        }

        public float AttackMelee(float nextAttackTime, float attackSpeed, Animator animator)
        {
            if (Time.time >= nextAttackTime)
            {
                animator.Play("Attack_EnemyBasic");
                nextAttackTime = Time.time + 1f / attackSpeed;
            }
            return nextAttackTime;
        }

        public float GetDamaged(int damage, float hp)
        {
            hp -= damage;
            return hp;
        }

        public void CheckIfDied(float hp, GameObject gameObject)
        {
            if (hp <= 0)
            {
                gameObject.SetActive(false);
            }
            else
            {
                return;
            }
        }
    }
}
