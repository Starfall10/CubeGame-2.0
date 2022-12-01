using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    //Creating an instance of the class to allow other classes to reference to variables and methods of this class
    public static HealthController instance;

    //maxHealth tells what is the maximum health that the player can have
    public float maxHealth = 100f;
    //the int currentHealth will be use to keep track of the player's health at all time
    public float currentHealth;

    //This is called when the script instance is loaded
    private void Awake()
    {
        //Making instance equal to this script/class
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Upon starting level, the player's health will be set to max
        currentHealth = maxHealth;
    }

    //This method will deal damage to the player
    public void DealDamage()
    {
        //To do this the currentHealth int will be decrease by 1 each time the method is called
        currentHealth -= Random.Range(1, 5);

    }


    //This method will check if the player has died and return a value for it
    public bool DeathCheck()
    {
        //check if the player's health is less than or equal to 0
        if (currentHealth <= 0)
        {
            //return true is yes
            return (true);
        }
        else
        {
            //return false is not
            return (false);
        }
    }

    //This method will heal the player when called
    public void HealPlayer()
    {
        //To heal the player, simply increase the currentHealth int by 1
        currentHealth++;

    }
}
