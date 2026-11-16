using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject optionsPanel;
    [SerializeField] Slider MusicSlider;
    [SerializeField] Slider SFXSlider;
    private float MusicVolume; //values between 0 and 1
    private float SFXVolume;


    private bool paused = false;
    void Awake()
    {
        canvas.enabled = false;
        optionsPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame && !paused)
        {
            pauseGame();
        }
        else if (Keyboard.current.escapeKey.wasPressedThisFrame && paused)
        {
            unpauseGame();
        }
    }
    void pauseGame()
    {
        Time.timeScale = 0f;
        canvas.enabled = true;
        paused = true;
    }
    public void unpauseGame()
    {
        canvas.enabled = false;
        paused = false;
        closeOptions();
        Time.timeScale = 1f;
    }
    public void quitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void openOptions()
    {
        optionsPanel.SetActive(true);
    }
    public void closeOptions()
    {
        optionsPanel.SetActive(false);
    }
    public void updateMusicVolume()
    {
        MusicVolume = MusicSlider.value;
    }
    public void updateSFXVolume()
    {
        SFXVolume = SFXSlider.value;
    }
    public float getMusicVolume()
    {
        return MusicVolume;
    }
    public float getSFXVolume()
    {
        return SFXVolume;
    }
    public bool isPaused()
    {
        return paused;
    }
}
