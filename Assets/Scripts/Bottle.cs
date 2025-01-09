using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Derived class for Wine
class WineChalice : Safe
{
    private string _name;

    public WineChalice(string name, bool isSafe) : base(isSafe) // Wine is safe
    {
        this._name = name;
    }

    public string GetName()
    {
        return this._name;
    }

    public void SetName(string name)
    {
        this._name = name;
    }
}

// Derived class for Beer
class BeerChalice : Safe
{
    private string _name;

    public BeerChalice(string name, bool isSafe) : base(isSafe) // Beer is safe
    {
        _name = name;
    }

    public string GetName()
    {
        return _name;
    }

    public void SetName(string name)
    {
        _name = name;
    }
}

// Derived class for Elixir
class ElixirChalice : Safe
{
    private string _name;

    public ElixirChalice(string name, bool isSafe) : base(isSafe) // Elixir is safe
    {
        _name = name;
    }

    public string GetName()
    {
        return _name;
    }

    public void SetName(string name)
    {
        _name = name;
    }
}

