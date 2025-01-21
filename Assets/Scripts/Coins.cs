using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] private int wallet; // Serialized field for Inspector visibility

    // Property to access and modify Wallet
    public int Wallet
    {
        get => wallet;
        set
        {
            wallet = value;
            // Sync changes to the Inspector
            SyncInspector();
        }
    }

    // Method to initialize the Wallet value
    public void CoinsCreate(int initialAmount)
    {
        Wallet = initialAmount; // Automatically syncs with Inspector
    }

    public void UpdateCoins(int newAmount)
    {
        Wallet = newAmount; // Automatically syncs with Inspector
    }

    public void ChangeCoins(int amount)
    {
        Wallet += amount; // Automatically syncs with Inspector
    }

    public int GetCoins()
    {
        return Wallet;
    }

    // Sync changes to the Inspector during runtime
    private void SyncInspector()
    {
#if UNITY_EDITOR
        UnityEditor.EditorUtility.SetDirty(this); // Marks the object as dirty to update in the Inspector
#endif
    }

    // This method is called whenever the script is recompiled or when changes are made in the Inspector
    private void OnValidate()
    {
        SyncInspector(); // Ensure the Inspector reflects the current value of wallet
    }
}