using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Initialising all event systems 
    public delegate void ObjectPassed();
    public static event ObjectPassed PassedObjectScore;

    public delegate void PickUp1Activated();
    public static event PickUp1Activated EnergyDrinkUsed;

    public delegate void PickUp2Activated();
    public static event PickUp2Activated NoodlesUsed;

    public delegate void PickUp3Activated();
    public static event PickUp3Activated CigarettesUsed;

    public delegate void Boss1Spawned();
    public static event Boss1Spawned PaperBossSpawned ;

    public delegate void Boss2Spawned();
    public static event Boss2Spawned PrinterBossSpawned;

    public delegate void BossesDefeated();
    public static event BossesDefeated DefeatedAmount;

    //Counts the amount of obstacles passed
    public void objectPassedCounter()
    {
        if (PassedObjectScore != null)
            PassedObjectScore();
    }

    //Counts the amount of energy drinks used
    public void energyDrinksUsed()
    {
        if (EnergyDrinkUsed != null)
            EnergyDrinkUsed();
    }
    //Counts the amount of noodles used
    public void noodlesUsed()
    {
        if (NoodlesUsed != null)
            NoodlesUsed();
    }
    //Counts the amount of cigarettes used
    public void cigarettesUsed()
    {
        if (CigarettesUsed != null)
            CigarettesUsed();
    }
    //Counts the amount of paper bosses spawned
    public void paperBossSpawned()
    {
        if (PaperBossSpawned != null)
            PaperBossSpawned();
    }
    //Counts the amount of printer bosses spawned 
    public void printerBossSpawned()
    {
        if (PrinterBossSpawned != null)
            PrinterBossSpawned();
    }
    //Counts the amount of bosses defeated 
    public void bossesDefeated()
    {
        if (DefeatedAmount != null)
            DefeatedAmount();
    }


}
