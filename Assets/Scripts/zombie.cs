using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Character
{
    //Speed varibles
    [HideInInspector]
    private Rigidbody2D _myBody;
    private Transform _player;
    private float _speed = 2f;


    void Awake()
    {
        // Using Contructor, it creates Zombie.
        GhostCreate("Ghost", 1, 1, 1);


        // Attains the rigid body script
        this._myBody = GetComponent<Rigidbody2D>();

        // Gets players position to target
        this._player = GameObject.FindGameObjectWithTag("Player").transform;

    }


    void Update()
    {
        //Zombies Movements
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

    public void GhostCreate(string name, int health, int maxHealth, int damage)
    {
        // Creates Zombie object with base class
        base.CharacterCreate(name, health, maxHealth, damage);

    }


    // When Zombie makes contact with player it gets destroyed
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }


}
