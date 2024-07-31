using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelFirst : MonoBehaviour
{
    public bool FirstPanel = false;
    public Dialogue dialogue;
    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf && !FirstPanel && CheckpointManager.Instance.GetCheckpoint("SpectralSense01"))
        {
            FirstPanel = true;
            DialogueManager.Instance.StartDialogue(dialogue);
        }
        else
        {

        }
    }
}
