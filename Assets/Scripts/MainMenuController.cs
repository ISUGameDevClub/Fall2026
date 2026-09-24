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
        SceneManager.LoadScene("Start");
    }
}
