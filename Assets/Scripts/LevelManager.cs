using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //Creating an instance of the class to allow other classes to reference to variables and methods of this class
    public static LevelManager instance;
    //The currentScore int will be storing the current score of the run
    //The scoreGained int will be change equal to the object's worth and then added to the main CurrentScore
    public int CurrentScore, scoreGained;

    

    //This is called upon the first instantiation of the script
    void Awake()
    {
        //Setting instance equal to this class
        instance = this;
        //Loading the the currentScore from the last level
        CurrentScore = PlayerPrefs.GetInt("levelEndScore");
    }

    //This method will increase the score the player
    public void GainScore()
    {
        //Here, the currentScore will simply be added by the scoreGained
        CurrentScore += scoreGained;
    }

    //This method will store the score at the end of the level
    public void StoreScores()
    {
        //Creating a PlayerPref of type Int will the name levelEndScore and value of whatever the currentScore was
        PlayerPrefs.SetInt("levelEndScore", CurrentScore);
    }
}
