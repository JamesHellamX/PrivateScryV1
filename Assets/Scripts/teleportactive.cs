using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleportactive : MonoBehaviour
{
    private bool isPlayerInRange = false; // Flag to check if player is within interaction range
    public GameObject GoToScene; // GameObject to show when in range
    public string sceneToLoad; // The name of the scene to load, assignable in the inspector

    void Update()
    {
        // Check for interaction input (E key)
        if (isPlayerInRange)
        {
            GoToScene.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Interact();
            }
        }
        else if (!isPlayerInRange)
        {
            // You can add logic here if needed when the player is not in range
        }
    }

    // Function called when the player interacts with the object
    void Interact()
    {
        GoToScene.SetActive(false);
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogWarning("Scene to load is not assigned.");
        }
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
            GoToScene.SetActive(false);
            isPlayerInRange = false;
            Debug.Log("Left interaction range");
        }
    }
}
