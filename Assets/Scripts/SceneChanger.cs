using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    // Runs when "play" button pressed
    public void PlayGame()
    {
        SceneManager.LoadScene("Bar");
    }

    // Runs when "restart" or "play again" buttons prssed
    public void EnterMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Runs when player health reaches zero
    public void PlayerDeath()
    {
        SceneManager.LoadScene("Loose");
    }

    // Runs when player get home
    public void PlayerWin()
    {
        SceneManager.LoadScene("Win");
    }
}
