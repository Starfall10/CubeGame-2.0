using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartMenu : MonoBehaviour
{
    public string startScene, highScore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        Debug.Log("Start Game");
        SceneManager.LoadScene(startScene);
    }

    public void ShowHighScore()
    {
        Debug.Log("Show Highscore");
        SceneManager.LoadScene(highScore);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
        
    }
}
