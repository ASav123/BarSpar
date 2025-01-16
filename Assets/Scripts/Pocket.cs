using System;
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

    public void Main(string[] args)
    {
        string[] sortingOrder = new string[] { "coin", "flower", "heart", "key" };
        string[] pockets = new string[] { "coin", "key", "coin", "heart", "flower", "heart", "heart", "heart", "coin" };
        InstanceSort(pockets);
        foreach (string item in pockets)
        {
            Console.WriteLine(item);
        }
    }

    public void Sort(string[] arr, string[] sortingOrder)
    {
        foreach (string item in sortingOrder)
        {
            for (int cursor = 0; cursor < arr.Length; cursor++)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[cursor] != item && arr[i] == item)
                    {
                        string tempItem = arr[i];
                        arr[i] = arr[cursor];
                        arr[cursor] = tempItem;
                    }

                }
            }
        }
    }

    public void InstanceSort(string[] arr)
    {
        int coinCount = 0;
        int heartCount = 0;
        int flowerCount = 0;
        int keyCount = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == "coin")
            {
                coinCount++;
            }
            else if (arr[i] == "heart")
            {
                heartCount++;
            }
            else if (arr[i] == "flower")
            {
                flowerCount++;
            }
            else
            {
                keyCount++;
            }
        }
        string[] tempArr = new string[4];
        if (coinCount > heartCount)
        {
            tempArr[0] = "coin";
            tempArr[1] = "heart";
        }
        else
        {
            tempArr[0] = "heart";
            tempArr[1] = "coin";
        }
        tempArr[2] = "flower";
        tempArr[3] = "key";

        Sort(arr, tempArr);
    }

    // Make a method that uses this to remove the index from pocket aray
    public int BinarySearch(string[] arr, string target)
    {
        int left = 0;
        int right = arr.Length - 1;

        while (left <= right)
        {
            int mid = (left + right) / 2;
            int comparison = string.Compare(arr[mid], target, System.StringComparison.Ordinal);

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

}
