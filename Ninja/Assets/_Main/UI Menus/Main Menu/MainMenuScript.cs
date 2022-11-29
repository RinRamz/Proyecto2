using System.Collections;
using UnityEngine;

namespace Ninja
{
    public class MainMenuScript : MonoBehaviour
    {
        [SerializeField] private Animator _animator = default;
        [SerializeField] private GameObject _levelMenu = default;
        [SerializeField] private GameObject _mainMenu = default; 

        public void PlayButton()
        {
            _animator.SetTrigger("PlayButton");
            StartCoroutine(WaitForAnim());
        }

        private IEnumerator WaitForAnim()
        {
            yield return new WaitForSeconds(1.7f);
            _mainMenu.SetActive(false);
            _levelMenu.SetActive(true);
        }
    }
}
