using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.TextCore.Text;

public class CoinsUpdate : MonoBehaviour
{
    // Connects script to textbox boject
    [SerializeField] private TextMeshProUGUI _coinsText;

    // Coins attributes
    private int _coinsCount;

    // Coins constructor
    public void CoinsCreate(int coins) {
        this._coinsCount = coins;
    }

    // Changes coins
    public void ChangeCoins(int changeBy) {
        this._coinsCount += changeBy;
    }

    // Gets coins
    public int GetCoins()
    {
        return _coinsCount;
    }

    void Update()
    {
        //Updates health textboxes
        this._coinsText.text = string.Format($"Coins: {GameData.Instance.PlayerCoins}");

    }
}