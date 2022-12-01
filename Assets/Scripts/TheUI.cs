using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheUI : MonoBehaviour
{
    //This create an instance of this class allowing other class to access, use and change variables and methods on this class
    public static TheUI instance;

    //These 2 sprite type variables store the spirte of the full and empty heart for the UI element
    //public Sprite fullHeart, emptyHeart;
    //These 3 store the reference to the 3 hearts that will be display on the UI canvas
    //public Image heart1, heart2, heart3;
    //This store the reference to the text that will display the player's current score on the UI canvas
    public Text points;

    public Image theHealthBar;

    public Image blueBar, purpleBar;


    

    //This method will be call once when the script is first instantiated
    void Awake()
    {
        //Making instance equal to this class
        instance = this;
    }

    //This will call once every frame 
    void Update()
    {
        //Calling the UpdateHealthUI() method from below
        //UpdateHealthUI();
        //Calling the UpdatePointUI() method from below
        UpdatePointUI();
        theHealthBar.fillAmount = HealthController.instance.currentHealth / HealthController.instance.maxHealth;

        blueBar.fillAmount = Boss.instance.bossCurrentHealth / Boss.instance.bossMaxHealth;
        purpleBar.fillAmount = Boss.instance.bossCurrentHealth / Boss.instance.bossMaxHealth;
    }

    //This method will change the current health display of the player.
    /*
    public void UpdateHealthUI()
    {
        //This switch case will be a fast way to just chage the number of heart displaying
        //This check upon the currenthealth variable stored in the HealthController class
        switch(HealthController.instance.currentHealth)
        {
            //By using heart.sprite this will access the reference sprite component from above the change it to the preset sprite named form above

            //Case 0, the player is dead, all 3 will be empty
            case 0:
                heart1.sprite = emptyHeart; 
                heart2.sprite = emptyHeart;
                heart3.sprite = emptyHeart;

                break;

            //Case 1, the player has 1 health, all 2 will be empty 1 full
            case 1:
                heart1.sprite = fullHeart;
                heart2.sprite = emptyHeart;
                heart3.sprite = emptyHeart;

                break;

            //Case 2, the player has 2 health, all 1 will be empty 2 full
            case 2:
                heart1.sprite = fullHeart;
                heart2.sprite = fullHeart;
                heart3.sprite = emptyHeart;

                break;


            //Case 3, the player has 3 health, all 3 will be full
            case 3:
                heart1.sprite = fullHeart;
                heart2.sprite = fullHeart;
                heart3.sprite = fullHeart;

                break;
        }
    }
    */

    //This method will change the score being display on the UI 
    public void UpdatePointUI()
    {
        //This changed the reference text from above with currentscore variable from the LevelManager class. To string allow this to be process as a string
        points.text = LevelManager.instance.CurrentScore.ToString();
    }
}
