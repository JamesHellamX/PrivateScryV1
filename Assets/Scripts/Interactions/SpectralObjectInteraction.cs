using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectralObjectInteraction : MonoBehaviour
{
    public GameObject requiredObject; // The other game object that needs to be active
    public GameObject spectralObject; // The object the player interacts with
    public GameObject interactionScriptObject; // The GameObject containing the interaction script
    public GameObject CanvasEToInteract;
    public string playerTag = "Player";
    public float interactionDistance = 3f;

    private bool canInteract = false;
    private bool isInteracting = false;

    void Update()
    {
        if (!isInteracting)
        {
            GameObject player = GameObject.FindGameObjectWithTag(playerTag);

            if (player != null)
            {

                // Check if the player is within the specified range
                float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

                if (distanceToPlayer <= interactionDistance && requiredObject.activeSelf)
                {
                    CanvasEToInteract.SetActive(true);

                    canInteract = true;
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Interact();

                    }
                }
                else
                {

                }
            }
        }
    }
    void Interact()
    {
        interactionScriptObject.SetActive(true);
    }
}
