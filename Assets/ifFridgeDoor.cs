using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ifFridgeDoor : MonoBehaviour
{
    public Door door;
    public Dialogue dialogue;
    public bool hasInteracted;
    public Checkpoint takeaway;

    void Start()
    {
        door = GetComponent<Door>();
    }

    void Update()
    {
        if (door.open && !hasInteracted)
        {
            DialogueManager.Instance.StartDialogue(dialogue);
            hasInteracted = true;
            CheckpointManager.Instance.SetCheckpoint("takeaway", true);
        }
        else { }
    }
}
