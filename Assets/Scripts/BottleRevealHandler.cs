using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleReveal : MonoBehaviour
{
    public GameObject fruitPrefab;
    public GameObject poisonPrefab;

    // Method to generate an array and reveal a bottle
    public void RevealRandomBottle()
    {
        // Step 1: Generate an array with random "reveal poison" or "reveal fruit"
        string[] actions = new string[5];
        for (int i = 0; i < actions.Length; i++)
        {
            actions[i] = Random.Range(0, 2) == 0 ? "reveal poison" : "reveal fruit";
        }

        // Step 2: Pigeonhole Sort the list
        PigeonholeSort(actions);

        // Step 3: Randomly pick a "reveal poison" or "reveal fruit"
        string chosenAction = actions[Random.Range(0, actions.Length)];

        // Step 4: Binary search for the chosen action
        int index = BinarySearch(actions, chosenAction);

        // Step 5: Reveal the bottle based on the binary search result
        if (actions[index] == "reveal poison")
        {
            RevealPoison();
        }
        else if (actions[index] == "reveal fruit")
        {
            RevealFruit();
        }
    }

    // Pigeonhole Sort Implementation
    private void PigeonholeSort(string[] array)
    {
        int min = 0;
        int max = 1;

        List<string>[] holes = new List<string>[max - min + 1];
        for (int i = 0; i < holes.Length; i++)
        {
            holes[i] = new List<string>();
        }

        foreach (var item in array)
        {
            int index = item == "reveal fruit" ? 0 : 1; // 0 for fruit, 1 for poison
            holes[index].Add(item);
        }

        int index2 = 0;
        foreach (var hole in holes)
        {
            foreach (var item in hole)
            {
                array[index2++] = item;
            }
        }
    }

    // Binary Search for non-integer values
    private int BinarySearch(string[] array, string target)
    {
        int low = 0, high = array.Length - 1;
        while (low <= high)
        {
            int mid = (low + high) / 2;
            int comparison = string.Compare(array[mid], target);
            if (comparison == 0) return mid;
            if (comparison < 0) low = mid + 1;
            else high = mid - 1;
        }
        return -1; // Not found
    }

    // Method to reveal a fruit bottle
    private void RevealFruit()
    {
        // Spawn fruit prefab (adjust the position as needed)
        Instantiate(fruitPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    // Method to reveal a poison bottle
    private void RevealPoison()
    {
        // Spawn poison prefab (adjust the position as needed)
        Instantiate(poisonPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
