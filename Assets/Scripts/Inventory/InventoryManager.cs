using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    // List to store items in the inventory
    public List<Item> Items = new List<Item>();

    public GameObject InventoryItem;
    public Transform ItemContent;

    public TMP_Text messageText;
    public Image itemImage;

    public Toggle EnableConsumable;
    public Toggle EnableKeyItem;
    public Toggle EnableQuestItem;

    public ItemController[] InventoryItems;

    private void Awake()
    {
        Instance = this;
    }


    public void Add(Item item)
    {
        Items.Add(item);
        // Optionally update the UI
        ListItems();
    }

    public void Remove(Item item)
    {
        Items.Remove(item);

    }

    public void ListItems()
    {
        // Clean content before opening inventory
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

        // Create inventory items for each item in the inventory
        foreach (Item item in Items)
        {
            // Customize inventory item UI based on item properties
            // Example: Set text, images, etc.
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("itemName").GetComponent<TMP_Text>();
            var itemImage = obj.transform.Find("itemImage").GetComponent<Image>();

            itemName.text = item.itemName;
            itemImage.sprite = item.itemImage;

            // Assign the item and itemEffects to the ItemController
            var itemController = obj.GetComponent<ItemController>();
            if (itemController != null)
            {
                itemController.AddItem(item);
                itemController.itemEffects = ItemEffects.Instance; // Assuming ItemEffects is a singleton
            }
            else
            {
                Debug.LogError("ItemController not found on inventory item prefab.");
            }
        }

        SetInventoryItems();
    }

    public void SetInventoryItems()
    {
        InventoryItems = ItemContent.GetComponentsInChildren<ItemController>();

        for (int i = 0; i < Items.Count; i++) 
        {
            InventoryItems[i].AddItem(Items[i]);
        }
    }

    public void ShowItemPickupMessage(Item item)
    {
        DisplayMessage("Obtained: " + item.itemName, item.itemImage, GetColorByItemClass(item));
    }

    private void DisplayMessage(string prefix, Sprite itemImageSprite, Color textColor)
    {
        StartCoroutine(ShowMessageAndIcon(prefix, itemImageSprite, textColor));
    }

    private void ClearMessage()
    {
        // Clear the message using TextMeshPro
        messageText.text = "";

        // Clear the item image using Image
        itemImage.sprite = null;
        itemImage.gameObject.SetActive(false); // Disable the item image
    }

    private IEnumerator ShowMessageAndIcon(string message, Sprite itemImageSprite, Color textColor)
    {
        // Display the message using TextMeshPro with the specified color
        messageText.text = message;
        messageText.color = textColor;

        // Display the item image using Image
        itemImage.sprite = itemImageSprite;
        itemImage.gameObject.SetActive(true); // Enable the item image

        yield return new WaitForSeconds(3.0f); // Change this duration as needed

        // Clear the message and item image after x seconds
        ClearMessage();
    }

    private Color GetColorByItemClass(Item item)
    {
        // Define colors based on item classes
        Color defaultColor = Color.white; // Default color
        Color consumableColor = Color.green;
        Color keyItemColor = Color.magenta;
        Color questItemColor = Color.yellow;

        // Assign colors based on item class
        if (item.consumable)
            return consumableColor;
        else if (item.keyItem)
            return keyItemColor;
        else if (item.questObject)
            return questItemColor;

        return defaultColor; // Return default color if no class is matched
    }

}

