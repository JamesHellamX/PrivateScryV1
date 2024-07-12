using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public Item item;
    public ItemEffects itemEffects;

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
        switch (item.itemID)
        {
            case Item.ItemID.IDNULL:
                break;
            // "case" is refering to the assigned ItemID of the object. Example: "Journal" has the itemID of '1'.
            case Item.ItemID.ID1:
                Debug.Log("Using Item with ID 1: Journal");
                ItemEffects.Instance.ItemEffectID1();
                break;
            case Item.ItemID.ID2:
                Debug.Log("Using item with ID 2: PortalKey");
                ItemEffects.Instance.ItemEffectID2();
                break;
            case Item.ItemID.ID3:
                Debug.Log("Using item with ID 3: Energy Drink");
                ItemEffects.Instance.ItemEffectID3();
                RemoveItem();
                break;
            case Item.ItemID.ID4:
                Debug.Log("Using item with ID 4: Spectral Key");
                ItemEffects.Instance.ItemEffectID4();
                RemoveItem();
                break;
            case Item.ItemID.ID5:
                Debug.Log("Using item with ID 5: ");
                ItemEffects.Instance.ItemEffectID5();
                break;
        }
    }
}
