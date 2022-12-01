using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Rigidbody2D theRB;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Destroy(gameObject);

            HealthController.instance.DealDamage();
        }
        else if(other.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}


