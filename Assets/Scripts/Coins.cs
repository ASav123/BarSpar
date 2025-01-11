using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coins : MonoBehaviour
{
    //Connects script to textbox boject
    [SerializeField] private TextMeshProUGUI _coinsText;

    //Coin attributes
    private int _coins;

    //Coin constructor
    public void CoinsCreate(int coins)
    {
        this._coins = coins;
    }

    //Getters and setters
    public int GetCoins()
    {
        return this._coins;
    }
    public void ChangeCoins(int changeBy)
    {
        if ((this._coins += changeBy) >= 0) {
            this._coins += changeBy;
        }
    }


    void Update()
    {
        //Updates coin textbox
        this._coinsText.text = string.Format($"Coins: {this.GetCoins()}");
    }
}