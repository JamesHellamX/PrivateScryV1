using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Sleeptime : MonoBehaviour
{
    public GameObject EToInteract;
    public GameObject PlayerCamera;
    public Dialogue dialogue;
    public bool isInteractable = false;
    public float dialogueDuration = 5f; // Estimated dialogue duration
    public float waitforfade = 5f; // Duration for the fade effect

    public GameObject uiPanel; // Reference to the UI panel
    public float fadeDuration = 1f; // Duration for fade effect

    void Update()
    {
        if (isInteractable && Input.GetKeyDown(KeyCode.E))
        {
            // Activate the UI panel for the fade effect
            uiPanel.SetActive(true);
            // Start the sequence: first fade in, then dialogue, then scene change
            StartCoroutine(StartSequence());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && CheckpointManager.Instance.GetCheckpoint("GoHome"))
        {
            isInteractable = true;
            EToInteract.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        EToInteract.SetActive(false);
        isInteractable = false;
    }

    private IEnumerator StartSequence()
    {
        // First, wait for the fade effect to finish
        yield return StartCoroutine(FadeInPanel());
        // After the fade, start the dialogue
        DialogueManager.Instance.StartDialogue(dialogue);
        // Then, wait for the dialogue to finish
        yield return new WaitForSeconds(dialogueDuration);
        // Finally, change the scene to the main menu
        SceneManager.LoadScene("MainMenu"); // Replace "MainMenu" with the actual scene name
    }

    private IEnumerator FadeInPanel()
    {
        CanvasGroup canvasGroup = uiPanel.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = uiPanel.AddComponent<CanvasGroup>();
        }

        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = 1f;
    }
}



