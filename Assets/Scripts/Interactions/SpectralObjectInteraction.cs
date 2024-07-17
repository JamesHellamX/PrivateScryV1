using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectralObjectInteraction : MonoBehaviour
{
    public GameObject spectralPanel; // The other game object that needs to be active
    public GameObject spectralObject; // The object the player interacts with
    public GameObject interactionScriptObject; // The GameObject containing the interaction script
    public GameObject CanvasEToInteract;
    public string playerTag = "Player";
    public float interactionDistance = 1f;
    public Item Item;
    public string Checkpoint;

    public bool IsInteractable = true;
    //public bool destroyAfterInteraction;

    private bool isInteracting = false;

    void Update()
    {
        if (!isInteracting && IsInteractable)
        {
            GameObject player = GameObject.FindGameObjectWithTag(playerTag);

            if (player != null)
            {
                // Check if the player is within the specified range
                float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

                if (distanceToPlayer <= interactionDistance && spectralPanel.activeSelf)
                {
                    CanvasEToInteract.SetActive(true);
                    interactionScriptObject.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.E))
                    {

                        CanvasEToInteract.SetActive(false);
                        // Check if the item has dialogue attached
                        if (Item.dialogue != null && DialogueManager.Instance != null)
                        {
                            // Play dialogue
                            Debug.Log("SpectralInteraction");
                            DialogueManager.Instance.StartDialogue(Item.dialogue);
                            IsInteractable = false;
                            CheckpointManager.Instance.SetCheckpoint(Checkpoint, true);
                        }
                        else
                        {
                            Debug.LogWarning("Dialogue or DialogueManager is not set up properly.");
                        }

                    }
                }
                else if (distanceToPlayer > interactionDistance)
                {

                }
            }
        }
        if (!isInteracting && !IsInteractable)
        {

        }
    }
}

