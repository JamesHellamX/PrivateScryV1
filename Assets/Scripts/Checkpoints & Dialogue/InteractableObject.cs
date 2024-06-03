using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public string checkpointToSet;     // Name of the checkpoint to set when this object is interacted with
    public Dialogue dialogueToTrigger; // Reference to the Dialogue ScriptableObject to trigger

    //private bool hasInteracted = false; // Flag to track whether the player has interacted with the object
    private bool isPlayingDialogue = false; // Flag to track if dialogue is currently playing

    // Remove the Interact method

    public void StartDialogue()
    {
        // Set flag to indicate interaction
        //hasInteracted = true;

        // Set checkpoint if specified
        if (!string.IsNullOrEmpty(checkpointToSet))
        {
            CheckpointManager.Instance.SetCheckpoint(checkpointToSet, true);
        }

        // Trigger dialogue if specified
        if (dialogueToTrigger != null)
        {
            DialogueManager.Instance.StartDialogue(dialogueToTrigger);
            isPlayingDialogue = true; // Set flag to indicate dialogue is playing
        }

        // Add any other interaction logic here
    }

    // Method to be called when the dialogue ends
    public void OnDialogueEnd()
    {
        isPlayingDialogue = false; // Reset flag when dialogue ends
    }
}




