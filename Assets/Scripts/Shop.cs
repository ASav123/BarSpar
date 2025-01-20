using UnityEngine;

public class Shop : MonoBehaviour
{
    private Coins _coins;
    private Player _player;
    private Click _click;
    private DifficultySelection _difficultySelection;
    
    private int _wallet;
    private int _health;
    private bool _hasSword;
    private bool _hasGun;
    private int _weaponChanges = 0;
    private int _previousWeapons = 0;

    // References to the spotlight GameObjects
    public GameObject spotlightSword;
    public GameObject spotlightGun;
    public GameObject spotlightHealthPotion;
    public GameObject spotlightLargeHealthPotion;

    void Start() 
    {
        _coins = GetComponent<Coins>();
        _player = GetComponent<Player>();
        _click = GetComponent<Click>();
        _difficultySelection = GetComponent<DifficultySelection>();
        
        // Get Current Player Health
        _health = _difficultySelection.GetPlayerHealth();
        Debug.Log("Current Player Health: " + _health);

        _hasSword = _click.DoesHaveSword();
        _hasGun = _click.DoesHaveGun();

    }

    void Update()
    {
        // Get Current Wallet Balance
        _wallet = _coins.GetCoins();
        Debug.Log("Current Wallet Balance: " + _wallet);

        if (_weaponChanges != _previousWeapons) 
        {
            
            
            _previousWeapons = _weaponChanges;
        }
    }

}
