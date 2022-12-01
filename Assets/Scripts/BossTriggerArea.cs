using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTriggerArea : MonoBehaviour
{
    public GameObject theBoss;

    void Start()
    {
        //This will call the PlaySound method from the Audio Manager, the sound number 4 which is the background music for the level
        AudioManager.instance.PlaySound(4);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //If the collided object has the "Player" tag then
        if (other.gameObject.tag == "Player")
        {
            AudioManager.instance.StopMusic(4);

            AudioManager.instance.PlaySound(5);

            theBoss.SetActive(true);

            gameObject.SetActive(false);
        }

    }
}