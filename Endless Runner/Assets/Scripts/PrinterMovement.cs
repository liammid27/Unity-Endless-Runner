using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrinterMovement : MonoBehaviour
{
    //Initialising variables
    public GameObject printer;
    public GameObject middleSpawn;
    public GameObject leftSpawn;
    public GameObject rightSpawn;
    bool isMoveable = true;
    bool canShoot = true;

    public GameObject Projectile;
    public GameObject Spawner;

    int prevnum = -1;
    int num;

    //Allows printer to move and shoot
    private void FixedUpdate()
    {
        if (isMoveable == true)
        {
            Move();
        }
        Shoot();
       
    }
   
    //Controls printer movement
    public void Move()
    {
        do
        {
            num = Random.Range(0, 3);
        }while (num == prevnum);


        if (num == 0)
        {
            printer.transform.position = leftSpawn.transform.position;
        }
        else if (num == 1)
        {
            printer.transform.position = middleSpawn.transform.position;
        }
        else if (num == 2)
        {
            printer.transform.position = rightSpawn.transform.position;
        }

        prevnum = num;
        isMoveable = false;
        StartCoroutine(MoveCooldown());
    }

    //Controls printer shooting
    public void Shoot()
    {
        if (canShoot == true)
        {
            Instantiate(Projectile, Spawner.transform);
            canShoot = false;
            StartCoroutine(ShootCooldown());
        }
        else
            return;
    }

    public IEnumerator MoveCooldown()
    {
        yield return new WaitForSeconds(5f);
        isMoveable = true;
    }

    public IEnumerator ShootCooldown()
    {
        yield return new WaitForSeconds(2f);
        canShoot = true;
    }

}
