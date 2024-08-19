using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toiletlul : MonoBehaviour
{
    public bool isInteractable = false;
    private bool hasInteracted = false;
    public GameObject EToInteract;

    // Update is called once per frame
    void Update()
    {
        if (isInteractable && Input.GetKeyDown(KeyCode.E))
        {
            GetComponent<AudioSource>().Play();
            EToInteract.SetActive(false);
            hasInteracted = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasInteracted)
        {
            isInteractable = true;
            EToInteract.SetActive(true);
        }
        else { }
    }

    private void OnTriggerExit(Collider other)
    {
        isInteractable = false;
        EToInteract.SetActive(false);
    }
}
