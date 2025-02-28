using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    private Transform player;

    private Vector3 tempPos;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Locks on the x-value of player
        tempPos = transform.position;
        tempPos.x = player.position.x;
        transform.position = tempPos;
    }
}