using UnityEngine;

public class BottleClick : MonoBehaviour
{
    private Safe bottle;
    private BottleManager bottleManager;

    // References to other scripts
    private Player player;
    private Coins coins;
    private Scenes scenes;

    // Initialize method to assign the bottle and BottleManager reference
    public void Initialize(Safe bottle, BottleManager bottleManager)
    {
        this.bottle = bottle;
        this.bottleManager = bottleManager;
    }

    private void Start()
    {
        // Get references to required scripts
        player = FindObjectOfType<Player>();
        coins = FindObjectOfType<Coins>();
        scenes = FindObjectOfType<Scenes>();
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
            if (!((Fruit)bottle).GetFruitIsConsumed())
            {
                ((Fruit)bottle).SetFruitIsConsumed(true);
                Debug.Log("Fruit has been consumed.");
            }
        }
        else if (bottle is Beer)
        {
            if (!((Beer)bottle).GetBeerIsConsumed())
            {
                ((Beer)bottle).SetBeerIsConsumed(true);
                Debug.Log("Beer has been consumed.");
            }
        }
        else if (bottle is Elixir)
        {
            if (!((Elixir)bottle).GetElixirIsConsumed())
            {
                ((Elixir)bottle).SetElixirIsConsumed(true);
                Debug.Log("Elixir has been consumed.");

                // Gain 20 health and 20 coins, then go to win scene
                player.ChangeHealth(20);
                coins.ChangeCoins(20);
                scenes.PlayerWin();
            }
        }
        else if (bottle is Poison)
        {
            if (!((Poison)bottle).GetPoisonIsConsumed())
            {
                ((Poison)bottle).SetPoisonIsConsumed(true);
                Debug.Log("Poison has been consumed.");

                // Lose 20 health and 20 coins, then go to loose scene
                player.ChangeHealth(-20);
                coins.ChangeCoins(-20);
                scenes.PlayerDeath();
            }
        }
    }
}
