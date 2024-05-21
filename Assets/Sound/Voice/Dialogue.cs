using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Dialogue", menuName = "Create new Dialogue")]
public class Dialogue : ScriptableObject
{
    [System.Serializable]
    public class DialogueLine
    {
        public string text; // Text for this dialogue line
        public AudioClip audioClip; // Audio clip for this dialogue line
    }

    public DialogueLine[] dialogueLines; // Array of dialogue lines
}
