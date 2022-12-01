using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    //These Booleans will help tell the difference between the collectibles object, each one has been named accordingly to what they are used foe
    public bool health, gem, speedBoast, jumpBoast;

    //This float store the magnitude of the force that the player will experience when collected the jumpBoast collectibles
    public float jumpBoastForce;


    //The code below will be run if another object gets inside the collision zone of the object
    public void OnTriggerEnter2D(Collider2D other)
    {
        //If the other object has the "Player" tag the code below will run
        if(other.tag == "Player")
        {
            //If this object has the health bool and the PO's currentHealth is less than maxHealth then the code below will run
            if(health == true && HealthController.instance.currentHealth < HealthController.instance.maxHealth)
            {
                //Debug.Log("Collect!");

                //The HealPlayer method from the HealthController class will be called
                HealthController.instance.HealPlayer();

                //This will call the PlaySound method from the Audio Manager, the sound number 3 is for collecting a collectible
                AudioManager.instance.PlaySound(3);

                //Then destroy the colelctible
                Destroy(gameObject);
            }
            //If this object has the gem bool then the code below will be run
            else if(gem == true)
            {
                //Debug.Log("Gem");

                //The vairable scoreGained form the class LevelManager will be set to 100
                LevelManager.instance.scoreGained = 100;
                //The GainScore method from the class Manager will be called
                LevelManager.instance.GainScore();

                //This will call the PlaySound method from the Audio Manager, the sound number 3 is for collecting a collectible
                AudioManager.instance.PlaySound(3);

                //Then destroy the colelctible
                Destroy(gameObject);
            }
            //If this object has the jumpBoast bool then the code below will run
            else if(jumpBoast == true)
            {
                //Debug.Log("Jump");

                //Apply the jumpBoastForce to the referece rigidbody of the player from the PlayerController class
                PlayerController.instance.theRB.velocity = new Vector2(PlayerController.instance.theRB.velocity.x, jumpBoastForce);

                //This will call the PlaySound method from the Audio Manager, the sound number 3 is for collecting a collectible
                AudioManager.instance.PlaySound(3);

                //Then destroy the colelctible
                Destroy(gameObject);
            }
        }
        
    }
}
