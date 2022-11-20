using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Plays first level when game is started
    public void PlayGame()
    {
        SceneManager.LoadScene(sceneName: "Level 1");
    }

    //shows the player stats scene when the button is clicked
    public void ViewStats()
    {
        SceneManager.LoadScene(sceneName: "View Stats");
    }

    //Allows the player to quit the game when the button is clicked
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}
