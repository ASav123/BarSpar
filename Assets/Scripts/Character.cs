using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    //Common attributes for all game characters like player and enemies
    private string _name;
    private int _maxHealth;
    private int _health;
    private int _damage;
    
    //Base constrctor 
    public void CharacterCreate(string name, int health, int maxHealth, int damage) {
        this._name = name;
        this._health = health;
        this._maxHealth = maxHealth;
        this._damage = damage; 
    }

    //Getters and setters

    // Name
    public string GetName() {
        return this._name;
    }

    // Health
    public int GetHealth() {
        return this._health;
    }

    public void ChangeHealth(int changeBy) {
        if ((changeBy + this._health) > this._maxHealth)
        {
            this._health = this._maxHealth;
        }
        else if ((changeBy + this._health) < 0)
        {
            this._health = 0;
        }
        else {
            this._health += changeBy;
        }
    }

    // Damage
    public int GetDamage() {
        return this._damage;
    }

    public void ChangeDamage(int changeBy) {
        if ((changeBy + this._damage) < 0) {
            this._damage = 0;
        }
    }


}
