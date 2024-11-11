using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InventoryManager : MonoBehaviour
{
    private List<InventoryItem> inventory = new List<InventoryItem>();

    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            inventory.Add(new InventoryItem(
                Random.Range(1, 100),
                "Item" + i,
                Random.Range(1.0f, 100.0f)
            ));
        }

        var item = LinearSearchByName("Item5");
        if (item != null)
        {
            Debug.Log("Found item by name: " + item.Name);
        }

        inventory = inventory.OrderBy(item => item.ID).ToList();
        var binaryItem = BinarySearchByID(5);
        if (binaryItem != null)
        {
            Debug.Log("Found item by ID: " + binaryItem.Name);
        }

        QuickSortByValue(inventory, 0, inventory.Count - 1);
        Debug.Log("Inventory sorted by value:");
        foreach (var i in inventory)
        {
            Debug.Log(i.Name + " - " + i.Value);
        }
    }

    public InventoryItem LinearSearchByName(string itemName)
    {
        foreach (var item in inventory)
        {
            if (item.Name == itemName)
            {
                return item;
            }
        }
        return null;
    }

    public InventoryItem BinarySearchByID(int targetID)
    {
        int left = 0;
        int right = inventory.Count - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (inventory[mid].ID == targetID)
            {
                return inventory[mid];
            }
            else if (inventory[mid].ID < targetID)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        return null;
    }

    public void QuickSortByValue(List<InventoryItem> list, int low, int high)
    {
        if (low < high)
        {
            int pi = Partition(list, low, high);

            QuickSortByValue(list, low, pi - 1);
            QuickSortByValue(list, pi + 1, high);
        }
    }

    private int Partition(List<InventoryItem> list, int low, int high)
    {
        InventoryItem pivot = list[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (list[j].Value < pivot.Value)
            {
                i++;
                // Swap
                var temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }
        }

        var tempPivot = list[i + 1];
        list[i + 1] = list[high];
        list[high] = tempPivot;

        return i + 1;
    }
}