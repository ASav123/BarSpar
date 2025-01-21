using UnityEngine;
using TMPro; // Required for TextMeshPro

public class Click : MonoBehaviour
{
    private Coins _coins;
    private Character _character;
    private bool _hasSword = false;
    private bool _hasGun = false;

    // References to the button GameObjects
    public GameObject swordButton;
    public GameObject gunButton;
    public GameObject healthPotionButton;
    public GameObject largeHealthPotionButton;

    // Reference to the TextMeshProUGUI coin counter
    public TextMeshProUGUI coinCounterText;

    void Start()
    {
        // Get Coins component
        _coins = FindObjectOfType<Coins>();
        if (_coins != null)
        {
            UpdateCoinCounter();
            Debug.Log("Initial wallet value: " + _coins.GetCoins());
        }

        _character = FindObjectOfType<Character>();
    }

    void Update()
    {
        // Get Current Wallet Balance
        Debug.Log("Current Wallet Balance: " + _coins.GetCoins());
        UpdateCoinCounter();
    }

    public void SwordButtonClicked()
    {
        if (_coins.GetCoins() >= 10)
        {
            _coins.ChangeCoins(-10); // Deduct 10 coins from the wallet
            Debug.Log("Sword purchased! Remaining wallet: " + _coins.GetCoins());
            swordButton.SetActive(false);
            UpdateCoinCounter();
            _hasSword = true;
        }
        else
        {
            Debug.Log("You're broke!");
        }
    }

    public void GunButtonClicked()
    {
        if (_coins.GetCoins() >= 20)
        {
            _coins.ChangeCoins(-20); // Deduct 20 coins from the wallet
            Debug.Log("Gun purchased! Remaining wallet: " + _coins.GetCoins());
            gunButton.SetActive(false);
            UpdateCoinCounter();
            _hasGun = true;
        }
        else
        {
            Debug.Log("You're broke!");
        }
    }

    public void HealthPotionButtonClicked()
    {
        if (_coins.GetCoins() >= 5)
        {
            _coins.ChangeCoins(-5); // Deduct 5 coins from the wallet
            Debug.Log("Health potion purchased! Remaining wallet: " + _coins.GetCoins());
            if (_character != null)
            {
                _character.ChangeHealth(20);
            }
            else
            {
                Debug.LogError("Character component is not assigned!");
            }
            UpdateCoinCounter();
        }
        else
        {
            Debug.Log("You're broke!");
        }
    }

    public void LargeHealthPotionButtonClicked()
    {
        if (_coins.GetCoins() >= 10)
        {
            _coins.ChangeCoins(-10); // Deduct 10 coins from the wallet
            Debug.Log("Large health potion purchased! Remaining wallet: " + _coins.GetCoins());
            if (_character != null)
            {
                _character.ChangeHealth(50);
            }
            else
            {
                Debug.LogError("Character component is not assigned!");
            }
            UpdateCoinCounter();
        }
        else
        {
            Debug.Log("You're broke!");
        }
    }

    // Updates the coin counter text
    private void UpdateCoinCounter()
    {
        if (coinCounterText != null)
        {
            coinCounterText.text = "Coins: " + _coins.GetCoins();
        }
        else
        {
            Debug.LogError("Coin counter text reference is missing!");
        }
    }

    public bool DoesHaveSword()
    {
        return _hasSword;
    }

    public bool DoesHaveGun()
    {
        return _hasGun;
    }
}