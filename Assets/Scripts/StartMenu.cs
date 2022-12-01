using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartMenu : MonoBehaviour
{
    //These 2 strings store the name of the value that will be loaded to 
    public string startScene, highScore, levelEndScore;

    void Start()
    {
        PlayerPrefs.SetInt("levelEndScore", 0);
    }

    //This method will be use by the start game button
    public void StartGame()
    {
        //Debug.Log("Start Game");
        //This uses the built in LoadScene() method from the imported scene manager library 
        SceneManager.LoadScene(startScene);

        AudioManager.instance.PlaySound(0);
    }


    //This method will be use by the Leaderboard button
    public void ShowHighScore()
    {
        //Debug.Log("Show Highscore");

        //This uses the built in LoadScene() method from the imported scene manager library 
        SceneManager.LoadScene(highScore);

        //This will call the PlaySound method from the Audio Manager, the sound number 0 is for clicking a button
        AudioManager.instance.PlaySound(0);
    }

    //This method will be use by the Quit button
    public void QuitGame()
    {
        //This will call the PlaySound method from the Audio Manager, the sound number 0 is for clicking a button
        AudioManager.instance.PlaySound(0);
        //Debug.Log("Quit Game");

        //Appplication.Quit() is a built in function that allow the game application to just close
        Application.Quit();


        
    }
}
