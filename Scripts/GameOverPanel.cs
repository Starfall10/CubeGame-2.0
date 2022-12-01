using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{

    public float timeToWait, timeCounter;
    public bool isGameOver, activatePanel;
    public string highscoreScene;

    public GameObject thePanel;

    public static GameOverPanel instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        timeCounter = timeToWait;
    }

    // Update is called once per frame
    void Update()
    {
        GameOver();
    }

    public void GameOver()
    {
        if(isGameOver && timeCounter > 0)
        {
            timeCounter -= Time.deltaTime;
        }
        else if(isGameOver && timeCounter < 0 && !activatePanel)
        {
            timeCounter = timeToWait;
            activatePanel = true;
            thePanel.SetActive(true);
        }
        else if(activatePanel)
        {
            //Debug.Log("Highscore");
            SceneManager.LoadScene(highscoreScene);
        }

    }
}
