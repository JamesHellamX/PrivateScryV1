using UnityEngine;

public class GoHomeDoor : MonoBehaviour
{
    // The target position to teleport the player to
    public Transform targetLocation;

    // The player GameObject
    public GameObject player;
    public GameObject EToDoor;

    private bool isPlayerInTrigger = false;

    // Function to teleport the player
    void TeleportPlayer()
    {
        if (targetLocation != null && player != null)
        {
            player.transform.position = targetLocation.position;
            EToDoor.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Target location or player is not set.");
        }
    }

    // Detect when the player interacts with the door
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
            EToDoor.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            EToDoor.SetActive(false);
        }
    }

    private void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E has been pressed. Teleporting now.");
            TeleportPlayer();
        }
    }
}

