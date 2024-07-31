using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shrinefloor : MonoBehaviour
{
    public bool isInteractable = true;
    public Dialogue dialogue;

    public void StartDialogue()
    {
        DialogueManager.Instance.StartDialogue(dialogue);
        isInteractable = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isInteractable)
        {
            StartDialogue();
        }
        else { }
    }
}
