using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();

    public Transform ItemContent;
    public GameObject InventoryItem;

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
        DisplayMessage("Obtained: " + item.itemName, item.itemImage, GetColorByItemClass(item));
        ListItems();
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
    }

    public void ListItems()
    {
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
            var itemImage = obj.transform.Find("ItemImage").GetComponent<Image>();

            itemName.text = item.itemName;
            itemImage.sprite = item.itemImage;
        }

        SetInventoryItems();
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
        Color specialRenderColor = Color.blue; // Adjust as needed

        // Assign colors based on item class
        if (item.consumable)
            return consumableColor;
        else if (item.keyItem)
            return keyItemColor;
        else if (item.questObject)
            return questItemColor;

        return defaultColor; // Return default color if no class is matched
    }

    public void SetInventoryItems()
    {
        InventoryItems = ItemContent.GetComponentsInChildren<ItemController>();

        for (int i = 0; i < Items.Count; i++)
        {
            InventoryItems[i].AddItem(Items[i]);
        }
    }
}
