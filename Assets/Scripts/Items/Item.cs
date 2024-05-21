using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Item", menuName = "Create new Item")]
public class Item : ScriptableObject
{
    public ItemID itemID;
    public string itemName;
    public Sprite itemImage;
    public string itemDescription;
    public bool consumable;
    public bool questObject;
    public bool keyItem;
    public Dialogue dialogue; // reference to the dialogue scriptable object

    public enum ItemID
    {
        IDNULL,
        ID1,
        ID2,
        ID3,
        ID4,
        ID5,
        ID6,
        ID7,
        ID8,
        ID9,
        ID10
    }
}
