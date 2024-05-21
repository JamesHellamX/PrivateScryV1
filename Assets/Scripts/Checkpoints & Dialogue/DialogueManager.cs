using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text dialogueText; // Reference to a TMP_Text element to display the dialogue
    public GameObject dialoguePanel; // Panel that contains the dialogue UI
    public AudioSource audioSource; // Reference to the AudioSource component
    //public float typingSpeed = 0.3f; // Speed at which text appears

    public static DialogueManager Instance { get { return _instance; } }
    private static DialogueManager _instance;

    private Queue<Dialogue.DialogueLine> dialogueLines; // Queue to store dialogue lines

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

    // Start is called before the first frame update
    void Start()
    {
        dialogueLines = new Queue<Dialogue.DialogueLine>();
    }

    // Method to start a new dialogue
    public void StartDialogue(Dialogue dialogue)
    {
        // Activate dialogue panel
        dialoguePanel.SetActive(true);

        // Clear previous dialogue lines
        dialogueLines.Clear();

        // Enqueue dialogue lines
        foreach (Dialogue.DialogueLine line in dialogue.dialogueLines)
        {
            dialogueLines.Enqueue(line);
        }

        // Display the next dialogue line
        DisplayNextLine();
    }

    // Method to display the next dialogue line
    public void DisplayNextLine()
    {
        // Check if there are no more dialogue lines
        if (dialogueLines.Count == 0)
        {
            EndDialogue();
            return;
        }

        // Dequeue the next dialogue line
        Dialogue.DialogueLine line = dialogueLines.Dequeue();

        // Start displaying the dialogue line with typing effect
        StartCoroutine(TypeDialogue(line));
    }

    // Coroutine for typing effect
    private IEnumerator TypeDialogue(Dialogue.DialogueLine line)
    {
        dialogueText.text = "";

        // Play audio clip if available (before typing starts)
        if (line.audioClip != null)
        {
            audioSource.clip = line.audioClip;
            audioSource.Play();
        }

        // Iterate through each character in the line
        foreach (char letter in line.text.ToCharArray())
        {
            // Add the character to the dialogue text
            dialogueText.text += letter;

            // Wait for a short duration to simulate typing effect
            //yield return new WaitForSeconds(typingSpeed);
        }

        // Wait until the audio finishes playing before continuing to the next line
        yield return new WaitWhile(() => audioSource.isPlaying);

        // Display the next dialogue line
        DisplayNextLine();
    }


    // Method to end the dialogue
    private void EndDialogue()
    {
        // Deactivate dialogue panel
        dialoguePanel.SetActive(false);
    }
}


