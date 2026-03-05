using UnityEngine;

public class Playerhealth : MonoBehaviour
{
    //Flytta detta till sitt egna script
    int health = 10;

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health < 0)
        {
            print("Aj jag dog");
        }
    }
}
