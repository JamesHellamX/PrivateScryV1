using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalSimple : MonoBehaviour
{
    public string playerTag = "Player";
    public bool isPlayerInJournalRange = false;
    // Start is called before the first frame update
    void Update()
    {
        if (isPlayerInJournalRange == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Just a simple Journal. Nothing more, nothing less.");
            }
        }
    }

    // Update is called once per frame
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInJournalRange = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        isPlayerInJournalRange = false;
    }
}
