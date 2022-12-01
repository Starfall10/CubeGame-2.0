using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public int CurrentScore, scoreGained;

    public string levelEndScore, gameEndScore;

    void Awake()
    {
        instance = this;
        CurrentScore = PlayerPrefs.GetInt(levelEndScore);
    }

    public void GainScore()
    {
        CurrentScore += scoreGained;
    }

    public void StoreScores()
    {
        PlayerPrefs.SetInt(levelEndScore, CurrentScore);
    }
}
