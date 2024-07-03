using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlanDialogue : MonoBehaviour
{
    private bool isPlayerInRange = false; // Flag to check if player is within interaction range

    public Item Alan;
    public GameObject EToInteract;

    void Update()
    {
        // Check for interaction input (E key)
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    // Function called when the player interacts with the object
    void Interact()
    {
        Debug.Log("Interacted with object: " + gameObject.name);
        if (Alan.dialogue != null && DialogueManager.Instance != null)
        {
            EToInteract.SetActive(false);
            // Play dialogue
            Debug.Log("SpectralInteraction");
            DialogueManager.Instance.StartDialogue(Alan.dialogue);
        }
        else
        {
            Debug.LogWarning("Dialogue or DialogueManager is not set up properly.");
        }
    }

    // Function called when another collider enters the trigger collider
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EToInteract.SetActive(true);
            isPlayerInRange = true;
        }
    }

    // Function called when another collider exits the trigger collider
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EToInteract.SetActive(false);
            isPlayerInRange = false;
            Debug.Log("Left interaction range");
        }
    }
}

