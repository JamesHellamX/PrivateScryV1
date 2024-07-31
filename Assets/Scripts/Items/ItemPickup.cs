using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item Item;
    public string playerTag = "Player";
    public float PickupRange = 10f; // Adjust this value based on your desired pickup range
    public PlayerItemRange PR;
    public GameObject CanvasEToPickup;
    public string hintName; // Field for the hint name
    public string checkpointtoset; // Field for the checkpoint name to set

    private bool isPickedUp = false; // Flag to check if the item has already been picked up

    void Update()
    {
        if (!isPickedUp)
        {
            GameObject player = GameObject.FindGameObjectWithTag(playerTag);

            if (player != null)
            {
                // Check if the player is within the specified range
                float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

                if (distanceToPlayer <= PickupRange)
                {
                    CanvasEToPickup.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Pickup();
                        CanvasEToPickup.SetActive(false);
                    }
                }
                else
                {
                    CanvasEToPickup.SetActive(false);
                }
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerItemRange PR = other.GetComponent<PlayerItemRange>();
            if (PR != null)
            {
                PR.ItemPickup();
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        PlayerItemRange PR = other.GetComponent<PlayerItemRange>();
        PR.ItemEnd();
    }

    void Pickup()
    {
        // Check if the item has dialogue attached
        if (Item.dialogue != null && DialogueManager.Instance != null)
        {
            // Play dialogue
            Debug.Log("Pickup1");
            DialogueManager.Instance.StartDialogue(Item.dialogue);
        }
        else
        {
            Debug.LogWarning("Dialogue or DialogueManager is not set up properly.");
        }

        InventoryManager.Instance.Add(Item);
        // Mark the item as picked up
        isPickedUp = true;

        // Show the hint if it's set
        if (!string.IsNullOrEmpty(hintName) && HintManager.Instance != null)
        {
            HintManager.Instance.ShowHint(hintName);
        }
        else
        {
            Debug.LogWarning("Hint name or HintManager is not set up properly.");
        }

        // Set the checkpoint if it's specified
        if (!string.IsNullOrEmpty(checkpointtoset))
        {
            CheckpointManager.Instance.SetCheckpoint(checkpointtoset, true);
        }
        else
        {
            Debug.LogWarning("Checkpoint to set is not specified.");
        }

        Destroy(gameObject);
    }
}

