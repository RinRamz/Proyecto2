using UnityEngine;

namespace Ninja
{
    public class EnemyCombatManager : MonoBehaviour
    {
        [SerializeField] private float _damage = default;

        public float Damage => _damage;
    }
}
