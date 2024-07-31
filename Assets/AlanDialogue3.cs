using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlanDialogue3 : MonoBehaviour
{
    public GameObject EToTalk;

    public Dialogue dialogue;

    public bool isInteractable = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && isInteractable)
        {
            DialogueManager.Instance.StartDialogue(dialogue);
            EToTalk.SetActive(false);
            Destroy(gameObject);
        }
        else { }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (CheckpointManager.Instance.GetCheckpoint("[C]Alan3"))
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
}

