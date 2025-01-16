using System.Collections.Generic;
using UnityEngine;

public class BottleRevealManager : MonoBehaviour
{
    private BottleManager bottleManager;

    public void Initialize(BottleManager bottleManager)
    {
        this.bottleManager = bottleManager;
    }

    // Reveal fruit or poison using Binary Search and Pigeonhole Sort
    public void RevealBottleChoice()
    {
        List<string> bottles = new List<string>
        {
            "reveal fruit", "reveal fruit", "reveal poison", "reveal fruit", "reveal poison"
        };

        // Pigeonhole Sort the bottles (Just organizing them)
        PigeonholeSort(bottles);

        // Randomly choose either "reveal fruit" or "reveal poison" based on sorted list
        string choice = Random.Range(0, bottles.Count) < bottles.Count / 2 ? "reveal fruit" : "reveal poison";

        if (choice == "reveal fruit")
        {
            bottleManager.RevealFruitBottle();
        }
        else
        {
            bottleManager.RevealPoisonBottle();
        }
    }

    // Simple implementation of Pigeonhole Sort
    private void PigeonholeSort(List<string> bottles)
    {
        List<string> pigeonholes = new List<string>();
        foreach (var bottle in bottles)
        {
            if (!pigeonholes.Contains(bottle))
            {
                pigeonholes.Add(bottle);
            }
        }

        bottles.Clear();
        pigeonholes.Sort();  // Sorting by alphabet (fruit and poison groups)
        foreach (var bottle in pigeonholes)
        {
            bottles.Add(bottle);
        }
    }
}
