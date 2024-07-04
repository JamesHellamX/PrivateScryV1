using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosetDialogue : MonoBehaviour
{
    public bool firstTime;
    public Dialogue dialogueToTrigger;

    private bool isPlayingDialogue = true;

    private void OnTriggerEnter(Collider other)
    {
        if (firstTime)
        {
            DialogueManager.Instance.StartDialogue(dialogueToTrigger);
            isPlayingDialogue = true; // Set flag to indicate dialogue is playing
            firstTime = false;
        }
        if (!firstTime)
        {

        }
    }
}
