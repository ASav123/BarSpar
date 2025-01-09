using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Base class that tells us if a bottle is safe to drink (a property of the bottle). Can be inherited by most bottles (the safe ones)
class Safe
{
    public bool IsSafe;
    public bool IsConsumed;
    public bool IsRevealed;

    public Safe(bool isSafe = true, bool isConsumed = false, bool isRevealed = false)
    {
        this.IsSafe = isSafe;
        this.IsConsumed = isConsumed;
        this.IsRevealed = isRevealed;
    }


    public virtual void OnDrink()
    {
        Debug.Log("You drank from a bottle. Nothing special happened.");
    }
}

class Fruit : Safe
{
    private string _name;

    public Fruit(bool isSafe, bool isConsumed, bool isRevealed) : base(isSafe, isConsumed, isRevealed) // Wine is safe
    {
        this._name = "Fruit";
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
        return this.IsRevealed;
    }

    public void SetFruitIsRevealed(bool isRevealed)
    {
        this.IsRevealed = isRevealed;
    }
}

// Derived class for Beer
class Beer : Safe
{
    private string _name;

    public Beer(bool isSafe, bool isConsumed, bool isRevealed) : base(isSafe, isConsumed, isRevealed) // Beer is safe
    {
        _name = "Beer";
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

    public bool GetBeerIsRevealed()
    {
        return this.IsRevealed;
    }

    public void SetBeerIsRevealed(bool isRevealed)
    {
        this.IsRevealed = isRevealed;
    }
}

// Derived class for Elixir
class Elixir : Safe
{
    private string _name;

    public Elixir(bool isSafe, bool isConsumed, bool isRevealed) : base(isSafe, isConsumed, isRevealed) // Elixir is safe
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

    public bool GetElixirIsRevealed()
    {
        return this.IsRevealed;
    }

    public void SetElixirIsRevealed(bool isRevealed)
    {
        this.IsRevealed = isRevealed;
    }

}

class Poison : Safe
{
    private string _name;

    public Poison(bool isSafe, bool isConsumed, bool isRevealed) : base(isSafe, isConsumed, isRevealed)  // Poison is not safe
    {
        _name = "Poison";
        IsSafe = false;  // Poison is unsafe
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

    public bool GetPoisonIsRevealed()
    {
        return this.IsRevealed;
    }

    public void SetPoisonIsRevealed(bool isRevealed)
    {
        this.IsRevealed = isRevealed;
    }
}

