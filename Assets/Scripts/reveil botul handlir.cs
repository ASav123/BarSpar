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

        // Step 2: Pigeon hole Sort
        PigeonholeSort(actions);

        // Step 3: Randomly pick a "reveal poison" or "reveal fruit"
        string chosenAction = actions[Random.Range(0, actions.Length)];

        // Step 4: Binary search 
        int index = BinarySearch(actions, chosenAction);

        // Step 5: Reveal the bottle based on whether my code gets "revel poison" or "reveal fruit"
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
        //  two buckets: "reveal fruit" and"reveal poison"
        List<string>[] holes = new List<string>[2];
        holes[0] = new List<string>(); // reveal fruit
        holes[1] = new List<string>(); // reveal poison

        // put each item in its bucket
        foreach (var item in array)
        {
            if (item == "reveal fruit")
                holes[0].Add(item);  // Add "reveal fruit" to the first bucket
            else
                holes[1].Add(item);  // Add "reveal poison" to the second bucket
        }

        // put the two buckets tgt and get the array
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
        int left = 0, right = array.Length - 1;
        while (left <= right)
        {
            int mid = ( left + right) / 2;
            int comparison = string.Compare(array[mid], target);  // Compare strings directly
            if (comparison == 0)
            {
                return mid;
            }
            if (comparison < 0)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
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
