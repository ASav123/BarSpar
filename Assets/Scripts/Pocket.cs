using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pocket : MonoBehaviour
{
    // Arrays for players pockets
    private string[] _playerPocket;
    private string[] _sortingOrder;

    private void Start()
    {
        // Creates soring order and sets key to false
        this._sortingOrder = new string[] { "coin", "flower", "heart", "key" };

    }

    // Adds an item pocked up to players pockets
    public void PocketAdd(string item)
    {
        // Creates a new array if one does not yet exist
        if (this._playerPocket == null)
        {
            this._playerPocket = new string[] { item };
        }

        // Creates an array with an extra slot and adds item
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

        InstanceSort();

    }

    // MODIFIED EXCHANGE SORT
    // Using the sorting order sorts players pockets into that order
    public void Sort(string[] sortingOrder)
    {
        // Exchange sort for one item at a time
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
                    }

                }
            }
        }
    }

    // Sorts players pockets by amount of each item and groups items together from highest to lowest based on their amount
    public void InstanceSort()
    {
        int coinCount = 0;
        int heartCount = 0;
        int flowerCount = 0;
        int keyCount = 0;

        // Counts each item
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
        // Created the highest to lowest item order
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

        // Sends to exhcange sort algorithm
        Sort(tempOrder);
    }


    //BINARY SEARCH
    // Binary search on a sorted players pockets array and returns index
    public int BinarySearch(string target)
    {
        int left = 0;
        int right = this._playerPocket.Length - 1;

        // Compares values of strings until the target string is found 
        while (left <= right)
        {
            int mid = (left + right) / 2;
            int comparison = string.Compare(this._playerPocket[mid], target, System.StringComparison.Ordinal);

            // If value = 0 then target is found
            if (comparison == 0)
            {
                return mid;
            }
            // If value < 0 then target is to the right of mid
            else if (comparison < 0)
            {
                left = mid + 1;
            }
            // Else target is to the left of mid
            else
            {
                right = mid - 1;
            }
        }

        return -1;
    }

    // LINEAR SEARCH
    // Linear search on sorted players pockets and returns index
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

    // Removes an item from players pockets
    public void RemoveItem(string item)
    {
        // Uses the binary search to find the items index
        int itemIndex = BinarySearch(item);

        // If item is found a one smaller array is made and copies all strings exept taarget index value
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


        }

    }

    // Seaches for "key" in players pockets using binary search
    public bool GetKeuStatus() {
        int reuslt = BinarySearch("key");
        if (reuslt != -1)
        {
            return true;
        }
        else 
        {
            return false;
        }
    }

}
