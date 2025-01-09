using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FishClass : ItemClass
{
    public override ItemClass GetItem() { return this; }

    public override FishClass GetFish() { return this; }
    public override FishClass GetMisc() { return null; }
    public override FishClass GetConsumable() { return null; }
}
