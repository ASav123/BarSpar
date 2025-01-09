using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    // Unique attributes of class
    public float moveSpeed = 5f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        // Imput for movment from wasd or arrow keys
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // Moves the player
        Vector2 moveDirection = new Vector2(moveX, moveY).normalized;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}
