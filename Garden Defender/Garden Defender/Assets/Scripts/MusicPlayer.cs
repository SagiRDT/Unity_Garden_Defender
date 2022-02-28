/*
 *  MusicPlayer
 *  The obj tht plays the game background music
 *  A singletone obj, theres only 1 music player
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // Cached component references
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsController.GetMasterVolume();
    }

    // Set the music volume
    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }

}
