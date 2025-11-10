using UnityEngine;
using System.Collections.Generic;
using System.Collections.Concurrent;

public class InventoryManager : MonoBehaviour
{
    public List<InventoryItem> inventory = new List<InventoryItem>();
    public string itemNameToFind = "Potion";

    private void Start()
    {
        InitializeInventory();

        int searchID = inventory[Random.Range(0, inventory.Count)].ID;
        var item = LinearSearchByName(itemNameToFind);

        if (item != null)
        {
            Debug.Log($"Found item {item.name} (ID: {item.ID}, Value: {item.value})");
        }
        else
        {
            Debug.Log($"Item not found");
        }

        QuickSortByValue(inventory);
        Debug.Log("Sorting by value:");
        PrintInventory();

        InventoryItem itemByID = BinarySearchByID(searchID);
        Debug.Log("Sorting by ID:");
        PrintInventory();
    }

    void InitializeInventory()
    {
        string[] itemNames = { "Potion", "Sack", "Armor", "Sword", "Vampire Dust", "Spell Book", "Bow" };
        System.Random rand = new System.Random();

        for (int i = 0; i < 10; i++)
        {
            string name = itemNames[rand.Next(itemNames.Length)];
            int value = rand.Next(1, 999);
            int ID = rand.Next(1, 8);
            inventory.Add(new InventoryItem(name, value, ID));
        }
    }

    InventoryItem BinarySearchByID(int ID)
    {
        inventory.Sort((a, b) => a.ID.CompareTo(b.ID));

        int low = 0;
        int high = inventory.Count - 1;

        while (low <= high)
        {
            int mid = (low + high) / 2;

            if (inventory[mid].ID == ID)
            {
                return inventory[mid];
            }
            else if (inventory[mid].ID < ID)
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }
        return null;
    }

    InventoryItem LinearSearchByName(string itemName)
    {
        foreach (var item in inventory)
        {
            if (item.name == itemName)
            {
                return item;
            }
        }
        return null;
    }

    void QuickSortByValue(List<InventoryItem> list)
    {
        QuickSort(list, 0, list.Count - 1);
    }

    void QuickSort(List<InventoryItem> list, int low, int high)
    {
        if (low < high)
        {
            int pivotIndex = Partition(list, low, high);
            QuickSort(list, low, pivotIndex - 1);
            QuickSort(list, pivotIndex + 1, high);
        }
    }

    int Partition(List<InventoryItem> list, int low, int high)
    {
        int pivot = list[high].value;
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (list[j].value <= pivot)
            {
                i++;
                Swap(list, i, j);
            }
        }
        Swap(list, i + 1, high);
        return i + 1;
    }

    void Swap(List<InventoryItem> list, int i, int j)
    {
        InventoryItem temp = list[i];
        list[i] = list[j];
        list[j] = temp;
    }

    void PrintInventory()
    {
        foreach (var item in inventory)
        {
            Debug.Log($"ID: {item.ID}, Name: {item.name}, Value: {item.value}");
        }
    }
}
