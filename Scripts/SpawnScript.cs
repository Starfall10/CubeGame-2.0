using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public Transform spawnPoint;

    public GameObject thePlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    private void Respawn()
    {
        if(PlayerController.instance.playerDeath == true)
        {
            //Debug.Log("respawn");

            Instantiate(thePlayer, spawnPoint.position, spawnPoint.rotation);

            PlayerController.instance.playerDeath = false;
        }
    }
}
