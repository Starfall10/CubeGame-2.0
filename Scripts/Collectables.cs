using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public bool health, gem, speedBoast, jumpBoast;

    public bool speedUP, jumpUP;

    public int jumpBoastForce;

    void Start()
    {
        speedUP = false;
        jumpUP = false;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(health == true && HealthController.instance.currentHealth < HealthController.instance.maxHealth)
            {
                //Debug.Log("Collect!");

                HealthController.instance.HealPlayer();

                
            }
            else if(gem == true)
            {
                //Debug.Log("Gem");
                LevelManager.instance.scoreGained = 100;
                LevelManager.instance.GainScore();
            }
            else if(jumpBoast == true)
            {
                //Debug.Log("Jump");
                PlayerController.instance.theRB.velocity = new Vector2(PlayerController.instance.theRB.velocity.x, jumpBoastForce);
            }

            Destroy(gameObject);
        }
        
    }
}
