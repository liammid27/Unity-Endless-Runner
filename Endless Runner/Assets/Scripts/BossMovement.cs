using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BossMovement : MonoBehaviour
{
    //Initialising variables 
    public Rigidbody rb;
    Player player;
    public int bossHP = 3;
    UI ui;
    bool firstLevel = true;
    public int bossesDefeated = 0;

    private void Start()
    {
        //Getting refernce to player and UI
        player = GameObject.FindObjectOfType<Player>();
        ui = GameObject.FindObjectOfType<UI>();
    }

    public void FixedUpdate()
    {
        //Ensuring that boss speed is consistent with player speed
        var speed = player.speed;
        Vector3 forwardMove = transform.right * -speed * Time.deltaTime;
        rb.MovePosition(rb.position + forwardMove);
        ui.BossUI(this);

        //Calls scene switcher when boss is defeated
        if (this.bossHP <= 0)
        {
            GameManager.DefeatedAmount += BossesDefeated;
            SceneSwitcher();
        }

    }

    public void SceneSwitcher()
    {
        //Switches levels after the first boss is defeated and then randomises levels after every boss defeated afterwards
        if (this.gameObject.name == "Mr Paper(Clone)" && firstLevel == true)
        {
            SceneManager.LoadScene(sceneName: "Level 2");
            firstLevel = false;
        }
        else if (this.gameObject.name == "Mr Paper(Clone)" && firstLevel == false)
        {
            int ranNum = Random.Range(0, 2);

            switch (ranNum)
            {
                case 0:
                    SceneManager.LoadScene(sceneName: "Level 1");
                    break;
                case 1:
                    SceneManager.LoadScene(sceneName: "Level 2");
                    break;
                default:
                    SceneManager.LoadScene(sceneName: "Level 2");
                    break;
            }

        }
        else if (this.gameObject.name == "Printer Boss(Clone)")
        {
            int ranNum = Random.Range(0, 2);

            switch (ranNum)
            {
                case 0:
                    SceneManager.LoadScene(sceneName: "Level 2");
                    break;
                case 1:
                    SceneManager.LoadScene(sceneName: "Level 1");
                    break;
                default:
                    SceneManager.LoadScene(sceneName: "Level 1");
                    break;
            }

        }

    }

    //Used to communicate with event system
    private void BossesDefeated()
    {
        bossesDefeated++;
    }
}
