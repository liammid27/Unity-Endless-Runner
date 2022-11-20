using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Initialising variables
    [SerializeField] Transform player;
    [SerializeField] Vector3 difference;

    void Start()
    {
        //Calculating the difference in position from the camera and the player
        difference = transform.position - player.position;
    }
    
    void Update()
    {
        //Creating a new object for the camera to set its position to on update which allows the camera to constantly follow the player
        Vector3 targetPos = player.position + difference;
        targetPos.x = 0;
        transform.position = targetPos;
    }

}
    
        
    

