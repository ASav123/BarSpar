using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : Character
{
    // Unique attributes of class
    private Character _character;
    private Scenes _scenes;

    private float _moveSpeed = 5f;
    


    void Start()
    {
        _character = GetComponent<Character>();
        _scenes = GetComponent<Scenes>();
        _character.CharacterCreate("Dave", 100, 3);
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
            _scenes.PlayGame();
        }

        if (collision.gameObject.CompareTag("Ghost"))
        {
            ChangeHealth(-1);

        }
    }
}
