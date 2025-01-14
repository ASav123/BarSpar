using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        // Plays the background music when scene loads
        audioSource.Play();
    }

    // Stops music
    public void StopMusic()
    {
        audioSource.Stop();
    }

    // Pauses music
    public void PauseMusic()
    {
        audioSource.Pause();
    }

    // Pasues music
    public void UnpauseMusic()
    {
        audioSource.UnPause();
    }

}