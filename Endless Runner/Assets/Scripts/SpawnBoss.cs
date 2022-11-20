using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    //Initialising variables
    public GameObject Boss;
    Vector3 spawnPoint;
    public bool canSpawn = true;
    Player player;
    public int paperTimesSpawned = 0;
    public int printerTimesSpawned = 0;

    //Gets reference to player and spawns boss at appropriate time
    private void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
        StartCoroutine(Spawn());
    }

    //Controls which bosses spawn at which times
    public IEnumerator Spawn()
    {
        yield return new WaitForSeconds(3f);
        if (canSpawn == true)
        {
            if (Boss.gameObject.name == "Mr Paper(Clone)")
            {
                GameManager.PaperBossSpawned += PaperTimesSpawned;
            }
            else if(Boss.gameObject.name == "Printer Boss(Clone)")
            {
                GameManager.PrinterBossSpawned += PrinterTimesSpawned;
            }
            spawnPoint = this.transform.position;
            Instantiate(Boss, spawnPoint, Quaternion.Euler(0, 90, 0));
            canSpawn = false;
        }
        
    }

    private void PaperTimesSpawned()
    {
        paperTimesSpawned++;
    }
    private void PrinterTimesSpawned()
    {
        printerTimesSpawned++;
    }
}
