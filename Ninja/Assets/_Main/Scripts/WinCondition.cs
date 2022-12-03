using UnityEngine;

namespace Ninja
{
    public class WinCondition : MonoBehaviour
    {
        [SerializeField] private GameObject _winCanvas = default;
        [SerializeField] Animator _canvasWinAnimator = default;
        [SerializeField] private GameObject _player = default;
        [SerializeField] private GameObject _mainCanvas = default;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                _player.SetActive(false);
                _winCanvas.SetActive(true);
                _canvasWinAnimator.SetTrigger("WinTrigger");
                _mainCanvas.SetActive(false);
            }
        }
    }
}
