using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : Character
{

    // Unique attributes of player class
    // All private so outside classes cannot acess these

    private Character _character;
    private Scenes _scenes;
    private Coins _coins;
    private CoinsUpdate _coinsUpdate;
    private Pocket _pocket;
    private int _moveSpeed;
    
    void Start()
    {
        // Getts each of the sripts
        _character = GetComponent<Character>();
        _scenes = GetComponent<Scenes>();
        _coins = GetComponent<Coins>();
        _coinsUpdate = GetComponent<CoinsUpdate>();
        _pocket = GetComponent<Pocket>();


        // Player created
        this.PlayerCreate(GameData.Instance.PlayerName , GameData.Instance.PlayerHealth, GameData.Instance.PlayerMaxHealth ,3 , GameData.Instance.PlayerSpeed, GameData.Instance.PlayerCoins);

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

    // Player constructor using base class of character
    public void PlayerCreate(string name, int health, int maxHealth, int damage, int moveSpeed, int coins)
    {
        // Uses base class constructer to create player object
        base.CharacterCreate(name, health, maxHealth, damage);
        this._moveSpeed = moveSpeed;

        // Coins created though composition (strong)
        this._coinsUpdate.CoinsCreate(coins);
    }

  

    // Collison detection with outside area

    // Bar
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bar"))
        {
            // Calls method from pocket script that searches the players pockets for key
            if (_pocket.GetKeuStatus() == true) {

                this._scenes.PlayGame();

            }
        }

        // Ghost
        if (collision.gameObject.CompareTag("Ghost"))
        {
            this.ChangeHealth(-GameData.Instance.EnemyDamage);
            GameData.Instance.PlayerHealth = this._character.GetHealth();


        }

        // Heart
        if (collision.gameObject.CompareTag("Heart"))
        {
            this.ChangeHealth(5);
            GameData.Instance.PlayerHealth = this._character.GetHealth();
            this._pocket.PocketAdd("heart");


        }

        // Coin
        if (collision.gameObject.CompareTag("Coin"))
        {
            this._coinsUpdate.ChangeCoins(5);
            GameData.Instance.PlayerCoins = this._coinsUpdate.GetCoins();
            this._pocket.PocketAdd("coin");

        }

        // Flower
        if (collision.gameObject.CompareTag("Flower"))
        {
            this._pocket.PocketAdd("flower");
        }

        // Key
        if (collision.gameObject.CompareTag("Key"))
        {
            this._pocket.PocketAdd("key");
        }
    }
}
