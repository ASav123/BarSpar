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
        GameData.Instance.ResetData();
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

    // Runs when minigame button is pressed
    public void MiniGame()
    {
        SceneManager.LoadScene("Bottle Gambling Game");
    }

    // Runs when shop button is pressed
    public void Shop()
    {
        SceneManager.LoadScene("Shop");
    }

    // Runs when player presses outside button
    public void Outside()
    {
        SceneManager.LoadScene("Outside");
    }

    // Runs when player presses outside button
    public void Fish()
    {
        SceneManager.LoadScene("fishing game");
    }

}
