using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemClickHandler : MonoBehaviour
{
    private Item item; // Reference to the associated Item object

    // Method to assign the corresponding Item object
    public void AssignItem(Item newItem)
    {
        item = newItem;
    }

    // Method to handle item clicks
    public void OnItemClick()
    {

    }
}