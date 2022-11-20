using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
   public void Restart()
    {
        //Sets score to 0 and reloads the game scene
        UI.scoreCount = 0;
        SceneManager.LoadScene(sceneName: "Level 1");
    }
}
