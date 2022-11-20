using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //Initialising variables
    public static bool IsPaused = false;
    public GameObject pauseMenu;

    //Pauses the game when necessary
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    //Resumes the game
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }

    //Pauses the game
    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }

    //Opens the main menu scene
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        UI.scoreCount = 0;
        SceneManager.LoadScene(sceneName: "Main Menu");
    }
}
