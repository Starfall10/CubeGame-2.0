using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandDamage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        //If the collided object has the "Player" tag then
        if (other.gameObject.tag == "Player")
        {
            
            Debug.Log("Hit player");

            //The DealDamage() method from the HealthController class will be call to damage the player
            HealthController.instance.DealDamage();
        }
    }
}
