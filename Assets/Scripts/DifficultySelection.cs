using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class DifficultySelection : MonoBehaviour
{

    private Player _player;
    private Coins _coins;
    // Start is called before the first frame update
    void Start()
    {
        _coins = GetComponent<Coins>();
        _player = GetComponent<Player>();
        _player.CharacterCreate("Dave", 5, 3);
        //_coins.CoinsCreate(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
