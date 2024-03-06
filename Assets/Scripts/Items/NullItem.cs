using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullItem : Item
{
    public NullItem()
    {
        // Set default values for the null item
        itemID = 0; // Or any other value that won't conflict with actual item IDs
        itemName = "NullItem";
        // Set other default values as needed
    }
}