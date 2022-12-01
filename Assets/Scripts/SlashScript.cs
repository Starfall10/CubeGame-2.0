using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashScript : MonoBehaviour
{
    //This float will store the time that the slash will be on the screen 
    public float timeToLive;

    //This method will be call once when the script is first instantiate
    void Awake()
    {
        //This will destroy the slash gameObject after the time set from time to live
        Destroy(gameObject, timeToLive);
    }

    //This method will check if any other object 
    private void OnTriggerEnter2D(Collider2D other)
    {
        //If the other object is an emeny then
        if(other.tag == "Enemy")
        {
            //Debug.Log("Hit Enemy!");

            //Destroy that other object, affectively killing the enemy
            other.gameObject.SetActive(false);

            //Destroy this slash 
            Destroy(gameObject);

            //Then the game will reward score to the player
            //So the scoreGained variable from the LevelManager class by 300
            LevelManager.instance.scoreGained = 300;
            //Then call the GainScore() method from the LevelManager class
            LevelManager.instance.GainScore();
        }

        if (other.tag == "Boss")
        {
            //Debug.Log("Hit boss");

            Boss.instance.bossCurrentHealth -= Random.Range(2, 7);
            Destroy(gameObject);

        }
    }
}
