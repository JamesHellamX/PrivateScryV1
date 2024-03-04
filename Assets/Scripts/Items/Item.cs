using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Item", menuName = "Create new Item")]
public class Item : ScriptableObject
{
    public int itemID;
    public string itemName;
    public Sprite itemImage;
    public string itemDescription;
    public bool consumable;
    public bool questObject;
    public bool keyItem;

}
