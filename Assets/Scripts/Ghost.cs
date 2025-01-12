using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Character
{
    //Speed varibles
    [HideInInspector]
    private Rigidbody2D _myBody;
    private Transform _player;
    private float _speed = 2f;

    void Awake()
    {
        // Gets each of the scripts 
        this._myBody = GetComponent<Rigidbody2D>();

        // Gets players position
        this._player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        //Ghost movement
        if (this._player != null)
        {
            Vector2 direction = (this._player.position - transform.position).normalized;

            this._myBody.velocity = direction * this._speed;
        }
        else
        {
            this._myBody.velocity = Vector2.zero;
        }
    }


    // Destroys Ghost when collides with player
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }


}