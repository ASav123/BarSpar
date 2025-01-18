using UnityEngine;

public class Coins : MonoBehaviour
{
    public int Wallet = 5000;

    public void CoinsCreate(int initialAmount)
    {
        Wallet = initialAmount;
    }

    public void UpdateCoins(int newAmount)
    {
        Wallet = newAmount;
    }

    public void ChangeCoins(int amount)
    {
        Wallet += amount;
    }

    public int GetCoins() {
        return Wallet;
    }
}