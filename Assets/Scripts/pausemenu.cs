using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pausemenu;

    public void Pause()
    {
        pausemenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void Resume ()
    {
        pausemenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void Restart()
    {
        Time.timeScale = 1;
    }
    public void MuteToggle(bool muted)
    {
        if (muted)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = 1;
        }
    }
}
