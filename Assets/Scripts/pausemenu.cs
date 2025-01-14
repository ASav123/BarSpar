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
        // dont know how to make it restart
    }
}
