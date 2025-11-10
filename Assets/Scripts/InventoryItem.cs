using System.Collections.Generic;
using UnityEngine;

public class InventoryItem
{
    public string name;
    public int value;
    public int ID;

    public InventoryItem(string name, int value, int ID)
    {
        this.name = name;
        this.value = value;
        this.ID = ID;
    }
}
