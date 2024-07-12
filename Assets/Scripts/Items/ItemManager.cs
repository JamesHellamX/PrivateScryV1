using System;
using System.Collections;
using System.Collections.Generic;
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

    public void Remove(Item item)
    {
        inventoryManager.Remove(item);
    }
}
