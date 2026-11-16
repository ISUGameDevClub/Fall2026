using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
        public void goToCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void goToStart()
    {
        SceneManager.LoadScene("Lvl.1 Alley");
    }

    public void goToSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
