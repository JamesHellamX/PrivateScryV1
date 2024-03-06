using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Search;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;

    // Dictionary to map item IDs to actions or functions
    private Dictionary<int, Action> itemActions = new Dictionary<int, Action>();

    // Reference to the inventory manager
    public InventoryManager inventoryManager;

    private void Awake()
    {
        Instance = this;

    }

    // Function to use an item based on its ID
    public void UseItemByID(int itemID)
    {
        Debug.Log("UseItemByID is being called");
        // Check if the item ID exists in the dictionary

        if (itemActions.ContainsKey(itemID))
        {
            // Execute the corresponding action or function for the item ID
            itemActions[itemID].Invoke();
        }
        else
        {
            Debug.LogWarning("No action defined for item ID: " + itemID);
        }
    }

    public void Remove(Item item)
    {
        inventoryManager.Remove(item);
    }
}
