using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyDrink : Pickup
{
    //Initialising variables
    public int energyDrank = 0;
    public int timesUsed = 0;
    public AudioClip collect;

    void Start()
    {
        //Getting reference to audio sources
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = collect;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Increases the player speed after colliding with energy drink
        if (other.gameObject.name == "Player")
        {
            GameManager.EnergyDrinkUsed += TimesUsed;
            other.gameObject.GetComponent<Player>().speed += 5f;
            energyDrank = 1;
            gameObject.GetComponent<Renderer>().enabled = false;
            GetComponent<AudioSource>().Play();
            StartCoroutine(Deactivate(other));

        }
    }

    //Communicating with event system
    private void TimesUsed()
    {
        timesUsed++;
    }

    //Deactivates energy drink speed boost after 3 seconds
    IEnumerator Deactivate(Collider other)
    {
        yield return new WaitForSeconds(3f);
        other.gameObject.GetComponent<Player>().speed -= 5f;
        energyDrank = 0;
        
    }    
}
