using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffects : MonoBehaviour
{
    public static ItemEffects Instance;

    public ItemDatabase itemDatabase; // Reference to the ItemDatabase ScriptableObject
    public CheckpointManager checkpointManager;

    public DialogueManager _dialogueManager;

    public GameObject Journal;
    public GameObject SpectralKeyButton;
    public GameObject SpectralPanel;
    public Item EnergyDrink;
    public Item SpectralKey;
    public ScriptableStartDialogue _dialogue;

    public Dialogue DTESTActivateSpectralPanel;


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
        Debug.Log("ItemEffectID3 called");

        if (itemDatabase == null)
        {
            Debug.LogError("ItemDatabase is not assigned in the ItemEffects script.");
            return;
        }

        Item spectralKey = itemDatabase.GetItemByID(Item.ItemID.ID4);  // Use enum instead of int
        if (spectralKey != null)
        {
            InventoryManager.Instance.Add(spectralKey);
            Debug.Log("Spectral Key added to the inventory");

            // Check if the spectral key has a dialogue and start it
            if (spectralKey.dialogue != null)
            {
                DialogueManager.Instance.StartDialogue(spectralKey.dialogue);
            }

            // Remove the used item (assuming it's the energy drink)
            InventoryManager.Instance.Remove(EnergyDrink);
            InventoryManager.Instance.ListItems();
        }
        else
        {
            Debug.LogError("Spectral Key item not found in the ItemDatabase.");
        }
    }


    public void ItemEffectID4()
    {

        SpectralKeyButton.SetActive(true);
        if (SpectralPanel.activeSelf == true)
        {
            bool isFlagOn = checkpointManager.GetCheckpoint("FirstSpectralPanel");
        }
        else
        {

        }
        //DialogueManager.Instance.StartDialogue(DTESTActivateSpectralPanel);

    }

    public void ItemEffectID5()
    {

    }





}
