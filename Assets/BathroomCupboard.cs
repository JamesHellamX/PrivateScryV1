using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathroomCupboard : MonoBehaviour
{
    public Dialogue dialogue;
    public bool hasInteracted;
    public bool isInteractable;
    public GameObject EToInteract;

    void Update()
    {
        if (isInteractable)
        {
            if (!hasInteracted)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Interact();
                }
            }
            else
            {
            }
        }
        else { }
    }

    public void Interact()
    {
        DialogueManager.Instance.StartDialogue(dialogue);

        hasInteracted = true;

        CheckpointManager.Instance.SetCheckpoint("[C]Bathroomcupboard", true);

        EToInteract.SetActive(false);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!hasInteracted)
            {
                EToInteract.SetActive(true);

                isInteractable = true;
            }
        }
    }

    // Deactivate the Main function when Player exit the trigger area
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EToInteract.SetActive(false);

            isInteractable = false;
        }
    }
}
