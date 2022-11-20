using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    //Initialising variables
    Player player;

    void Start()
    {
        //Creates an instance of the player
        player = GameObject.FindObjectOfType<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Checks if the player is what collided with the obstacle
        if (other.gameObject.name == "Player")
        {
            //Kills the player when colliding with obstacle
            player.Die();
        }
    }
   
}
