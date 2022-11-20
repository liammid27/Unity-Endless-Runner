using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noodles : Pickup
{
    //Initialising variables
    public bool jump2 = false;
    public int timesUsed = 0;
    public AudioClip collect;

    void Start()
    {
        //Gets refernces to audio sources
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = collect;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Increases the players jump height and plays sound
        if (other.gameObject.name == "Player")
        {
            GameManager.NoodlesUsed += TimesUsed;
            GetComponent<AudioSource>().Play();
            if (other.gameObject.GetComponent<Player>().jumpForce == 1800)
            {
                other.gameObject.GetComponent<Player>().jumpForce = 1200;
                other.gameObject.GetComponent<Player>().jumpForce += 600;
                
            }
            else
            {
                other.gameObject.GetComponent<Player>().jumpForce += 600;
                
            }
         
            
            foreach (Renderer r in GetComponentsInChildren<Renderer>())
                r.enabled = false;

            StartCoroutine(Deactivate(other));
        }
    }

    //Communicates with event system
    private void TimesUsed()
    {
        timesUsed++;
    }

    //Deactivates power up after 5 seconds
    IEnumerator Deactivate(Collider other)
    {
        yield return new WaitForSeconds(5f);
        other.gameObject.GetComponent<Player>().jumpForce = 1200;
        
    }
}
