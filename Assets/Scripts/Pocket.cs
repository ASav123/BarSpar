using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pocket : MonoBehaviour
{
    private string[] _playerPocket;
    private int _playerPocketPointer;

    private int _countCoins;
    private int _countHearts;
    private int _countKeys;
    private int _countFlower;

    public void PocketAdd(string item)
    {
        if (this._playerPocket == null)
        {
            this._playerPocket = new string[] { item };
        }
        else
        {
            string[] newPlayerPocket = new string[this._playerPocket.Length + 1];
            for (int i = 0; i < this._playerPocket.Length; i++)
            {
                newPlayerPocket[i] = this._playerPocket[i];
            }
            newPlayerPocket[newPlayerPocket.Length - 1] = item;
            this._playerPocket = newPlayerPocket;
        }
        foreach (string playerPocket in this._playerPocket)
        {
            Debug.Log(playerPocket);
        }
        Debug.Log("");
    }

    //public void Sort() {
    //    for(int i = 0; i < this._playerPocket.Length)
    //}

    //    public void Sort() {
    //        for (int i = 0; i < this._playerPocket.Length; i++) {
    //            if (this._playerPocket[i] == "Coin") {
    //                this._countCoins++;
    //            }
    //            else if (this._playerPocket[i] == "Heart")
    //            {
    //                this._countHearts++;
    //            }
    //            else if (this._playerPocket[i] == "Key")
    //            {
    //                this._countKeys++;
    //            }
    //            else if (this._playerPocket[i] == "Flower")
    //            {
    //                this._countFlowers++;
    //            }
    //        }
    //    }

}
