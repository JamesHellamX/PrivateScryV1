using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Database", menuName = "Inventory/Item Database")]
public class ItemDatabase : ScriptableObject
{
    public static ItemDatabase Instance;
    public List<Item> items = new List<Item>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else 
        {
            //Destroy(gameObject);
        }
    }

    // Method to retrieve an item by its ID
    public Item GetItemByID(int id)
    {
        foreach (Item item in items)
        {
            if ((int)item.itemID == id)
            {
                return item;
            }
        }
        return null; // Return null if no item with the specified ID is found
    }
}

