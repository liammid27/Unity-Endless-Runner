using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    //Initialising variables
    public static int scoreCount;
    public static UI userInterface;

    [SerializeField] Text scoreText;
    [SerializeField] Text jumpText;
    [SerializeField] Text bossText;
    public int _scoreCount;
    public Text shootText;
   
  

    public void AddScore()
    {
        //Increases score when called
        scoreCount++;
        
    }

    private void Awake()
    {
        //Calls the UI while the game is being loaded
        userInterface = this;
        
    }

    void Update()
    {
        //Sets the score text
        scoreText.text = "SCORE: " + scoreCount;
        GameManager.PassedObjectScore += AddScore;
        
    }

    //updates Ui to show that player can jump
    public void JumpUI(Player player)
    {
        if (player.jumpForce == 1800)
        {
            jumpText.text = "DOUBLE JUMP: AVAILABLE";
            jumpText.color = Color.green;
        }
        else
        {
            jumpText.text = "DOUBLE JUMP: UNAVAILABLE";
            jumpText.color = Color.red;
        }
    }

    //updates Ui to show that player can shoot
    public void ShootUI(Player player)
    {
        if (player.canShoot == true)
        {
            shootText.text = "SHOOT: AVAILABLE";
            shootText.color = Color.green;
        }
        else
        {
            shootText.text = "SHOOT: UNAVAILABLE";
            shootText.color = Color.red;
        }
    }

    //updates Ui to show that player the bosses health 
    public void BossUI(BossMovement boss)
    {
        int bHPText = boss.gameObject.GetComponent<BossMovement>().bossHP;

        if (boss.gameObject.name == "Mr Paper(Clone)")
        {
            bossText.text = "Unfinished Essay has " + bHPText + "HP left";
        }
        else if (boss.gameObject.name == "Printer Boss(Clone)")
        {
            bossText.text = "Malfunctioning Printer has " + bHPText + "HP left";
        }

    }
        


}
