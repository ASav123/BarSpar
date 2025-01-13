using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : Character
{
    // Unique attributes of player class
    private Character _character;
    private Scenes _scenes;
    private Coins _coins;
    private DifficultySelection _difficultySelection;

    private int _moveSpeed;
    


    void Start()
    {
        // Getts each of the sripts
        _character = GetComponent<Character>();
        _scenes = GetComponent<Scenes>();
        _coins = GetComponent<Coins>();
        _difficultySelection = GetComponent<DifficultySelection>();

        // Constructors 
        PlayerCreate(GameData.Instance.PlayerName, GameData.Instance.PlayerHealth, 3, GameData.Instance.PlayerSpeed);
        _coins.CoinsCreate(GameData.Instance.PlayerCoins);
    }
    // Player constructor using base class of character
    public void PlayerCreate(string name, int health, int damage, int moveSpeed) {
        _character.CharacterCreate(name, health, damage);
        this._moveSpeed = moveSpeed;
    }

    void Update()
    {
        // Imput for movment from wasd or arrow keys
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // Moves the player
        Vector2 moveDirection = new Vector2(moveX, moveY).normalized;
        transform.Translate(moveDirection * this._moveSpeed * Time.deltaTime);

    }

    // Collison detection with outside area
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bar"))
        {
            this._scenes.PlayGame();
        }

        if (collision.gameObject.CompareTag("Ghost"))
        {
            this.ChangeHealth(-GameData.Instance.EnemyDamage);
            GameData.Instance.PlayerHealth = this.GetHealth();


        }

        if (collision.gameObject.CompareTag("Heart"))
        {
            this.ChangeHealth(5);
            GameData.Instance.PlayerHealth = this.GetHealth();


        }

        if (collision.gameObject.CompareTag("Coin"))
        {
            this._coins.ChangeCoins(5);
            GameData.Instance.PlayerCoins = this._coins.GetCoins();

        }
    }
}
