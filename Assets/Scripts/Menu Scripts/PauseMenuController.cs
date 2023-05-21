using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenu;
    public GameObject pauseButton;
    private PlayerController _player;


    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        PauseOnKeyboard();
        HidePauseButton();
    }
    public void PauseGame()
    {
        isPaused = true;
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0;
    }

    public void PauseOnKeyboard()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_player._isGameOver)
        {
            Debug.Log("Pause !");
            if (!isPaused)
            {
                isPaused = true;
                pauseMenu.SetActive(true);
                pauseButton.SetActive(false);
                Time.timeScale = 0;
            }
            else
            {
                ResumeGame();
                pauseButton.SetActive(true);
            }
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        isPaused = false;
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;
    }

    void HidePauseButton()
    {
        if (_player._isGameOver)
        {
            pauseButton.SetActive(false);
        }
    }
}
