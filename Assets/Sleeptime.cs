using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Add this for scene management
using UnityEngine.UI; // Add this for UI management

public class Sleeptime : MonoBehaviour
{
    public GameObject EToInteract;
    public GameObject PlayerCamera;
    public Dialogue dialogue;
    public bool isInteractable = false;
    public float dialogueDuration = 5f; // Estimate or set the dialogue duration
    public GameObject uiPanel; // Reference to the UI panel
    public float fadeDuration = 1f; // Duration for fade effect

    // Update is called once per frame
    void Update()
    {
        if (isInteractable && Input.GetKeyDown(KeyCode.E))
        {
            // Instead of deactivating the camera, we activate the UI panel
            uiPanel.SetActive(true);
            StartCoroutine(FadeInPanel());
            DialogueManager.Instance.StartDialogue(dialogue);
            StartCoroutine(WaitForDialogueToFinish());
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

    private IEnumerator WaitForDialogueToFinish()
    {
        // Wait for the estimated duration of the dialogue
        yield return new WaitForSeconds(dialogueDuration);
        // Change the scene to the main menu
        SceneManager.LoadScene("MainMenu"); // Change "MainMenu" to the name of your main menu scene
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


