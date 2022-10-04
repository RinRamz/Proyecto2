using UnityEngine;

namespace Ninja
{
    public class CamaraScript : MonoBehaviour
    {
        [SerializeField] private GameObject _player = default;
        
        void Update()
        {
            Vector3 position = transform.position;
            position.x = _player.transform.position.x;
            transform.position = position;
        }
    }
}
