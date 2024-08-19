using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bookshelf : MonoBehaviour
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
                    //Debug.Log("Interacting");
                }
            }
        }
        else { }
    }

    public void Interact()
    {
        DialogueManager.Instance.StartDialogue(dialogue);
        //Debug.Log("Starting Dialogue");

        hasInteracted = true;
        //Debug.Log("hasInteracted set to True");

        CheckpointManager.Instance.SetCheckpoint("[C]Bookshelf", true);
        //Debug.Log("Checkpoint set to true");

        EToInteract.SetActive(false);
        //Debug.Log("Interaction successful. EToInteract set to False");

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!hasInteracted)
            {
                EToInteract.SetActive(true);
                //Debug.Log("EToInteract set to visible");

                isInteractable = true;
                //Debug.Log("isInteractable set to true");
            }
        }
    }

    // Deactivate the Main function when Player exit the trigger area
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EToInteract.SetActive(false);
            //Debug.Log("EToInteract set to invisible");

            isInteractable = false;
            //Debug.Log("isInteractable set to False");
        }
    }
}