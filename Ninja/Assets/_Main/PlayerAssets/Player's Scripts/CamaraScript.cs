using UnityEngine;

namespace Ninja
{
    public class CamaraScript : MonoBehaviour
    {
        [SerializeField] private GameObject player = default;
        void Update()
        {
            Vector3 position = transform.position;
            position.x = player.transform.position.x;
            transform.position = position;
        }
    }
}
