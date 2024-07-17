using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlanDialogue : MonoBehaviour
{
    public GameObject EToTalk;
    public bool isInteractable;
    public Dialogue DAlan1;
    public Dialogue DAlan2;
    public Dialogue DAlan3;

    void Start()
    {
        isInteractable = true;
        CheckpointManager.Instance.SetCheckpoint("[C]Alan1", true);
    }

    void Update()
    {
        if (isInteractable && Input.GetKeyDown(KeyCode.E))
        {
            if (CheckpointManager.Instance.GetCheckpoint("[C]Alan1"))
            {
                DialogueManager.Instance.StartDialogue(DAlan1);
                CheckpointManager.Instance.SetCheckpoint("[C]Alan1", false);
                isInteractable = false;
                EToTalk.SetActive(false);
            }
            else if (CheckpointManager.Instance.GetCheckpoint("[C]Alan2"))
            {
                DialogueManager.Instance.StartDialogue(DAlan2);
                CheckpointManager.Instance.SetCheckpoint("[C]Alan2", false);
                isInteractable = false;
                EToTalk.SetActive(false);
            }
            else if (CheckpointManager.Instance.GetCheckpoint("[C]Alan3"))
            {
                DialogueManager.Instance.StartDialogue(DAlan3);
                CheckpointManager.Instance.SetCheckpoint("[C]Alan3", false);
                isInteractable = false;
                EToTalk.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isInteractable)
        {
            EToTalk.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EToTalk.SetActive(false);
        }
    }
}


