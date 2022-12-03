using System.Collections;
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

        public void ReturnPos(Transform transform, Vector2 initialPos, Rigidbody2D rigidbody2D, float movementSpeed)
        {
            Vector3 scale = transform.localScale;
            scale.x = transform.position.x > initialPos.x ? 1f : -1f;
            transform.localScale = scale;
            Vector2 target = new Vector2(initialPos.x, rigidbody2D.position.y);
            Vector2 newPos = Vector2.MoveTowards(transform.position, target, movementSpeed * Time.fixedDeltaTime);
            rigidbody2D.MovePosition(newPos);
        }

        public void Patrol(Transform currentPos, Rigidbody2D rigidbody2D, float movementSpeed, float moveDistance)
        {
            Vector2 target = new Vector2(rigidbody2D.position.x + moveDistance, rigidbody2D.position.y);
            Vector2 newPos = Vector2.MoveTowards(currentPos.position, target, movementSpeed * Time.fixedDeltaTime);
            rigidbody2D.MovePosition(newPos);
        }

        public void Flip(Transform transform, Transform playerPos)
        {
            Vector3 scale = transform.localScale;
            scale.x = playerPos.position.x > transform.position.x ? -1f : 1f;
            transform.localScale = scale;
        }

        public float FlipPatrol(Transform localScale, float moveDistance)
        {
            moveDistance *= -1;
            Vector3 scale = localScale.localScale;
            scale.x = moveDistance > 0 ? -1f : 1f;
            localScale.localScale = scale;
            return moveDistance;
        }

        public float GetDamaged(int damage, float hp, GameObject crittext, bool isCrit, Transform transform, Transform playerPos)
        {
            Vector3 spawnPos = new Vector3(transform.position.x + 1f, transform.position.y + 1f);

            if (playerPos.position.x > transform.position.x)
            {
                spawnPos.x = transform.position.x - 1f;
            }

            if (isCrit)
            {
                Instantiate(crittext, spawnPos, Quaternion.identity);
            }
            hp -= damage;
            return hp;
        }

        public void CheckIfDied(float hp, GameObject gameObject, Animator animator, string animName)
        {
            if (hp <= 0)
            {
                StartCoroutine(WaitForAnim(animator, animName, gameObject));
            }
            else
            {
                return;
            }
        }

        private IEnumerator WaitForAnim(Animator animator, string animName, GameObject gameObject)
        {
            animator.Play(animName);
            yield return new WaitForSeconds(0.3f);
            gameObject.SetActive(false);
        }
    }
}
