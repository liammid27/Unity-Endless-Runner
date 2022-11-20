using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrinterMove : MonoBehaviour
{
    //Initialising variables
    public Rigidbody rb;
    Player player;
    
    //Gets reference to player 
    private void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
    }

    //Moves the printer at the same speed as the player
    public void FixedUpdate()
    {
        var speed = player.speed;
        Vector3 forwardMove = transform.right * -speed * Time.deltaTime;
        rb.MovePosition(rb.position + forwardMove);

    }
}
