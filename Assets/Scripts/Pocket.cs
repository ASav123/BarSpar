using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pocket : MonoBehaviour
{
    private string[] _playerPocket;
    private string[] _sortingOrder;

    private bool _hasKey;

    private void Start()
    {
        Debug.Log("Running");
        this._sortingOrder = new string[] { "coin", "flower", "heart", "key" };
        this._hasKey = false;

    }

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

        if (item == "key")
        {
            this._hasKey = true;
        }

        InstanceSort();

    }

    public void Sort(string[] sortingOrder)
    {
        foreach (string key in sortingOrder) {
            Debug.Log(key);
        }
        foreach (string item in sortingOrder)
        {
            for (int cursor = 0; cursor < this._playerPocket.Length; cursor++)
            {
                for (int i = 0; i < this._playerPocket.Length; i++)
                {
                    if (this._playerPocket[cursor] != item && this._playerPocket[i] == item)
                    {
                        string tempItem = this._playerPocket[i];
                        this._playerPocket[i] = this._playerPocket[cursor];
                        this._playerPocket[cursor] = tempItem;
                        Debug.Log("Swapping");
                    }

                }
            }
        }
    }

    public void InstanceSort()
    {
        int coinCount = 0;
        int heartCount = 0;
        int flowerCount = 0;
        int keyCount = 0;

        for (int i = 0; i < this._playerPocket.Length; i++)
        {
            if (this._playerPocket[i] == "coin")
            {
                coinCount++;
            }
            else if (this._playerPocket[i] == "heart")
            {
                heartCount++;
            }
            else if (this._playerPocket[i] == "flower")
            {
                flowerCount++;
            }
            else
            {
                keyCount++;
            }
        }
        string[] tempOrder = new string[4];
        if (coinCount > heartCount)
        {
            tempOrder[0] = "coin";
            tempOrder[1] = "heart";
        }
        else
        {
            tempOrder[0] = "heart";
            tempOrder[1] = "coin";
        }
        tempOrder[2] = "flower";
        tempOrder[3] = "key";

        Sort(tempOrder);
    }

    public int BinarySearch(string target)
    {
        int left = 0;
        int right = this._playerPocket.Length - 1;

        while (left <= right)
        {
            int mid = (left + right) / 2;
            int comparison = string.Compare(this._playerPocket[mid], target, System.StringComparison.Ordinal);

            if (comparison == 0)
            {
                return mid;
            }
            else if (comparison < 0)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return -1;
    }

    public int LinearSearch(string item)
    {
        for (int i = 0; i < this._playerPocket.Length; i++)
        {
            if (this._playerPocket[i] == item)
            {
                return i;
            }
        }
        return -1;
    }

    public void RemoveItem(string item)
    {
        int itemIndex = BinarySearch(item);

        if (itemIndex != -1) {
            string[] newPockets = new string[this._playerPocket.Length - 1];
            for (int i = 0; i < this._playerPocket.Length - 1; i++)
            {
                if (i < itemIndex)
                {
                    newPockets[i] = this._playerPocket[i];
                }
                else if (i > itemIndex)
                {
                    newPockets[i - 1] = this._playerPocket[i];
                }
            }
            this._playerPocket = newPockets;

            if (item == "key") {
                this._hasKey = false;
            }
        }

    }

    public bool GetKeuStatus() { 
        return this._hasKey;
    }

}
