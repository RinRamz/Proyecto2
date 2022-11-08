using UnityEngine;

namespace Ninja
{
    public class EnemyRangeOfSight : MonoBehaviour
    {
        private bool _inRangeofSight = default;

        public bool InRangeofSight => _inRangeofSight;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                _inRangeofSight = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                _inRangeofSight = false;
            }
        }
    }
}
