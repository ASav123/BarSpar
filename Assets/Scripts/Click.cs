using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour
{
    public Button swordButton;
    public Button gunButton;
    public Button healthPotionButton;
    public Button largeHealthPotionButton;

    private Coins _coins;
    private Player _player;
    private int wallet;

    void Start()
    {
        swordButton.onClick.AddListener(SwordButtonClicked);
        gunButton.onClick.AddListener(GunButtonClicked);
        healthPotionButton.onClick.AddListener(HealthPotionButtonClicked);
        largeHealthPotionButton.onClick.AddListener(LargeHealthPotionButtonClicked);

        _coins = GetComponent<Coins>();
        _player = GetComponent<Player>();

        wallet = _coins.Wallet; // Assuming Wallet is a public property in Coins class
    }

    void SwordButtonClicked()
    {
        if (wallet >= 10)
        {
            wallet -= 10;
            _coins.UpdateCoins(wallet); // Update the Coins object
            swordButton.gameObject.SetActive(false);
        }
    }

    void GunButtonClicked()
    {
        if (wallet >= 20)
        {
            wallet -= 20;
            _coins.UpdateCoins(wallet); // Update the Coins object
            gunButton.gameObject.SetActive(false);
        }
    }

    void HealthPotionButtonClicked()
    {
        if (wallet >= 5)
        {
            wallet -= 5;
            _coins.UpdateCoins(wallet); // Update the Coins object
            healthPotionButton.gameObject.SetActive(false);
        }
    }

    void LargeHealthPotionButtonClicked()
    {
        if (wallet >= 10)
        {
            wallet -= 10;
            _coins.UpdateCoins(wallet); // Update the Coins object
            largeHealthPotionButton.gameObject.SetActive(false);
        }
    }
}