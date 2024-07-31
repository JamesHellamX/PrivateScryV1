using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastFood : MonoBehaviour
{
    public Dialogue Dialogue;
    public GameObject EToInteract;
    public bool isInteractable = false;
    public bool hasInteracted = false;
    private string playerTag = "Player";

    private void Start()
    {
        if (EToInteract != null)
        {
            EToInteract.SetActive(false); // Ensure the EToInteract prompt is initially inactive
        }

        Debug.Log("Initial isInteractable: " + isInteractable);
    }

    private void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag(playerTag);
        if (player != null && isInteractable)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Interact();
            }
        }
    }

    public void Interact()
    {
        if (EToInteract != null)
        {
            EToInteract.SetActive(false);
        }

        DialogueManager.Instance.StartDialogue(Dialogue);
        isInteractable = false;
        hasInteracted = true;
        CheckpointManager.Instance.SetCheckpoint("takeaway", true);
        Debug.Log("Interacted with FastFood. isInteractable set to false and hasInteracted set to true.");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger zone.");
            if (isInteractable && !hasInteracted)
            {
                if (EToInteract != null)
                {
                    EToInteract.SetActive(true);
                }
                Debug.Log("EToInteract set to active.");
            }
            else
            {
                Debug.Log("isInteractable is false or already interacted.");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player left trigger zone.");
            if (EToInteract != null)
            {
                EToInteract.SetActive(false);
            }
        }
    }

    public void SetInteractable(bool value)
    {
        isInteractable = value;
    }
}


