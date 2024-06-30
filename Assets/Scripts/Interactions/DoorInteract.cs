using UnityEngine;

public class DoorInteract : MonoBehaviour
{
    private bool isPlayerInRange = false; // Flag to check if player is within interaction range

    void Update()
    {
        // Check for interaction input (E key)
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    // Function called when the player interacts with the object
    void Interact()
    {
        Debug.Log("Interacted with object: " + gameObject.name);
        // Add your interaction logic here
    }

    // Function called when another collider enters the trigger collider
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
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
