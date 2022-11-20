using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UI2 : MonoBehaviour
{
    //Initialising variables
    [SerializeField] Text deathText;
    
    void Start()
    {
        //Displays player score on the death screen
        deathText.text = "Your Score Was: " + UI.scoreCount;
    }

}
