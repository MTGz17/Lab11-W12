using System;

[System.Serializable]
public class InventoryItem
{
    public int ID;
    public string Name;
    public float Value;

    // Constructor to initialize an inventory item
    public InventoryItem(int id, string name, float value)
    {
        ID = id;
        Name = name;
        Value = value;
    }
}