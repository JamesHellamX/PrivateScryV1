using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CursorLockScript : MonoBehaviour
{
    private bool cursorLocked = true;

    [SerializeField] private GameObject[] cursorVisibleElements; // Assign the UI elements in the Inspector
    [SerializeField] private PlayerLook playerLookScript; // Assign the PlayerLook script in the Inspector
    [SerializeField] private PlayerMovement playerMovementScript; // Assign the PlayerMovement script in the Inspector

    private MonoBehaviour[] scriptsToDisable;

    void Start()
    {
        LockCursor();
        scriptsToDisable = new MonoBehaviour[] { playerLookScript, playerMovementScript };
    }

    void Update()
    {
        // Toggle cursor lock when the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cursorLocked = !cursorLocked;
            LockCursor();
        }

        // Check if any of the designated UI elements are active, and if so, show the cursor, set game time scale to 0, and deactivate the PlayerLook and PlayerMovement scripts
        foreach (GameObject element in cursorVisibleElements)
        {
            if (element.activeSelf)
            {
                Cursor.visible = true;
                DisableScripts();
                return; // Exit the loop early if any UI element is active
            }
        }

        // If no designated UI elements are active, hide the cursor, unlock it, resume game time scale, and activate the PlayerLook and PlayerMovement scripts
        Cursor.visible = false;
        LockCursor();
        EnableScripts();
    }

    void LockCursor()
    {
        if (cursorLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void DisableScripts()
    {
        foreach (MonoBehaviour script in scriptsToDisable)
        {
            script.enabled = false;
        }
    }

    void EnableScripts()
    {
        foreach (MonoBehaviour script in scriptsToDisable)
        {
            script.enabled = true;
        }
    }
}
