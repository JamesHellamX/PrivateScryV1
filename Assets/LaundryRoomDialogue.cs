using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LaundryRoomDialogue : MonoBehaviour
{
    public Dialogue dialogue;
    public bool isInteractable;

    private void Start()
    {
        isInteractable = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isInteractable)
        {
            DialogueManager.Instance.StartDialogue(dialogue);
            Debug.Log("Starting Dialogue");

            CheckpointManager.Instance.SetCheckpoint("[C]LaundryRoom", true);

            isInteractable = false;
            Debug.Log("hasInteracted set to True");
        }
            if (!isInteractable)
        {

        }
    }
}