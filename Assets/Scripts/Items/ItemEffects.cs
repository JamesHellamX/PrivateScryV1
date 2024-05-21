using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffects : MonoBehaviour
{
    public static ItemEffects Instance;

    public ItemDatabase itemDatabase; // Reference to the ItemDatabase ScriptableObject

    public GameObject Journal;
    public GameObject SpectralKeyItem;
    public GameObject SpectralKeyButton;

    private void Awake()
    {
        Instance = this;
    }


    public void ItemEffectIDDefault()
    {
        Debug.Log("Item has no specified method or effect");
    }

    public void ItemEffectIDNull()
    {

    }

    public void ItemEffectID1()
    {
        if (Journal.activeSelf)
        {
            Journal.SetActive(false);
        }
        else
        {
            Journal.SetActive(true);
        }
    }

    public void ItemEffectID2()
    {

    }

    public void ItemEffectID3()
    {
        // Retrieve the item with ID 4 from the ItemDatabase and add it to the inventory
        Item itemToAdd = itemDatabase.GetItemByID(4);
        if (itemToAdd != null)
        {
            InventoryManager.Instance.Add(itemToAdd);
        }
        else
        {
            Debug.LogWarning("Item with ID 4 not found in the ItemDatabase.");
        }
    }


public void ItemEffectID4()
    {
        SpectralKeyButton.SetActive(true);
    }

    public void ItemEffectID5()
    {

    }





}
