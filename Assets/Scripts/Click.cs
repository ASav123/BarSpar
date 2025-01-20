using UnityEngine;
using TMPro; // Required for TextMeshPro

public class Click : MonoBehaviour
{
    private Coins _coins;
    private int _wallet;
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
            _wallet = _coins.GetCoins();
            UpdateCoinCounter();
            Debug.Log("Initial wallet value: " + _wallet);
        }
        else
        {
            Debug.LogError("Coins component not found in the scene!");
        }

        // Check if the coinCounterText is assigned
        if (coinCounterText == null)
        {
            Debug.LogError("Coin counter text is not assigned in the Inspector!");
        }
    }

    public void SwordButtonClicked()
    {
        if (_wallet >= 10)
        {
            _wallet -= 10;
            Debug.Log("Sword purchased! Remaining wallet: " + _wallet);
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
        if (_wallet >= 20)
        {
            _wallet -= 20;
            Debug.Log("Gun purchased! Remaining wallet: " + _wallet);
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
        if (_wallet >= 5)
        {
            _wallet -= 5;
            Debug.Log("Health potion purchased! Remaining wallet: " + _wallet);
            UpdateCoinCounter();
        }
        else
        {
            Debug.Log("You're broke!");
        }
    }

    public void LargeHealthPotionButtonClicked()
    {
        if (_wallet >= 10)
        {
            _wallet -= 10;
            Debug.Log("Large health potion purchased! Remaining wallet: " + _wallet);
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
            coinCounterText.text = "Coins: " + _wallet;
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