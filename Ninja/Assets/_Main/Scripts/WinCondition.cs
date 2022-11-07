using UnityEngine;

namespace Ninja
{
    public class WinCondition : MonoBehaviour
    {
        [SerializeField] private GameObject _winCanvas = default;
        [SerializeField] private GameObject _mainCanvas = default;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Time.timeScale = 0f;
            _winCanvas.SetActive(true);
            _mainCanvas.SetActive(false);
        }
    }
}
