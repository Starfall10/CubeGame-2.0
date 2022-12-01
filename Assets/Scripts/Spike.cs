using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spike : MonoBehaviour
{
    //This built method will check if there is a collider from another object 
    private void OnTriggerEnter2D(Collider2D other)
    {
        //If the other collider is of the player then
        if(other.tag == "Player")
        {
            //Debug.Log("Spike!");

            //Calling the DealDamage() function of the HealthController() class.
            HealthController.instance.DealDamage();
        }
    }
}