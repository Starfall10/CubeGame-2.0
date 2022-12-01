using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //This create an instance of the class which allow other class to referece this class vairables and methods
    public static AudioManager instance;

    //This will create an array that will store the data type of AudioSource, which is an Unity variable which store audio files to be use
    public AudioSource[] soundList;

    //This method is called upon the object is initialized
    void Awake()
    {
        //Setitng instance equal to this create a reference of this class for other classes
        instance = this;
    }

    //This method will be use to play the sound track stored in the soundList array,
    //the sound integer will be referencing the index position of the array
    public void PlaySound(int sound)
    {
        //Before playing the sound, I will be using Stop() method which stop it from playing, in case this sound is already playing before,
        //This makes it so the sound will not be played over lapping it self which will produce an unpleasent audio
        soundList[sound].Stop();

        //THe Play() method is a built in Unity metho that will play the sound track selected,
        //In this case the selcted is the will be which every number which is pass in as paramter and refereing to an item in the soundLIst array
        soundList[sound].Play();
    }

    //This method will be use just ot stop a selected sound from playing (if it is already playing)
    public void StopMusic(int sound)
    {
        //The Stop() method is a built in method that will stop the selected soundtrack from playing.
        soundList[sound].Stop();
    }
}
