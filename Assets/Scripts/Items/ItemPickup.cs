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

                    if (Input.GetKeyDown(KeyCode.E))
                    {

                        Pickup();
                        CanvasEToPickup.SetActive(false);

                    }
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
        InventoryManager.Instance.Add(Item);
        // Mark the item as picked up
        isPickedUp = true;

        Destroy(gameObject);
        
    }
}
