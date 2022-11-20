using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    //Initialising variables
    Player player;

    void Start()
    {
        //Creates an instance of the player
        player = GameObject.FindObjectOfType<Player>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Checks if the player is what collided with the obstacle
        if(collision.gameObject.name == "Player")
        {
            //Kills the player when colliding with obstacle
            player.Die();
        }

    }

}
