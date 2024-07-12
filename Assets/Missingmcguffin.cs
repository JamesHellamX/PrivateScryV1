using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missingmcguffin : MonoBehaviour
{
    private bool IsInRange = false;
    public GameObject EToInspect;
    public Item MissingMcguffin;
    private bool IsInteractable = true;

    void Update()
    {
        if (IsInteractable)
        {
            if (IsInRange)
            {
                EToInspect.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Interact();
                }
            }
        }
        else
        {

        }

    }

    private void Interact()
    {
        EToInspect.SetActive(false);
        DialogueManager.Instance.StartDialogue(MissingMcguffin.dialogue);
    }

    private void OnTriggerEnter(Collider other)
    {
        IsInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        IsInRange = false;
    }
}
