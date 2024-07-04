using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandprintScript1 : MonoBehaviour
{
    public GameObject Painting;
    public GameObject SpectralHandprint;
    public float moveDistance = 1.0f; // The distance you want the door to move
    public GameObject EtoInteract;
    public GameObject PortalKey;
    private bool hasInteracted = false; // To ensure the interaction happens only once
    public Vector3 NewPosition;
    public AudioSource DoorSlam;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !hasInteracted)
        {

            Painting.transform.position = NewPosition;

            // Deactivate the handprint and interaction prompt
            SpectralHandprint.SetActive(false);
            EtoInteract.SetActive(false);

            PortalKey.SetActive(true);
            // Mark that the interaction has occurred
            hasInteracted = true;

            // Destroy the handprint game object
            Destroy(gameObject);
        }
    }
}

