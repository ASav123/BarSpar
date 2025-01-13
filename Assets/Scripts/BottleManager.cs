using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleManager : MonoBehaviour
{
    private List<Safe> bottles = new List<Safe>();

    public GameObject questionMarkPrefab;
    public GameObject fruitPrefab;
    public GameObject beerPrefab;
    public GameObject elixirPrefab;
    public GameObject poisonPrefab;

    void Start()
    {
        Debug.Log("Start method called");
        SpawnBottles(); // This will call SpawnBottles when the game starts
    }

    private void GenerateBottleList()
    {
        bottles.Clear();

        bottles.Add(new Elixir(true, false));
        bottles.Add(new Beer(true, false, new Fruit(true, false)));
        bottles.Add(new Poison(false, false));
        bottles.Add(new Poison(false, false));
        bottles.Add(new Fruit(true, false));
        bottles.Add(new Fruit(true, false));
        bottles.Add(new Fruit(true, false));

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

        // Adjust the spawn position offset
        float xOffset = -5f; // Moves bottles more to the left

        for (int i = 0; i < bottles.Count; i++)
        {
            Vector3 spawnPosition = new Vector3(i * 2 + xOffset, 0, 0);
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
            spriteRenderer.sprite = fruitPrefab.GetComponent<SpriteRenderer>().sprite;
            Debug.Log("Fruit has been consumed.");
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
        }
        else if (bottle is Poison && !((Poison)bottle).GetPoisonIsConsumed())
        {
            ((Poison)bottle).SetPoisonIsConsumed(true);
            spriteRenderer.sprite = poisonPrefab.GetComponent<SpriteRenderer>().sprite;
            Debug.Log("Poison has been consumed.");
        }
    }
}
