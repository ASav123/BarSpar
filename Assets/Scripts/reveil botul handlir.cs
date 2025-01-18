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

    // Pigeonhole Sort Implementation (Prioritize "reveal fruit")
    private void PigeonholeSort(string[] array)
    {
        // Create two buckets: one for "reveal fruit" and one for "reveal poison"
        List<string>[] holes = new List<string>[2];
        holes[0] = new List<string>(); // for "reveal fruit"
        holes[1] = new List<string>(); // for "reveal poison"

        // Step through the array and categorize each item into its respective bucket
        foreach (var item in array)
        {
            if (item == "reveal fruit")
                holes[0].Add(item);  // Add "reveal fruit" to the first bucket
            else
                holes[1].Add(item);  // Add "reveal poison" to the second bucket
        }

        // Reconstruct the array: first add "reveal fruit" from the first bucket, then "reveal poison" from the second
        int index = 0;
        foreach (var hole in holes)
        {
            foreach (var item in hole)
            {
                array[index++] = item;
            }
        }
    }

    // Binary Search (search for "reveal fruit" or "reveal poison")
    private int BinarySearch(string[] array, string target)
    {
        int low = 0, high = array.Length - 1;
        while (low <= high)
        {
            int mid = (low + high) / 2;
            int comparison = string.Compare(array[mid], target);  // Compare strings directly
            if (comparison == 0)
            {
                return mid;
            }
            if (comparison < 0)
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }
        return -1; // If not found, return -1
    }

    // written by chatgpt
    private void RevealFruit()
    {
        Instantiate(fruitPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    // Method to reveal a poison bottle
    private void RevealPoison()
    {

        Instantiate(poisonPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

}
