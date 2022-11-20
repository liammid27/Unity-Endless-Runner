using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    //Initialising variables
    [SerializeField] GameObject platform;
    Vector3 nextSpawnPoint;

    //Created a list of platform prefabs
    List<GameObject> prefabList = new List<GameObject>();
    public GameObject Prefab1;
    public GameObject Prefab2; 
    public GameObject Prefab3;

    public GameObject Gap;

    public void SpawnPlatform(bool spawn)
    {
        //Fills list with prefabs and gets random number
        prefabList.Add(Prefab1);
        prefabList.Add(Prefab2);
        prefabList.Add(Prefab3);
        int platformPrefabIndex = Random.Range(0, 3);

        

        //Random number chooses a prefab at random and spawns at the the end of the last platform
        GameObject temp = Instantiate(prefabList[platformPrefabIndex], nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;

        if (spawn)
        {
            temp.GetComponent<Platform>().SpawnObstacle();
            temp.GetComponent<Platform>().SpawnPickup();
        }
    }

    void Start()
    {
        // for loop that spawns 8 platforms at a time
        for (int i = 0; i < 8; i++)
        {
            if ( i < 3)
            {
                SpawnPlatform(false);
            }
            else
            {
                SpawnPlatform(true);
            }
            
        }

    }

}
