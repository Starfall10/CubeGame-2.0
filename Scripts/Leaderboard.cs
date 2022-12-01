using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    public int[] leaderboard = new int[5];

    public int[] array1 = { 3, 1, 55, 2, 123 };
    public int[] array2 = new int[3];

    void Awake()
    {
        PlayerPrefs.DeleteAll();
    }

    void Start()
    {
        Sort();
        SetPlayerPrefs();
        AppendArray();
        ForLoop();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void AppendArray()
    {
        array2[0] = 1;
    }


    public void SetPlayerPrefs()
    {
        for (int i = 0; i < 3; i++)
        {
            PlayerPrefs.SetInt("NO." + i; i)
        }
    }






    public void ForLoop()
    {
        for (int i = 0; i < array2.Length; i++)
        {
            Debug.Log(array2[i]);
        }

    }

    public void Sort()
    {
        for (int j = 0; j < array1.Length; j++)
        {
            int temp = 0;

            for (int i = 0; i < array1.Length - 1; i++)
            {
                if (array1[i] > array1[i + 1])
                {
                    temp = array1[i];
                    array1[i] = array1[i + 1];
                    array1[i + 1] = temp;
                }
            }
        }
    }




}
