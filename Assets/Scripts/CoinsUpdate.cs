using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.TextCore.Text;

public class CoinsUpdate : MonoBehaviour
{
    // Connects script to textbox boject
    [SerializeField] private TextMeshProUGUI _coinsText;

    private int _coinsCount;

    // Scripts
    private Player _player;
    private Scenes _scenes;


    void Start()
    {
        // Gets each of the scripts
        _player = GetComponent<Player>();
        _scenes = GetComponent<Scenes>();
    }

    public void CoinsCreate(int coins) {
        this._coinsCount = coins;
    }

    public void ChangeCoins(int changeBy) {
        this._coinsCount += changeBy;
    }

    public int GetCoinsCount()
    {
        return _coinsCount;
    }

    void Update()
    {
        //Updates health textboxes
        this._coinsText.text = string.Format($"Coins: {GameData.Instance.PlayerCoins}");

    }
}