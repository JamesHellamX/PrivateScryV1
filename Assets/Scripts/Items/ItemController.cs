using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public Item item;

    public InventoryManager inventoryManager;

    public void RemoveItem()
    {
        InventoryManager.Instance.Remove(item);

        Destroy(gameObject);
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
    }

    public void UseItem()
    {
        if (item != null)
        {
            // Apply the effects of the item
            //ItemEffects.Instance.UseItemEffect(item.itemID);

            // Remove the item from the inventory
            inventoryManager.Remove(item);
        }
        else
        {
            Debug.LogWarning("Item is null.");
        }
    }
}
