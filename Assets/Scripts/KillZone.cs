using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            //Debug.Log("Die");

            HealthController.instance.currentHealth = 0;
        }
    }
}
