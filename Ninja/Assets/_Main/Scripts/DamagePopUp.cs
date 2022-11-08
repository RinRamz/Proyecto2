using UnityEngine;
using TMPro;

namespace Ninja
{
    public class DamagePopUp : MonoBehaviour
    {
        private float _disappearTimer = default;
        private TextMeshPro _textMeshPro = default;
        private Color _textColor = default;

        private void Awake()
        {
            _textMeshPro = GetComponent<TextMeshPro>();  
            _textColor = _textMeshPro.color;
            _disappearTimer = 0.5f;
        }

        private void Update()
        {
            _disappearTimer -= Time.deltaTime;

            if (_disappearTimer > 0.25f)
            {
                float increaseScaleAmount = 1f;
                transform.localScale += Vector3.one * increaseScaleAmount * Time.deltaTime;
            }
            else
            {
                float decreaseScaleAmount = 1f;
                transform.localScale -= Vector3.one * decreaseScaleAmount * Time.deltaTime;
            }

            if (_disappearTimer < 0)
            {
                float disappearSpeed = 6f;
                _textColor.a -= disappearSpeed * Time.deltaTime;
                _textMeshPro.color = _textColor;
                if (_textColor.a <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
