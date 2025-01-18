//botl class
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Base class that tells us if a bottle is safe to drink (a property of the bottle). Can be inherited by most bottles (the safe ones)
public class Safe
{
    public bool IsSafe;
    public bool IsConsumed;

    public Safe(bool isSafe = true, bool isConsumed = false)
    {
        this.IsSafe = isSafe;
        this.IsConsumed = isConsumed;
    }

    public virtual void OnDrink()
    {
        Debug.Log("You drank from a bottle. Nothing special happened.");
    }

    public bool GetIsSafe()
    {
        return this.IsSafe;
    }

    public bool GetIsConsumed()
    {
        return this.IsConsumed;
    }

    public void SetIsConsumed(bool isConsumed)
    {
        this.IsConsumed = isConsumed;
    }
}

public class Fruit : Safe
{
    private string _name;
    private bool _isRevealed;

    public Fruit(bool isSafe, bool isConsumed) : base(isSafe, isConsumed)
    {
        this._name = "Fruit";
        this._isRevealed = false;
    }

    public string GetFruitName()
    {
        return this._name;
    }

    public bool GetFruitIsSafe()
    {
        return this.IsSafe;
    }

    public bool GetFruitIsConsumed()
    {
        return this.IsConsumed;
    }

    public void SetFruitIsConsumed(bool isConsumed)
    {
        this.IsConsumed = isConsumed;
    }

    public bool GetFruitIsRevealed()
    {
        return this._isRevealed;
    }

    public void SetFruitIsRevealed(bool isRevealed)
    {
        this._isRevealed = isRevealed;
    }
}


public class Beer : Safe
{
    private string _name;
    private Fruit _fruit; // Aggregating a fruit object inside the beer, because the fruit and beer need to be connected in order for the beer to reveal the position of a fruit. However, since if all fruits are eaten, the beer is rendered useless, I will make the beer disappear as well when the fruit is eaten

    public Beer(bool isSafe, bool isConsumed, Fruit fruit) : base(isSafe, isConsumed)
    {
        _name = "Beer";
        _fruit = fruit;
    }

    public string GetBeerName()
    {
        return _name;
    }

    public bool GetBeerIsSafe()
    {
        return this.IsSafe;
    }

    public bool GetBeerIsConsumed()
    {
        return this.IsConsumed;
    }

    public void SetBeerIsConsumed(bool isConsumed)
    {
        this.IsConsumed = isConsumed;
    }

    // Checking if fruit is consumed, if all three are consumed, then so will the beer
    public void CheckAndConsumeBeer()
    {
        if (_fruit.GetFruitIsConsumed()) // If the fruit is consumed
        {
            SetBeerIsConsumed(true);
            Debug.Log("The fruit was consumed, now the beer is consumed!");
        }
    }
}

class Elixir : Safe
{
    private string _name;

    public Elixir(bool isSafe, bool isConsumed) : base(isSafe, isConsumed) // Elixir is safe
    {
        _name = "Elixir";
    }

    public string GetElixirName()
    {
        return _name;
    }

    public bool GetElixirIsSafe()
    {
        return this.IsSafe;
    }

    public bool GetElixirIsConsumed()
    {
        return this.IsConsumed;
    }

    public void SetElixirIsConsumed(bool isConsumed)
    {
        this.IsConsumed = isConsumed;
    }
}

class Poison : Safe
{
    private string _name;

    public Poison(bool isSafe, bool isConsumed) : base(isSafe, isConsumed)  // Poison is not safe
    {
        _name = "Poison";
        IsSafe = false;  // Poison is unsafe, so here I overrode the inheritance and made isSafe to false.
    }

    public string GetPoisonName()
    {
        return _name;
    }

    public bool GetPoisonIsSafe()
    {
        return this.IsSafe;
    }

    public bool GetPoisonIsConsumed()
    {
        return this.IsConsumed;
    }

    public void SetPoisonIsConsumed(bool isConsumed)
    {
        this.IsConsumed = isConsumed;
    }
}
