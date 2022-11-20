using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    //Initialising variable
    [SerializeField] float pickupTurnSpeed = 90f;
   


    private void OnTriggerEnter(Collider other)
    {
        //Checks if pick up is spawned in an obstacle and deletes it
        if (other.gameObject.GetComponent<Obstacle>() != null)
        {
            Destroy(gameObject);
            return;
        }



    }

    void Update()
    {
        //Rotates the pick up
        transform.Rotate(0, pickupTurnSpeed * Time.deltaTime, 0);
    }
}
