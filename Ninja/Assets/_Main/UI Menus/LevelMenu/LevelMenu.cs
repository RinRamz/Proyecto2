using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class LevelMenu : MonoBehaviour
{
    public void StartLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
}
