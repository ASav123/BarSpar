using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class DifficultySelection : MonoBehaviour
{
    private int _playerHealth = 100;
    private int _playerSpeed = 5;
    private int _enemyDamage = 1;

    private Player _player;
    private Coins _coins;
    // Start is called before the first frame update
    void Start()
    {
        _coins = GetComponent<Coins>();
        _player = GetComponent<Player>();
    }

    public void Hard() {
        Debug.Log("Hard button");
        this._playerHealth = 50;
        this._playerSpeed = 4;
        this._enemyDamage = 1;

    }
    public void Normal() {
        Debug.Log("Normal Button");
        this._playerHealth = 100;
        this._playerSpeed = 5;
        this._enemyDamage = 1;
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
