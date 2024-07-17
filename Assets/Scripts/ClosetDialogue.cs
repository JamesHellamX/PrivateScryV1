using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosetDialogue : MonoBehaviour
{
    public bool firstTime;
    public Dialogue dialogueToTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (firstTime)
        {
            DialogueManager.Instance.StartDialogue(dialogueToTrigger);
            firstTime = false;
        }
        if (!firstTime)
        {

        }
    }
}
