using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashScript : MonoBehaviour
{
    public float timeToLive;


    void Awake()
    {
        Destroy(gameObject, timeToLive);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            Debug.Log("Hit Enemy!");

            other.gameObject.SetActive(false);

            Destroy(gameObject);

            LevelManager.instance.scoreGained = 300;
            LevelManager.instance.GainScore();
        }
    }
}
