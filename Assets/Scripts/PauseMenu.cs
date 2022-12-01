using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //This string store the name of the scene that the the quit button will load out to
    public string sceneToQuitTo;

    //This boolean keep track of when the game is paused or not
    public bool isPaused;

    //This store a referecne to the PauseMenu panel from the Ui element
    public GameObject thePauseMenu;


    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        //Calling the PauseGAme() method
        PauseGame(); 
    }

    //This methods will allow the player to Pause the game whenever they want
    public void PauseGame()
    {
        //The code will run when the ESC button
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            //If the game is Paused
            if(isPaused)
            {
                //This will call the PlaySound method from the Audio Manager, the sound number 0 is for clicking a button
                AudioManager.instance.PlaySound(0);
                //Changing the bool to false
                isPaused = false;
                //Then swtich off the Pause Menu panel
                thePauseMenu.SetActive(false);
                //Then change the time flow of time of the game to normal 
                Time.timeScale = 1f;
            }
            //If the game is not Paused
            else
            {
                //This will call the PlaySound method from the Audio Manager, the sound number 0 is for clicking a button
                AudioManager.instance.PlaySound(0);
                //Changing the bool to true
                isPaused = true;
                //Activating or turn on the Pause Menu panel
                thePauseMenu.SetActive(true);
                //Then change the stop flow of time of the game
                Time.timeScale = 0f;
            }
        }

        
    }

    //This method will be use by the game button and to Resume the game
    public void Resume()
    {
        //This will call the PlaySound method from the Audio Manager, the sound number 0 is for clicking a button
        AudioManager.instance.PlaySound(0);
        //Debug.Log("Resume");

        //The code will be the same as before
        //Changing the bool to false
        isPaused =false;
        //then switch off the Pause Menu panel
        thePauseMenu.SetActive(false);
        //Then change the time flow of time of the game to normal
        Time.timeScale = 1f;

    }

    //This method will be use by tha game butotn and to quit out of the level
    public void Quit()
    {
        //Debug.Log("Quit");  

        //Using the LoadScene() method from the SceneManager method from Unity.
        SceneManager.LoadScene(sceneToQuitTo);
    }
}
