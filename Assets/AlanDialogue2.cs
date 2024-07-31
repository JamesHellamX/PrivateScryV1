using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlanDialogue2 : MonoBehaviour
{
    public GameObject AlanDialogue3;
    public GameObject EToTalk;

    public Dialogue dialogue;

    public bool isInteractable = false;

    void Start()
    {
        // Initialization if needed
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInteractable)
        {
            // Start the dialogue
            DialogueManager.Instance.StartDialogue(dialogue);

            // Activate the next dialogue GameObject
            AlanDialogue3.SetActive(true);

            // Hide the "E To Talk" UI element
            EToTalk.SetActive(false);

            // Show the hint
            HintManager.Instance.ShowHint("SpectralSense01");

            // Start the coroutine to delay destruction
            StartCoroutine(DelayedDestroy(0.1f)); // Adjust delay time if needed
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (CheckpointManager.Instance.GetCheckpoint("[C]Alan2"))
            {
                EToTalk.SetActive(true);
                isInteractable = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        EToTalk.SetActive(false);
        isInteractable = false;
    }

    private IEnumerator DelayedDestroy(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}

