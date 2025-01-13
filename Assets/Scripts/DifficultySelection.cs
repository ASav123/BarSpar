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

    // Start is called before the first frame update
    void Start()
    {
        // Normal game settings
        this._playerHealth = 100;
        this._playerSpeed = 5;
        this._enemyDamage = 1;
        GameData.Instance.DifficultySettings(this._playerHealth, this._playerSpeed, this._enemyDamage);

    }

    // Hard settings
    public void Hard() {
        Debug.Log("Hard button");
        this._playerHealth = 50;
        this._playerSpeed = 3;
        this._enemyDamage = 2;
        GameData.Instance.DifficultySettings(this._playerHealth, this._playerSpeed, this._enemyDamage);
    }

    // Normal settings
    public void Normal() {
        Debug.Log("Normal Button");
        this._playerHealth = 100;
        this._playerSpeed = 5;
        this._enemyDamage = 1;
        GameData.Instance.DifficultySettings(this._playerHealth, this._playerSpeed, this._enemyDamage);

    }

    // Getters
    public int GetPlayerHealth() {
        return this._playerHealth;
    }

    public int GetPlayerSpeed() {
        return this._playerSpeed;
    }

    public int GetEnemyDamage() {
        return (this._enemyDamage);
    }

    
}
