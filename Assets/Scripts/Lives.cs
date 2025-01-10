using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.TextCore.Text;

public class Lives : MonoBehaviour
{
    //Connects script to textbox boject
    [SerializeField] private TextMeshProUGUI _heartsText;

    private Player _player;


    void Start()
    {
        _player = GetComponent<Player>();

    }

    void Update()
    {
        //Updates health textboxes
        this._heartsText.text = string.Format($"{this._player.GetHealth()}");
    }
}