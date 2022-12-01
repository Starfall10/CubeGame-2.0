using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishFlag : MonoBehaviour
{
    //This string will store the name of the next number to be load
    public string nextLevel;

    //This method will check if there is another object that enter the trigger zone of the object
    public void OnTriggerEnter2D(Collider2D other)
    {
        //If that other object is "Player" then the code below will be run
        if(other.tag == "Player")
        {
            //calling the StoreScores() method in the LevelManager class
            LevelManager.instance.StoreScores();
            //Debug.Log("Exit!")

            //Using the LoadScene() method from the library will allow program to load the scene with the set name in nextLevel
            SceneManager.LoadScene(nextLevel);
            
        }
    }
}
