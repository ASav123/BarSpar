using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemClass
{
    public string ItemName;
    public Sprite ItemIcon;
    // each item has a name and icon 

    public abstract ItemClass GetItem();

    public abstract FishClass Getfish();
    public abstract MiscClass GetMisc();
    public abstract ConsumableClass GetConsumable();



}
