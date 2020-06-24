using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public string mainMenuLevel;
    public GameObject pauseMenu;
    public GameObject soundEffects;
    public GameObject gameMusic;
    public GameObject soundsOn;
    public GameObject soundsOff;
    public GameObject musicOn;
    public GameObject musicOff;
    public GameObject pauseButton;

        public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        FindObjectOfType<GameManager>().Reset();
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void QuitToMain()
    {
        Time.timeScale = 1f;
        Application.LoadLevel(mainMenuLevel);
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
    }
    
    public void ToggleSoundsOff()
    {
        soundEffects.SetActive(false);
        soundsOff.SetActive(true);
        soundsOn.SetActive(false);

    }

    public void ToggleSoundsOn()
    {
        soundEffects.SetActive(true);
        soundsOff.SetActive(false);
        soundsOn.SetActive(true);

    }

    public void MusicSoundsOff()
    {
        gameMusic.SetActive(false);
        musicOff.SetActive(true);
        musicOn.SetActive(false);

    }

    public void MusicSoundsOn()
    {
        gameMusic.SetActive(true);
        musicOff.SetActive(false);
        musicOn.SetActive(true);

    }
}
