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

    public static int LinearSearch(string[] arr, string item)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == item)
            {
                return i;
            }
        }
        return -1;
    }

    public static string[] RemoveItem(string[] arr, string item)
    {
        int itemIndex = LinearSearch(arr, item);
        string[] newPockets = new string[arr.Length - 1];
        for (int i = 0; i < arr.Length - 1; i++)
        {
            if (i < itemIndex)
            {
                newPockets[i] = arr[i];
            }
            else if (i > itemIndex)
            {
                newPockets[i - 1] = arr[i];
            }
        }
        return newPockets;
    }

}
