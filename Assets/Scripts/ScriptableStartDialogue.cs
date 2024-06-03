using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Dialogue;

public class ScriptableStartDialogue : MonoBehaviour
{
    public static ScriptableStartDialogue Instance;
    public DialogueManager _dialogueManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

        public void StartDialogue(Dialogue dialogue)
        {
            _dialogueManager.StartDialogue(dialogue);
        }
}
