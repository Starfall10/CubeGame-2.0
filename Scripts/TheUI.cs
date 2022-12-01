using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheUI : MonoBehaviour
{
    public static TheUI instance;

    public Sprite fullHeart, emptyHeart;

    public Image heart1, heart2, heart3;

    public Text points;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        UpdateHealthUI();
        UpdatePointUI();
    }

    public void UpdateHealthUI()
    {
        switch(HealthController.instance.currentHealth)
        {
            case 0:
                heart1.sprite = emptyHeart; 
                heart2.sprite = emptyHeart;
                heart3.sprite = emptyHeart;

                break;

            case 1:
                heart1.sprite = fullHeart;
                heart2.sprite = emptyHeart;
                heart3.sprite = emptyHeart;

                break;

            case 2:
                heart1.sprite = fullHeart;
                heart2.sprite = fullHeart;
                heart3.sprite = emptyHeart;

                break;

            case 3:
                heart1.sprite = fullHeart;
                heart2.sprite = fullHeart;
                heart3.sprite = fullHeart;

                break;
        }
    }

    public void UpdatePointUI()
    {
        points.text = LevelManager.instance.CurrentScore.ToString();
    }
}
