using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace Ninja
{
    public class VochoSoundController : MonoBehaviour
    {
        [SerializeField] private AudioClip[] _audioClips;
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.CompareTag("Player") && collision.collider.transform.position.y > transform.position.y)
            {
                _audioSource.clip = _audioClips[1];
                _audioSource.Play();
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("PlayerSword"))
            {
                _audioSource.clip = _audioClips[0];
                _audioSource.Play();
                StartCoroutine(CarAlarm());
            }
        }

        private IEnumerator CarAlarm()
        {
            yield return new WaitForSeconds(2.8f);
            _audioSource.Pause();
        }
    }
}
