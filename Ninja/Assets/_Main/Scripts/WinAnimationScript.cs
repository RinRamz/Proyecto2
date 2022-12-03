using UnityEngine;

public class WinAnimationScript : MonoBehaviour
{
    [SerializeField] private GameObject _winUI = default;

    public void OnAnimationEnd()
    {
        _winUI.SetActive(true);
    }
}
