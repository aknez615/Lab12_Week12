using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventoryItem inventoryItem;

    void LinearSearchByName(string itemName)
    {
        if (inventoryItem.items == null)
        {
            Debug.Log("Inventory is empty.");
            return;
        }
    }
}
