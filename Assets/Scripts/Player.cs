using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : Character
{
    // Unique attributes of class
    private Character _character;
    private Scenes _scenes;
    private Coins _coins;

    private float _moveSpeed = 5f;
    


    void Awake()
    {
        _character = GetComponent<Character>();
        _scenes = GetComponent<Scenes>();
        _coins = GetComponent<Coins>();
        _character.CharacterCreate("Dave", 5, 3);
        _coins.CoinsCreate(0);
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bar"))
        {
            this._scenes.PlayGame();
        }

        if (collision.gameObject.CompareTag("Ghost"))
        {
            this.ChangeHealth(-1);

        }

        if (collision.gameObject.CompareTag("Heart"))
        {
            this.ChangeHealth(5);

        }

        if (collision.gameObject.CompareTag("Coin"))
        {
            this._coins.ChangeCoins(5);
        }
    }
}
