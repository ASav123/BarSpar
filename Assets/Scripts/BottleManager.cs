using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleManager : MonoBehaviour
{
    // List to hold all the bottles
    private List<Safe> bottles = new List<Safe>();

    // Public prefab references
    public GameObject questionMarkPrefab;  // For the question mark image
    public GameObject fruitPrefab;         // For fruit bottle
    public GameObject beerPrefab;          // For beer bottle
    public GameObject elixirPrefab;        // For elixir bottle
    public GameObject poisonPrefab;        // For poison bottle

    // Function to generate a random order of bottles (elixir, beer, poisons, fruits)
    private void GenerateBottleList()
    {
        // Clear the list to avoid duplicate entries if GenerateBottleList() is called more than once
        bottles.Clear();

        // Add the different bottles to the list (1 elixir, 1 beer, 2 poisons, 3 fruits)
        bottles.Add(new Elixir(true, false));
        bottles.Add(new Beer(true, false, new Fruit(true, false)));  // Aggregating Fruit in Beer
        bottles.Add(new Poison(false, false));
        bottles.Add(new Poison(false, false));
        bottles.Add(new Fruit(true, false));
        bottles.Add(new Fruit(true, false));
        bottles.Add(new Fruit(true, false));

        // Shuffle the list randomly
        for (int i = 0; i < bottles.Count; i++)
        {
            Safe temp = bottles[i];
            int randomIndex = Random.Range(i, bottles.Count);
            bottles[i] = bottles[randomIndex];
            bottles[randomIndex] = temp;
        }
    }

    // Function to spawn the bottles on the screen (use prefab here)
    public void SpawnBottles()
    {
        // Generate the list of bottles (called on start of the game)
        GenerateBottleList();

        // Loop through the list and spawn the bottles (for example, on a straight line)
        for (int i = 0; i < bottles.Count; i++)
        {
            // Create a question mark prefab (this could be a GameObject you have in your project)
            GameObject bottlePrefab = Instantiate(questionMarkPrefab, new Vector3(i * 2, 0, 0), Quaternion.identity) as GameObject;

            // Set the bottle object for the bottlePrefab (this could be passed as a reference)
            bottlePrefab.GetComponent<BottleClick>().Initialize(bottles[i], this);

            // Replace the question mark with the appropriate bottle prefab
            if (bottles[i] is Fruit)
            {
                bottlePrefab.GetComponent<SpriteRenderer>().sprite = fruitPrefab.GetComponent<SpriteRenderer>().sprite;
            }
            else if (bottles[i] is Beer)
            {
                bottlePrefab.GetComponent<SpriteRenderer>().sprite = beerPrefab.GetComponent<SpriteRenderer>().sprite;
            }
            else if (bottles[i] is Elixir)
            {
                bottlePrefab.GetComponent<SpriteRenderer>().sprite = elixirPrefab.GetComponent<SpriteRenderer>().sprite;
            }
            else if (bottles[i] is Poison)
            {
                bottlePrefab.GetComponent<SpriteRenderer>().sprite = poisonPrefab.GetComponent<SpriteRenderer>().sprite;
            }
        }
    }

    // Function to handle the reveal and action when a bottle is clicked
    internal void RevealBottle(GameObject bottleObject, Safe bottle)
    {
        // Access the bottle type and replace the question mark with the correct sprite or model
        if (bottle is Fruit)
        {
            // Using the getter to check if it's consumed
            if (!((Fruit)bottle).GetFruitIsConsumed())
            {
                ((Fruit)bottle).SetFruitIsConsumed(true);  // Using the setter to mark it as consumed
                Debug.Log("Fruit has been consumed.");
            }
        }
        else if (bottle is Beer)
        {
            // Using the getter/setter to consume the beer
            if (!((Beer)bottle).GetBeerIsConsumed())
            {
                ((Beer)bottle).SetBeerIsConsumed(true);
                Debug.Log("Beer has been consumed.");
            }
        }
        else if (bottle is Elixir)
        {
            // Using the getter/setter to consume the elixir
            if (!((Elixir)bottle).GetElixirIsConsumed())
            {
                ((Elixir)bottle).SetElixirIsConsumed(true);
                Debug.Log("Elixir has been consumed.");
            }
        }
        else if (bottle is Poison)
        {
            // Using the getter/setter to consume the poison
            if (!((Poison)bottle).GetPoisonIsConsumed())
            {
                ((Poison)bottle).SetPoisonIsConsumed(true);
                Debug.Log("Poison has been consumed.");
            }
        }
    }
}
