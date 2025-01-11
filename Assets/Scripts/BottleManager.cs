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

        SpawnBottles();  // This will call SpawnBottles when the game starts
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

        for (int i = 0; i < bottles.Count; i++)
        {
            GameObject bottlePrefab = Instantiate(questionMarkPrefab, new Vector3(i * 2, 0, 0), Quaternion.identity);

            bottlePrefab.GetComponent<BottleClick>().Initialize(bottles[i], this);

            if (bottles[i] is Fruit)
                bottlePrefab.GetComponent<SpriteRenderer>().sprite = fruitPrefab.GetComponent<SpriteRenderer>().sprite;
            else if (bottles[i] is Beer)
                bottlePrefab.GetComponent<SpriteRenderer>().sprite = beerPrefab.GetComponent<SpriteRenderer>().sprite;
            else if (bottles[i] is Elixir)
                bottlePrefab.GetComponent<SpriteRenderer>().sprite = elixirPrefab.GetComponent<SpriteRenderer>().sprite;
            else if (bottles[i] is Poison)
                bottlePrefab.GetComponent<SpriteRenderer>().sprite = poisonPrefab.GetComponent<SpriteRenderer>().sprite;
        }

    }

    internal void RevealBottle(GameObject bottleObject, Safe bottle)
    {
        if (bottle is Fruit && !((Fruit)bottle).GetFruitIsConsumed())
        {
            ((Fruit)bottle).SetFruitIsConsumed(true);
            Debug.Log("Fruit has been consumed.");
        }
        else if (bottle is Beer && !((Beer)bottle).GetBeerIsConsumed())
        {
            ((Beer)bottle).SetBeerIsConsumed(true);
            Debug.Log("Beer has been consumed.");
        }
        else if (bottle is Elixir && !((Elixir)bottle).GetElixirIsConsumed())
        {
            ((Elixir)bottle).SetElixirIsConsumed(true);
            Debug.Log("Elixir has been consumed.");
        }
        else if (bottle is Poison && !((Poison)bottle).GetPoisonIsConsumed())
        {
            ((Poison)bottle).SetPoisonIsConsumed(true);
            Debug.Log("Poison has been consumed.");
        }
    }
}
