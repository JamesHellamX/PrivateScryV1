using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missingmcguffin : MonoBehaviour
{
    public GameObject EToInspect;
    public Dialogue dialogue;
    private bool IsInteractable = true;
    private bool hasInteracted = false;

    void Update()
    {


    }

    private void Interact()
    {
        DialogueManager.Instance.StartDialogue(dialogue);
        EToInspect.SetActive(false);
        hasInteracted = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasInteracted)
        {
            IsInteractable = true;
            EToInspect.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Interact();
            }
        }
        else { }
    }

    private void OnTriggerExit(Collider other)
    {
        EToInspect.SetActive(false);
        IsInteractable = false;
    }
}
