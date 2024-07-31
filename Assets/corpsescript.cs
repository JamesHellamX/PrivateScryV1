using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class corpsescript : MonoBehaviour
{
    public GameObject EToInspect;
    public GameObject Corpse2;

    public Dialogue dialogue;

    public bool isInteractable;
    public bool hasInteracted;

    public float dialogueDuration = 5f; // Estimated duration for the dialogue

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasInteracted)
        {
            isInteractable = true;
            EToInspect.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EToInspect.SetActive(false);
            isInteractable = false;
        }
    }

    private void Update()
    {
        if (isInteractable && Input.GetKeyDown(KeyCode.E) && !hasInteracted)
        {
            hasInteracted = true;
            EToInspect.SetActive(false);
            DialogueManager.Instance.StartDialogue(dialogue);
            StartCoroutine(WaitForDialogueEnd(dialogueDuration));
        }
    }

    private IEnumerator WaitForDialogueEnd(float duration)
    {
        // Wait for the estimated duration of the dialogue
        yield return new WaitForSeconds(duration);

        // Activate Corpse2 and destroy the current GameObject
        Corpse2.SetActive(true);
        Destroy(gameObject);
    }
}
