using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CigaretteProjectile : MonoBehaviour
{
    //Decreases the bosses HP if it is hit with cigarette projectile 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Mr Paper(Clone)")
        {
            other.gameObject.GetComponent<BossMovement>().bossHP--;
        }
        else if (other.gameObject.name == "Printer Boss(Clone)")
        {
            other.gameObject.GetComponent<BossMovement>().bossHP--;
        }

    }
}
