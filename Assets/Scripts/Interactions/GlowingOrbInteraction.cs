using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowingOrbInteraction : MonoBehaviour
{
    public string interactionMessage = "Interacted with object"; // Message to display when interacted
    public Dialogue dialogue; // Dialogue to play when interacting
    public GameObject CanvasEToInteract; // UI element to show interaction prompt
    public Material glowMaterial; // Material to use for glowing effect
    public Material defaultMaterial; // Default material of the object
    public AudioSource glowSound;

    private bool isPlayerInRange = false;
    private bool hasInteracted = false; // Flag to prevent re-interaction
    public string checkpointName = "GlowFlag1"; // Checkpoint name to set when dialogue ends
    private Renderer objectRenderer;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        UpdateGlowStatus(); // Check the glow status at start
        StartGlowSound();
    }

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E) && !hasInteracted)
        {
            Interact();
            StopGlowSound();
        }
    }

    // Function called when player interacts with the object
    void Interact()
    {
        hasInteracted = true; // Prevent further interaction
        Debug.Log(interactionMessage);
        CanvasEToInteract.SetActive(false);

        if (dialogue != null && DialogueManager.Instance != null)
        {
            DialogueManager.Instance.StartDialogue(dialogue);
            StartCoroutine(WaitForDialogueEnd());
        }
        else
        {
            Debug.LogWarning("Dialogue or DialogueManager is not set up properly.");
        }
    }

    private IEnumerator WaitForDialogueEnd()
    {
        yield return new WaitUntil(() => !DialogueManager.Instance.IsDialoguePlaying());

        // Set the checkpoint to achieved
        if (!string.IsNullOrEmpty(checkpointName))
        {
            CheckpointManager.Instance.SetCheckpoint(checkpointName, true);
            Debug.Log("Checkpoint set to achieved: " + checkpointName);
        }

        // Update glow status
        UpdateGlowStatus();

        // Optionally, you can disable the interaction UI after interaction
        if (CanvasEToInteract != null)
        {
            CanvasEToInteract.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            if (CanvasEToInteract != null && !hasInteracted)
            {
                CanvasEToInteract.SetActive(true);
            }
            Debug.Log("Player is in range");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            if (CanvasEToInteract != null)
            {
                CanvasEToInteract.SetActive(false);
            }
            Debug.Log("Player left range");
        }
    }

    private void UpdateGlowStatus()
    {
        bool isCheckpointAchieved = CheckpointManager.Instance.GetCheckpoint("GlowFlag1");
        Debug.Log($"Checkpoint GlowFlag1 is achieved: {isCheckpointAchieved}");

        if (!hasInteracted && !isCheckpointAchieved)
        {
            objectRenderer.material = glowMaterial;
            StartGlowSound(); // Start the glow sound if applicable
            Debug.Log("Applying glow material");
        }
        else
        {
            objectRenderer.material = defaultMaterial;
            StopGlowSound(); // Stop the glow sound if applicable
            Debug.Log("Applying default material");
        }
    }

    private void StartGlowSound()
    {
        if (glowSound != null && !glowSound.isPlaying)
        {
            glowSound.loop = true;
            glowSound.Play();
            Debug.Log("Starting glow sound");
        }
    }

    private void StopGlowSound()
    {
        if (glowSound != null && glowSound.isPlaying)
        {
            glowSound.Stop();
            Debug.Log("Stopping glow sound");
        }
    }
}





