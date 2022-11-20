using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    //Initialising variables
    PlatformSpawner platformSpawner;
    [SerializeField] GameObject pickupPrefab; // Will later create list of 3 of pick ups like the obstacle list below

    //Creating a list of obstacle prefabs
    List<GameObject> obstaclePrefabList = new List<GameObject>();
    [SerializeField] GameObject obstaclePrefab1;
    [SerializeField] GameObject obstaclePrefab2;
    [SerializeField] GameObject obstaclePrefab3;

    List<GameObject> pickupPrefabList = new List<GameObject>();
    [SerializeField] GameObject pickupPrefab1;
    [SerializeField] GameObject pickupPrefab2;
    [SerializeField] GameObject pickupPrefab3;



    void Start()
    {
        //Creates instance of platform spawner
        platformSpawner = GameObject.FindObjectOfType<PlatformSpawner>();
        
    }

    private void OnTriggerExit(Collider other)
    {
        //Spawns another platform at the end, adds one score to player and destroys the last platform after 2 seconds
        if (other.gameObject.name == "Player")
        {
            UI.userInterface.AddScore();
            platformSpawner.SpawnPlatform(true);
            Destroy(gameObject, 8);
        }
        
    }

   public void SpawnObstacle()
    {
        //Adds obstacle prefabs to the list and gets a random number
        obstaclePrefabList.Add(obstaclePrefab1);
        obstaclePrefabList.Add(obstaclePrefab2);
        obstaclePrefabList.Add(obstaclePrefab3);
        int obstaclePrefabIndex = Random.Range(0, 3);

        //Gets random number and assigns it to spawn point on the platform
        int obstacleIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleIndex).transform;

        //Spawns random obstacles at "random" positions on the platform
        Instantiate(obstaclePrefabList[obstaclePrefabIndex], spawnPoint.position, Quaternion.identity, transform);
    }

    public void SpawnPickup()
    {
        pickupPrefabList.Add(pickupPrefab1);
        pickupPrefabList.Add(pickupPrefab2);
        pickupPrefabList.Add(pickupPrefab3);

        //Gets random boolean to determine if pick up should spawn
        bool randomBool = (Random.Range(0, 2) == 0);
        int pickupPrefabIndex = Random.Range(0, 3);

        //Spawns pick ups but added for loop incase i want to increase the amount of pick ups per platform at a later stage
        if (randomBool == true)
        {
            for (int i = 0; i < 1; i++)
            {
                GameObject temp = Instantiate(pickupPrefabList[pickupPrefabIndex], transform);
                temp.transform.position = RandomColliderPoint(GetComponent<Collider>());
            }
        }
        
    }

    Vector3 RandomColliderPoint (Collider collider)
    {
        //Choosing a random position for every axis within a collider
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x), 
            Random.Range(collider.bounds.min.y, collider.bounds.max.y), 
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );
        //Makes sure random point is on the collider
        if(point != collider.ClosestPoint(point))
        {
            point = RandomColliderPoint(collider);
        }

        //Make all pick ups spawn at y: 1 so that they are right above the platform
        point.y = 1;
        return point;
    }
}
