using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorpseRadius : MonoBehaviour
{
    public Item Item;
    public GameObject interactionScriptObject; // The GameObject containing the interaction script
    public string playerTag = "Player";
    public float InspectionRange = 10f;
    public GameObject CanvasEToInspect;
    public GameObject corpse2;
    public string checkpointToSet;

    public bool isDialoguePlaying;

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag(playerTag);

        if (player != null)
        {
            // Check if the player is within the specified range
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

            if (distanceToPlayer <= InspectionRange)
            {
                CanvasEToInspect.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // Check if the item has dialogue attached and no dialogue is currently playing
                    if (Item.dialogue != null && DialogueManager.Instance != null && !DialogueManager.Instance.IsDialoguePlaying())
                    {
                        // Play dialogue
                        Debug.Log("CorpseInteraction");
                        DialogueManager.Instance.StartDialogue(Item.dialogue);
                        if (!string.IsNullOrEmpty(checkpointToSet))
                        {
                            CheckpointManager.Instance.SetCheckpoint(checkpointToSet, true);
                            Debug.Log("checkpoint set to true");
                        }
                    }
                    else
                    {
                        Debug.LogWarning("Dialogue or DialogueManager is not set up properly, or dialogue is already playing.");
                    }
                }
            }
            else
            {
                CanvasEToInspect.SetActive(false);
            }
        }
    }

    // This function can be called by the DialogueManager when the dialogue is finished
    public void OnDialogueFinished()
    {
        isDialoguePlaying = false;

        corpse2.SetActive(true);
        Destroy(gameObject);
    }
}


