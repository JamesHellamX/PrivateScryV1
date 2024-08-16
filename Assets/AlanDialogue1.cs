using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlanDialogue1 : MonoBehaviour
{
    public GameObject AlanDialogue2;
    public GameObject EToTalk;

    public Dialogue dialogue;

    public bool isInteractable = false;

    // Start is called before the first frame update
    void Start()
    {
        CheckpointManager.Instance.SetCheckpoint("[C]Bookshelf", false);
        CheckpointManager.Instance.SetCheckpoint("[C]takeaway", false);
        CheckpointManager.Instance.SetCheckpoint("[C]LaundryRoom", false);
        CheckpointManager.Instance.SetCheckpoint("[C]Bathroomcupboard", false);
        CheckpointManager.Instance.SetCheckpoint("SpectralSense01", false);
        CheckpointManager.Instance.SetCheckpoint("SpectralBootprint", false);
        CheckpointManager.Instance.SetCheckpoint("PortalKeyAquired", false);
        CheckpointManager.Instance.SetCheckpoint("[C]Alan2", false);
        CheckpointManager.Instance.SetCheckpoint("[C]Alan3", false);
        CheckpointManager.Instance.SetCheckpoint("GoHome", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInteractable)
        {                               
            DialogueManager.Instance.StartDialogue(dialogue);
            AlanDialogue2.SetActive(true);
            EToTalk.SetActive(false);
            Destroy(gameObject);
        }
        else { }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EToTalk.SetActive(true);
            isInteractable=true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        EToTalk.SetActive(false);
        isInteractable=false;
    }
}
