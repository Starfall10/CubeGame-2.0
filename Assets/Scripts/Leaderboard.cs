using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Leaderboard : MonoBehaviour
{
    public static Leaderboard instance;

    //public int[] scores = { 160, 3451, 3192, 3323, 0980, 0 };
    //public string[] names = { "AAA", "BBB", "CCC", "DDD", "EEE", "" };
    public int[] scores = new int[5];
    public string[] names = new string[5];
    public int newScore;
    public string newName;
    public int temp1 = 0;
    public string temp2 = "";
    public bool validName;

    public Text score1, name1;
    public Text score2, name2;
    public Text score3, name3;
    public Text score4, name4;
    public Text score5, name5;
    public Text messageToPlayer;
    public GameObject message;
    public GameObject inputBox;


    public string levelEndScore;

    public bool runEnded;

    public string StartLevel;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        message.SetActive(false);

        validName = false;
        newScore = PlayerPrefs.GetInt("levelEndScore");

        //SetBoard();
        LoadingPlayerPref();
        Sort();
        UpdateLeaderboard(); 

        Debug.Log(newScore);

        if(GameOverPanel.instance.isGameOver == true)
        {
            runEnded = true;
        }

        if (newScore > scores[4] && runEnded == true)
        {
            //Debug.Log(newScore);
            //Debug.Log("running");
            messageToPlayer.text = "Congrats! You have made it into the laederboard!";
            message.SetActive(true);
            inputBox.SetActive(true);
        }
        else
        {
            messageToPlayer.text = "You have not made it to the leaderboard. Try harder next time!";
            message.SetActive(true);

        }

        //SetBoard();
        //SortingPlayerPrefs();
    }

    // Update is called once per frame
    void Update()
    {
        if (validName == true)
        {
            scores[5] = newScore;
            names[5] = newName.ToString();
            messageToPlayer.text = "Congratulation, " + newName;

            Sort();
            UpdateLeaderboard();
            validName = false;
            StoringPlayerPrefs();
            inputBox.SetActive(false);
            runEnded = false;
        }
    }


    public void Sort()
    {
        for (int x = 0; x < scores.Length; x++)
        {
            for (int i = 0; i < scores.Length - 1; i++)
            {
                if (scores[i + 1] > scores[i])
                {
                    temp1 = scores[i + 1];
                    scores[i + 1] = scores[i];
                    scores[i] = temp1;

                    temp2 = names[i + 1];
                    names[i + 1] = names[i];
                    names[i] = temp2;
                    
                }
            }
        }
    }

    public void UpdateLeaderboard()
    {
        
        score1.text = scores[0].ToString();
        score2.text = scores[1].ToString();
        score3.text = scores[2].ToString();
        score4.text = scores[3].ToString();
        score5.text = scores[4].ToString();

        name1.text = names[0].ToString();
        name2.text = names[1].ToString();
        name3.text = names[2].ToString();
        name4.text = names[3].ToString();
        name5.text = names[4].ToString();

    }

    public void SetBoard()
    {
        for (int i = 0; i < 5; i++)
        {
            scores[i] = 0;
            names[i] = "AAA";
        }
    }



    public void NameValidation()
    {
        if(newName.Length > 3)
        {
            validName = false;
            Debug.Log(validName);
            messageToPlayer.text = "The name you entered is too long";
            message.SetActive(true);
            
        }
        else
        {
            validName = true;

        }
    }

    public void GetPlayerName(string inputname)
    {
        
        //Debug.Log("Entered: " + inputname);
        newName = inputname;
        NameValidation();
        Debug.Log(validName);
    }

    


    public void StoringPlayerPrefs()
    {
        for (int i = 0; i < 5; i ++)
        {
            PlayerPrefs.SetInt("Score of player " + i.ToString(), scores[i]);
            PlayerPrefs.SetString("Name of player " + i.ToString(), names[i]);
        }
    }

    public void LoadingPlayerPref()
    {
        for (int i = 0; i < 5; i ++)
        {
            scores[i] = PlayerPrefs.GetInt("Score of player " + i.ToString());
            names[i] = PlayerPrefs.GetString("Name of player " + i.ToString());
        }
    }
        

    public void QuitToMainMenu()
    {
        //This will call the PlaySound method from the Audio Manager, the sound number 0 is for clicking a button
        AudioManager.instance.PlaySound(0);

        SceneManager.LoadScene(StartLevel);
    }

}
