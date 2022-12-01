using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishFlag : MonoBehaviour
{
    public string nextLevel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
                
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            LevelManager.instance.StoreScores();
            //Debug.Log("Exit!")
            SceneManager.LoadScene(nextLevel);
            
        }
    }
}
