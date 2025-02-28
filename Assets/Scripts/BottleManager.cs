// bawtyl mann-ijir 
//written partially by chatgpt
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleManager : MonoBehaviour
{
    private List<Safe> bottles = new List<Safe>();
    private int consumedFruits = 0; // Track how many fruits have been consumed
    
    public GameObject questionMarkPrefab;
    public GameObject fruitPrefab;
    public GameObject beerPrefab;
    public GameObject elixirPrefab;
    public GameObject poisonPrefab;

    // aggrecation and composition: 
    private Beer beerBottle; // Store the beer bottle reference
    private Scenes _scenes;
    private Coins _coins;


   

    void Start()
    {
        Debug.Log("Start method called");
        
        SpawnBottles(); // This will call SpawnBottles when the game starts
        _scenes = GetComponent<Scenes>();
        _coins = GetComponent<Coins>();
    }

    private void GenerateBottleList()
    {
        bottles.Clear();

        // Create the bottles, including the Beer bottle
        beerBottle = new Beer(true, false, new Fruit(true, false)); // Store the beer bottle reference here
        bottles.Add(new Elixir(true, false));
        bottles.Add(beerBottle);  // Add beer bottle to the list
        bottles.Add(new Poison(false, false));
        bottles.Add(new Poison(false, false));
        bottles.Add(new Fruit(true, false));
        bottles.Add(new Fruit(true, false));
        bottles.Add(new Fruit(true, false));

        // Shuffle the bottles randomly
        for (int i = 0; i < bottles.Count; i++)
        {
            Safe temp = bottles[i];
            int randomIndex = Random.Range(i, bottles.Count);
            bottles[i] = bottles[randomIndex];
            bottles[randomIndex] = temp;
        }
    }

    public void SpawnBottles()
    {
        GenerateBottleList();

        // Adjust the spawn position offset for more space between bottles
        float xOffset = -6f; // Shift the bottles a tad to the left (more negative value)
        float spacing = 2.5f; // Space between bottles

        for (int i = 0; i < bottles.Count; i++)
        {
            Vector3 spawnPosition = new Vector3(i * spacing + xOffset, 0, 0); // Apply offset and spacing
            GameObject bottlePrefab = Instantiate(questionMarkPrefab, spawnPosition, Quaternion.identity);

            // Initialize the bottle with the BottleClick script
            bottlePrefab.GetComponent<BottleClick>().Initialize(bottles[i], this);

            // Set the BoxCollider2D size to (1, 5)
            BoxCollider2D boxCollider = bottlePrefab.GetComponent<BoxCollider2D>();
            if (boxCollider != null)
            {
                boxCollider.size = new Vector2(1, 5); // Set the collider size to (1, 5)
            }

            // The sprite remains as the question mark until revealed
        }
    }


    internal void RevealBottle(GameObject bottleObject, Safe bottle)
    {
        // Access the SpriteRenderer of the clicked bottle
        SpriteRenderer spriteRenderer = bottleObject.GetComponent<SpriteRenderer>();

        if (bottle is Fruit && !((Fruit)bottle).GetFruitIsConsumed())
        {
            ((Fruit)bottle).SetFruitIsConsumed(true);
            consumedFruits++; // Increment consumed fruits count
            spriteRenderer.sprite = fruitPrefab.GetComponent<SpriteRenderer>().sprite;
            Debug.Log("Fruit has been consumed.");

            // Check if three fruits have been consumed
            if (consumedFruits >= 3)
            {
                // Automatically reveal the beer bottle if three fruits are consumed
                ConsumeBeer();
            }
        }
        else if (bottle is Beer && !((Beer)bottle).GetBeerIsConsumed())
        {
            ((Beer)bottle).SetBeerIsConsumed(true);
            spriteRenderer.sprite = beerPrefab.GetComponent<SpriteRenderer>().sprite;
            Debug.Log("Beer has been consumed.");
        }
        else if (bottle is Elixir && !((Elixir)bottle).GetElixirIsConsumed())
        {
            ((Elixir)bottle).SetElixirIsConsumed(true);
            spriteRenderer.sprite = elixirPrefab.GetComponent<SpriteRenderer>().sprite;
            Debug.Log("Elixir has been consumed.");
            this._coins.ChangeCoins(20);
            this._scenes.PlayerDeath()
;
        }
        else if (bottle is Poison && !((Poison)bottle).GetPoisonIsConsumed())
        {
            ((Poison)bottle).SetPoisonIsConsumed(true);
            spriteRenderer.sprite = poisonPrefab.GetComponent<SpriteRenderer>().sprite;
            Debug.Log("Poison has been consumed.");
            this._scenes.PlayerWin();
            this._coins.ChangeCoins(-20);
        }
    }

    // Method to automatically reveal and consume the beer bottle after 3 fruits are consumed
    private void ConsumeBeer()
    {
        if (beerBottle != null && !beerBottle.GetBeerIsConsumed())
        {
            beerBottle.SetBeerIsConsumed(true);
            // Automatically reveal the beer bottle sprite
            GameObject beerBottleObject = FindObjectOfType<BottleClick>().gameObject;
            SpriteRenderer spriteRenderer = beerBottleObject.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = beerPrefab.GetComponent<SpriteRenderer>().sprite;

            // Trigger the beer bottle reveal and consumption
            Debug.Log("Beer automatically consumed and revealed after 3 fruits.");

            EnableColliders();


        }
    }

    private void EnableColliders()
    {
        // Ensure that all bottles still have colliders enabled
        var bottleClickObjects = FindObjectsOfType<BottleClick>();
        foreach (var bottleClick in bottleClickObjects)
        {
            BoxCollider2D boxCollider = bottleClick.GetComponent<BoxCollider2D>();
            if (boxCollider != null)
            {
                boxCollider.enabled = true; // Enable the collider for the bottle
            }
        }
    }
}
