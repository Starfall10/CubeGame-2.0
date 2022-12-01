using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public static HealthController instance;

    public int maxHealth;
    public int currentHealth;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DealDamage()
    {
        currentHealth--;

    }

    public bool DeathCheck()
    {
        if (currentHealth <= 0)
        {
            return (true);
        }
        else
        {
            return (false);
        }
    }

    public void HealPlayer()
    {
        currentHealth++;

    }
}
