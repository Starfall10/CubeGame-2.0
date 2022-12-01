using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{
    //Creating an instance of the class to allow other classes to reference to variables and methods of this class
    public static GameOverPanel instance;

    //These 2 floats will be use to get the script to run a countdown
    public float timeToWait, timeCounter;
    //Creating 2 bool isGameOver and activatePanel
    public bool isGameOver, activatePanel;
    //This string will be use load the highscoreScene
    public string highscoreScene;

    public Text points;

    //This stores the referenec to the UI Canvas Panel so that I will be able to turn it on and off
    public GameObject thePanel;

    


    //Awake() will be called once when the object is created
    void Awake()
    {
        //Setting instance equal to this class
        instance = this;
    }

    //This function will be called at the start of the scene
    void Start()
    {
        //When the scene start the timeCounter is set to the timeToWait
        timeCounter = timeToWait;
    }

    // Update is called once per frame
    void Update()
    {
        //Calling the GameOver() method
        GameOver();
    }

    //This method will manager what happens when the gameover sequence starts
    public void GameOver()
    {
        //First it will check if the isGameOver bool is true and the timecounter is larger than 0
        if(isGameOver && timeCounter > 0)
        {
            //Using Time.deltaTime I can decrease time relative to real life time
            timeCounter -= Time.deltaTime;
        }
        //After the first timeCounter has run out, it checks if the activatePanel bool is false
        else if(isGameOver && timeCounter < 0 && !activatePanel)
        {
            //If it is then, the counter will reset
            timeCounter = timeToWait;
            //The the activate panel will be change to true
            activatePanel = true;

            points.text = LevelManager.instance.CurrentScore.ToString();
            //And the UI Canvas Panel will show up covering the whole screen
            thePanel.SetActive(true);
        }
        //After the end of the second timeCounter, the leaderboard will be load
        else if(activatePanel)
        {
            //Debug.Log("Highscore");


            

            LevelManager.instance.StoreScores();

            

            //Calling the LoadScene method from the import Unity's SceneManagement library
            SceneManager.LoadScene(highscoreScene);

            
        }


    }
}
