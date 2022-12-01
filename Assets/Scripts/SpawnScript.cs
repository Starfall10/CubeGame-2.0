using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    //This variable store the Transform x,y,z position of the spawnpoint
    public Transform spawnPoint;
    //This store the a reference of the Player from the prefab to be create again.
    public GameObject thePlayer;

    //This method will respawn the player after dies
    private void Respawn()
    {
        //This check if the bool playerDeath is true
        if(PlayerController.instance.playerDeath == true)
        {
            //Debug.Log("respawn");

            //This spawn a new player at the spawnPoint position and rotation
            Instantiate(thePlayer, spawnPoint.position, spawnPoint.rotation);

            //This will change the bool playerDeath from the PlayerController class.
            PlayerController.instance.playerDeath = false;
        }
    }
}
