using System.Collections;
using System.Collections.Generic;
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
        scriptsToDisable = new MonoBehaviour[] { playerLookScript, playerMovementScript };
        LockCursor();
    }

    void Update()
    {
        // Toggle cursor lock when the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cursorLocked = !cursorLocked;
            LockCursor();
        }

        HandleUIElementsAndCursor();
    }

    private void HandleUIElementsAndCursor()
    {
        // Check if any UI elements are active
        bool anyUIElementActive = false;
        foreach (GameObject element in cursorVisibleElements)
        {
            if (element.activeSelf)
            {
                anyUIElementActive = true;
                break;
            }
        }

        if (anyUIElementActive)
        {
            // If any UI element is active, unlock the cursor and disable gameplay scripts
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            DisableScripts();
            Time.timeScale = 0f; // Pause the game
        }
        else
        {
            if (cursorLocked)
            {
                // If the cursor should be locked for gameplay
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                EnableScripts();
                Time.timeScale = 1f; // Resume the game
            }
            else
            {
                // If the cursor should be unlocked for non-gameplay actions
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                DisableScripts();
                Time.timeScale = 1f; // Keep the game running
            }
        }
    }

    void LockCursor()
    {
        if (cursorLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            EnableScripts();
            Time.timeScale = 1f; // Resume the game when locking the cursor
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            DisableScripts();
            Time.timeScale = 1f; // Ensure the game is not paused by unlocking the cursor
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
