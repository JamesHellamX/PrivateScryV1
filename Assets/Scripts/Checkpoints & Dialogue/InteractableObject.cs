using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public string checkpointToSet;     // Name of the checkpoint to set when this object is interacted with
    public Dialogue dialogueToTrigger; // Reference to the Dialogue ScriptableObject to trigger

    // Remove the Interact method

    public void StartDialogue()
    {
        // Set checkpoint if specified
        if (!string.IsNullOrEmpty(checkpointToSet))
        {
            CheckpointManager.Instance.SetCheckpoint(checkpointToSet, true);
        }

        // Trigger dialogue if specified
        if (dialogueToTrigger != null)
        {
            DialogueManager.Instance.StartDialogue(dialogueToTrigger);
        }

        // Add any other interaction logic here
    }
}



