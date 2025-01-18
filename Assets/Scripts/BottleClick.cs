// boddl cilck
using UnityEngine;
// written by chatgpt
public class BottleClick : MonoBehaviour
{
    private Safe bottle;
    private BottleManager bottleManager;

    // Initialize method to assign the bottle and BottleManager reference
    public void Initialize(Safe bottle, BottleManager bottleManager)
    {
        this.bottle = bottle;
        this.bottleManager = bottleManager;
    }

    // When the bottle is clicked
    private void OnMouseDown()
    {
        bottleManager.RevealBottle(gameObject, bottle); // Reveal the clicked bottle
        HandleBottleConsumption(); // Handle its consumption
    }

    private void HandleBottleConsumption()
    {
        if (bottle is Fruit)
        {
            // Using getter and setter for the fruit bottle
            if (!((Fruit)bottle).GetFruitIsConsumed())
            {
                ((Fruit)bottle).SetFruitIsConsumed(true);
                Debug.Log("Fruit has been consumed.");
            }
        }
        else if (bottle is Beer)
        {
            // Using getter and setter for the beer bottle
            if (!((Beer)bottle).GetBeerIsConsumed())
            {
                ((Beer)bottle).SetBeerIsConsumed(true);
                Debug.Log("Beer has been consumed.");
            }
        }
        else if (bottle is Elixir)
        {
            // Using getter and setter for the elixir bottle
            if (!((Elixir)bottle).GetElixirIsConsumed())
            {
                ((Elixir)bottle).SetElixirIsConsumed(true);
                Debug.Log("Elixir has been consumed.");
            }
        }
        else if (bottle is Poison)
        {
            // Using getter and setter for the poison bottle
            if (!((Poison)bottle).GetPoisonIsConsumed())
            {
                ((Poison)bottle).SetPoisonIsConsumed(true);
                Debug.Log("Poison has been consumed.");
            }
        }
    }
}

