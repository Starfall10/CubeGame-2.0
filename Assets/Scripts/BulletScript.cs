using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // This variable store the rigidbody component that will enable the bullet object to move
    public Rigidbody2D theRB;


    // This function will check if the bullet object has collide with any other box collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        // if collided with an object with tag "Player" then the following code will be run
        if(other.tag == "Player")
        {
            //The bullet object will be destroy on collision with the PO
            Destroy(gameObject);
            //Then the DealDamage() method from the HealthController object will be call.
            HealthController.instance.DealDamage();
        }
        // if collided with an object with tag "Ground" then the following code will be run
        else if (other.tag == "Ground")
        {
            //The bullet object will be destroy on collision with the ground.
            Destroy(gameObject);
        }
    }
}


