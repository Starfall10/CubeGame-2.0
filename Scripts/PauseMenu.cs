using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public string sceneToQuitTo;

    public bool isPaused;

    public GameObject thePauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PauseGame(); 
    }

    public void PauseGame()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                isPaused = false;
                thePauseMenu.SetActive(false);
                Time.timeScale = 1f;
            }
            else
            {
                isPaused = true;
                thePauseMenu.SetActive(true);
                Time.timeScale = 0f;
            }
        }

        
    }

    public void Resume()
    {
        //Debug.Log("Resume");
        isPaused=false;
        thePauseMenu.SetActive(false);
        Time.timeScale = 1f;

    }

    public void Quit()
    {
        //Debug.Log("Quit");  
        SceneManager.LoadScene(sceneToQuitTo);
    }
}
