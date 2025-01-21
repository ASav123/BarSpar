using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class DifficultySelection : MonoBehaviour
{
    // Attibutes that change difficulty
    private int _playerHealth;
    private int _playerSpeed;
    private int _enemyDamage;
    private int _difficulty;

    private Coins _coins;

    // Start is called before the first frame update
    void Start()
    {
        // Normal game settings
        this._playerHealth = 100;
        this._playerSpeed = 5;
        this._enemyDamage = 1;
        this._difficulty = 1;
        GameData.Instance.DifficultySettings(this._playerHealth, this._playerSpeed, this._enemyDamage);

        _coins = GetComponent<Coins>();
        _coins.CoinsCreate(10);
        Debug.Log("Created Coins");
    }

    // Hard settings
    public void Hard() {
        this._playerHealth = 50;
        this._playerSpeed = 3;
        this._enemyDamage = 2;
        this._difficulty = 0;
        GameData.Instance.DifficultySettings(this._playerHealth, this._playerSpeed, this._enemyDamage);

        _coins.CoinsCreate(5);
    }

    // Normal settings
    public void Normal() {
        this._playerHealth = 100;
        this._playerSpeed = 5;
        this._enemyDamage = 1;
        this._difficulty = 1;
        GameData.Instance.DifficultySettings(this._playerHealth, this._playerSpeed, this._enemyDamage);

        _coins.CoinsCreate(10);
    }

    // Getters
    public int GetPlayerHealth() {
        return this._playerHealth;
    }

    public int GetPlayerSpeed() {
        return this._playerSpeed;
    }

    public int GetEnemyDamage() {
        return this._enemyDamage;
    }

    public int GetDifficulty() {
        return this._difficulty;
    }

    
}
