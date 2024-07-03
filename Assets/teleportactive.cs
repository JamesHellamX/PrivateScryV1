using UnityEngine;

public class Teleportactive : MonoBehaviour
{
    private bool isPlayerInRange = false; // Flag to check if player is within interaction range
    public GameObject TeleportMenu;
    public GameObject CanvasEToInteract;
    void Update()
    {
        // Check for interaction input (E key)
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
            CanvasEToInteract.SetActive(false);
        }
    }

    // Function called when the player interacts with the object
    void Interact()
    {
        Debug.Log("Interacted with object: " + gameObject.name);
        TeleportMenu.SetActive(true);
    }

    // Function called when another collider enters the trigger collider
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            CanvasEToInteract.SetActive(true);
        }
    }

    // Function called when another collider exits the trigger collider
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            Debug.Log("Left interaction range");
        }
    }
}