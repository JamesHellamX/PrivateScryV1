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
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting dialogue...");
        dialoguePanel.SetActive(true);
        dialogueLines.Clear();

        foreach (Dialogue.DialogueLine line in dialogue.dialogueLines)
        {
            dialogueLines.Enqueue(line);
        }

        isDialoguePlaying = true;
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
            yield return null; // Change this line if you want a typing effect, e.g., `yield return new WaitForSeconds(typingSpeed);`
        }

        yield return new WaitWhile(() => audioSource.isPlaying);
        DisplayNextLine();
    }

    private void EndDialogue()
    {
        Debug.Log("Ending dialogue...");
        dialoguePanel.SetActive(false);
        isDialoguePlaying = false;
    }

    public bool IsDialoguePlaying()
    {
        return isDialoguePlaying;
    }
}




