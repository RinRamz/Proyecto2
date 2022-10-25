using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ninja
{
    public class PauseMenu : MonoBehaviour
    {
        public void Resume()
        {
            Time.timeScale = 1f;
        }

        public void Pause()
        {
            Time.timeScale = 0f;
        }

        public void Menu()
        {
            SceneManager.LoadScene("MainMenu");
            Time.timeScale = 1f;
        }

        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Time.timeScale = 1f;
        }
    }

}