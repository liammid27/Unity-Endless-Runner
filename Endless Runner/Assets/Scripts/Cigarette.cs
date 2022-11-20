using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cigarette : Pickup
{
    //Initialising variables
    public int timesUsed = 0;
    public AudioClip collect;

    void Start()
    {
        //Getting reference to audio sources
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = collect;
    }

    private void Update()
    {
        //Rotates cigarette 
        transform.Rotate(0, 0, 90 * Time.deltaTime);
        
    }


    private void OnTriggerEnter(Collider other)
    {
        //When the player collides with this pickup the can Jump boolean becomes true
        if (other.gameObject.name == "Player")
        {
            GameManager.CigarettesUsed += TimesUsed;
            other.gameObject.GetComponent<Player>().canShoot = true;
            
            gameObject.GetComponent<Renderer>().enabled = false;
            foreach (Renderer r in GetComponentsInChildren<Renderer>())
                r.enabled = false;

            GetComponent<AudioSource>().Play();

            StartCoroutine(Deactivate());
        }
        else if (other.gameObject.name == "Mr Paper")
        {
            other.gameObject.GetComponent<BossMovement>().bossHP--;
        }

    }
    //Communicates with event system
    private void TimesUsed()
    {
        timesUsed++;
    }

    //Deactivates cigarette after 10 seconds
    IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);

    }



}
