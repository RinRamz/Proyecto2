using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Animator _animator = default;
    [SerializeField] private Animator _loadingAnimator = default;

    public void StartLevel(int levelIndex)
    {
        StartCoroutine(LoadLevel(levelIndex));
    }

    private IEnumerator LoadLevel(int levelIndex)
    {
        AsyncOperation _operation = SceneManager.LoadSceneAsync(levelIndex);
        
        if (_operation.progress > 0.7f)
        {
            _loadingAnimator.SetTrigger("Completed");
            _animator.SetTrigger("Start");
            yield return null;
        }
    }
}
