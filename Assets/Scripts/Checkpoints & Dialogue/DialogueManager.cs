using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text dialogueText; // Reference to a TMP_Text element to display the dialogue
    public GameObject dialoguePanel; // Panel that contains the dialogue UI
    public AudioSource audioSource; // Reference to the AudioSource component

    public static DialogueManager Instance { get { return _instance; } }
    private static DialogueManager _instance;

    private Queue<Dialogue.DialogueLine> dialogueLines; // Queue to store dialogue lines
    private bool isDialoguePlaying = false; // Flag to indicate if dialogue is currently playing
    private List<GameObject> objectsToDestroy; // List of GameObjects to be destroyed after dialogue ends

    private void Awake()
    {
        // Ensure there's only one instance of DialogueManager
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    void Start()
    {
        dialogueLines = new Queue<Dialogue.DialogueLine>();
        objectsToDestroy = new List<GameObject>();
    }

    public void StartDialogue(Dialogue dialogue, GameObject gameObjectToDestroy = null)
    {
        // If a dialogue is already playing, end it before starting a new one
        if (isDialoguePlaying)
        {
            EndDialogue();
        }

        // Activate the dialogue panel
        dialoguePanel.SetActive(true);

        // Clear any existing dialogue lines to prepare for the new dialogue
        dialogueLines.Clear();

        // Enqueue the new dialogue lines
        foreach (Dialogue.DialogueLine line in dialogue.dialogueLines)
        {
            dialogueLines.Enqueue(line);
        }

        // Mark dialogue as playing
        isDialoguePlaying = true;

        // Add the GameObject to be destroyed after the dialogue ends (if provided)
        if (gameObjectToDestroy != null)
        {
            objectsToDestroy.Add(gameObjectToDestroy);
        }

        // Start displaying the next line of dialogue
        DisplayNextLine();
    }

    public void DisplayNextLine()
    {
        if (dialogueLines.Count == 0)
        {
            EndDialogue();
            return;
        }

        Dialogue.DialogueLine line = dialogueLines.Dequeue();
        StartCoroutine(TypeDialogue(line));
    }

    private IEnumerator TypeDialogue(Dialogue.DialogueLine line)
    {
        dialogueText.text = "";

        if (line.audioClip != null)
        {
            audioSource.clip = line.audioClip;
            audioSource.Play();
        }

        foreach (char letter in line.text.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null; // Change this line for the typing effect, e.g., `yield return new WaitForSeconds(typingSpeed);`
        }

        yield return new WaitWhile(() => audioSource.isPlaying);
        DisplayNextLine();
    }

    public void EndDialogue()
    {
        // Clear the dialogue queue and reset UI elements
        dialogueLines.Clear();
        dialogueText.text = "";

        // Hide the dialogue panel
        dialoguePanel.SetActive(false);

        // Set the dialogue playing flag to false
        isDialoguePlaying = false;

        // Destroy any objects that were set to be destroyed after the dialogue
        foreach (GameObject obj in objectsToDestroy)
        {
            if (obj != null)
            {
                Destroy(obj);
            }
        }
        objectsToDestroy.Clear();
    }

    public bool IsDialoguePlaying()
    {
        return isDialoguePlaying;
    }
}





