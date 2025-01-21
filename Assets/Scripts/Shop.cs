using UnityEngine;

public class Shop : MonoBehaviour
{
    private Coins _coins;
    private Click _click;
    private DifficultySelection _difficultySelection;
    
    private int _wallet;
    private int _health;
    private bool _hasSword;
    private bool _hasGun;
    private int _difficulty;
    private int _maxHealth;
    private int _diffrenceHealth;

    private int _Sword;
    private int _Gun;
    private int _HealthPotion;
    private int _LargeHealthPotion;

    // References to the spotlight GameObjects
    public GameObject spotlightSword;
    public GameObject spotlightGun;
    public GameObject spotlightHealthPotion;
    public GameObject spotlightLargeHealthPotion;

    void Start() 
    {
        _coins = GetComponent<Coins>();
        _click = GetComponent<Click>();
        _difficultySelection = GetComponent<DifficultySelection>();

        _difficulty = _difficultySelection.GetDifficulty();

        // Determines Max Health in Respect to Difficulty
        if (_difficulty == 0) {
            this._maxHealth = 50;
        } else {
            this._maxHealth = 100;
        }
    }

    void Update()
    {
        // Get Current Wallet Balance
        _wallet = _coins.GetCoins();
        Debug.Log("Current Wallet Balance: " + _wallet);

        // Get Current Player Health
        _health = _difficultySelection.GetPlayerHealth();
        Debug.Log("Current Player Health: " + _health);

        // Determines Which Potion Is Best To Buy
        _diffrenceHealth = _maxHealth - _health;
        if (_diffrenceHealth >= 50) {
            _LargeHealthPotion = 10;
            _HealthPotion = 5;
        } else if (_diffrenceHealth >= 20 && _diffrenceHealth < 50) {
            _LargeHealthPotion = 0;
            _HealthPotion = 5;
        } else if (_diffrenceHealth >= 10 && _diffrenceHealth < 20) {
            _LargeHealthPotion = 0;
            _HealthPotion = 3;
        } else {
            _LargeHealthPotion = 0;
            _HealthPotion = 1;
        }

        // If Really Low Health, Incentivises Purchase of Potion
        if (_health < 5) {
            _LargeHealthPotion *= 3;
            _HealthPotion *= 3;
        }

        // Get Whether Or Not You Have Which Weapon
        _hasSword = _click.DoesHaveSword();
        _hasGun = _click.DoesHaveGun();

        _Sword = _hasSword ? 0 : 10;
        _Gun = _hasGun ? 0 : 20;

        // If Has No Weapons, Incentivises The Player To Buy One
        if (!_hasGun && !_hasSword) {
            _Sword = 20;
            _Gun = 40;
        }

        // Determines What You Can Afford
        if (_wallet <= 5) {
            _Sword = 0;
            _Gun = 0;
            _LargeHealthPotion = 0;
        } else if (_wallet <= 10 && _wallet > 5) {
            _Sword = 0;
            _Gun = 0;
        } else {
            _Gun = 0;
        }

        // Creates Arrays To Be Sorted
        int[] items = { _Sword, _Gun, _HealthPotion, _LargeHealthPotion };

        // Sorts The Items From Lowest to Highest In Terms Of How Good It Is For You
        MergeSort(items, 0, items.Length - 1);

        // Ensure the array has enough elements before accessing indices
        if (items.Length > 3) {
            if (items[3] == 0) {
                DisableAllSpotlights();
            } else {
                if (items[3] > items[2]) {
                    HandleSpotlights(items, 3, 2, 1, 0);
                } else if (items[3] == items[2]) {
                    HandleSpotlights(items, 3, 2, 1, 0, true);
                } else {
                    DisableAllSpotlights();
                }
            }
        }
    }

    void HandleSpotlights(int[] items, int index1, int index2, int index3, int index4, bool includeEqual = false)
    {
        TurnOnSpotlights(items, index1, _Sword, _Gun, _HealthPotion, _LargeHealthPotion);
        if (includeEqual) TurnOnSpotlights(items, index2, _Sword, _Gun, _HealthPotion, _LargeHealthPotion);
        TurnOffSpotlights(items, index3, _Sword, _Gun, _HealthPotion, _LargeHealthPotion);
        TurnOffSpotlights(items, index4, _Sword, _Gun, _HealthPotion, _LargeHealthPotion);
    }

    void DisableAllSpotlights()
    {
        spotlightSword.SetActive(false);
        spotlightGun.SetActive(false);
        spotlightHealthPotion.SetActive(false);
        spotlightLargeHealthPotion.SetActive(false);
    }

    void TurnOnSpotlights(int[] items, int index, int Sword, int Gun, int HealthPotion, int LargeHealthPotion)
    {
        if (index < items.Length) {
            if (items[index] == Sword) spotlightSword.SetActive(true);
            if (items[index] == Gun) spotlightGun.SetActive(true);
            if (items[index] == HealthPotion) spotlightHealthPotion.SetActive(true);
            if (items[index] == LargeHealthPotion) spotlightLargeHealthPotion.SetActive(true);
        }
    }

    void TurnOffSpotlights(int[] items, int index, int Sword, int Gun, int HealthPotion, int LargeHealthPotion)
    {
        if (index < items.Length) {
            if (items[index] == Sword) spotlightSword.SetActive(false);
            if (items[index] == Gun) spotlightGun.SetActive(false);
            if (items[index] == HealthPotion) spotlightHealthPotion.SetActive(false);
            if (items[index] == LargeHealthPotion) spotlightLargeHealthPotion.SetActive(false);
        }
    }

    static void MergeSort(int[] array, int left, int right) {
        if (left < right) {
            // Find the middle point
            int middle = (left + right) / 2;

            // Recursively sort the first and second halves
            MergeSort(array, left, middle);
            MergeSort(array, middle + 1, right);

            // Merge the sorted halves
            Merge(array, left, middle, right);
        }
    }

    static void Merge(int[] array, int left, int middle, int right) {
        // Sizes of the two subarrays
        int n1 = middle - left + 1;
        int n2 = right - middle;

        // Temporary arrays
        int[] leftArray = new int[n1];
        int[] rightArray = new int[n2];

        // Copy data to temporary arrays
        for (int i = 0; i < n1; i++)
            leftArray[i] = array[left + i];
        for (int j = 0; j < n2; j++)
            rightArray[j] = array[middle + 1 + j];

        // Merge the temporary arrays back into the original array
        int iIndex = 0, jIndex = 0; // Initial indexes for left and right subarrays
        int k = left; // Initial index for merged array

        while (iIndex < n1 && jIndex < n2)
        {
            if (leftArray[iIndex] <= rightArray[jIndex])
            {
                array[k] = leftArray[iIndex];
                iIndex++;
            }
            else
            {
                array[k] = rightArray[jIndex];
                jIndex++;
            }
            k++;
        }

        // Copy remaining elements of leftArray[], if any
        while (iIndex < n1)
        {
            array[k] = leftArray[iIndex];
            iIndex++;
            k++;
        }

        // Copy remaining elements of rightArray[], if any
        while (jIndex < n2)
        {
            array[k] = rightArray[jIndex];
            jIndex++;
            k++;
        }
    }

}
