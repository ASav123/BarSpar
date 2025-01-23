using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    // Creates a static referance of file so other scripts can access it
    public static GameData Instance;

    // Game data saved vlaues
    public string PlayerName;
    public int PlayerCoins;
    public int PlayerHealth;
    public int PlayerMaxHealth;
    public int PlayerSpeed;
    public int EnemyDamage;

    // Initilizes the script as soon as game loads
    private void Awake()
    {
        // Makes sure only one instance of the script is running and it does not get destroyed
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        CreatePlayerData("Dave", 0);
    }

    // Creates inital values for game and stores them
    public void CreatePlayerData(string name, int coins)
    {
        this.PlayerName = name;
        this.PlayerCoins = coins;
    }

    // Changes game settings based on chosen difficulty
    public void DifficultySettings(int health, int speed, int ememyDamage) {
        this.PlayerHealth = health;
        this.PlayerMaxHealth = health;
        this.PlayerSpeed = speed;
        this.EnemyDamage = ememyDamage;
    }

    // Resents data to defaults data values
    public void ResetData() {
        this.PlayerCoins = 0;
        this.PlayerHealth = this.PlayerMaxHealth;

    }

}
