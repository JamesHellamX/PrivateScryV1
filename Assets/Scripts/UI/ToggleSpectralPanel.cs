using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TogglePanel : MonoBehaviour
{
    public GameObject panelToToggle;
    public float activeDuration = 10f; // Duration in seconds
    private bool panelActive = false;

    public void ToggleAndActivateForDuration()
    {
        if (panelToToggle != null)
        {
            panelActive = !panelActive;
            panelToToggle.SetActive(panelActive);

            // Enable/disable interaction components
            Collider[] colliders = panelToToggle.GetComponentsInChildren<Collider>(true);
            foreach (Collider collider in colliders)
            {
                collider.enabled = panelActive;
            }

            // Enable/disable interaction scripts (if any)
            MonoBehaviour[] scripts = panelToToggle.GetComponentsInChildren<MonoBehaviour>(true);
            foreach (MonoBehaviour script in scripts)
            {
                script.enabled = panelActive;
            }

            if (panelActive)
            {
                Invoke("DeactivatePanel", activeDuration);
            }
        }
    }

    private void DeactivatePanel()
    {
        if (panelToToggle != null)
        {
            panelActive = false;
            panelToToggle.SetActive(false);

            // Disable interaction components
            Collider[] colliders = panelToToggle.GetComponentsInChildren<Collider>(true);
            foreach (Collider collider in colliders)
            {
                collider.enabled = false;
            }

            // Disable interaction scripts (if any)
            MonoBehaviour[] scripts = panelToToggle.GetComponentsInChildren<MonoBehaviour>(true);
            foreach (MonoBehaviour script in scripts)
            {
                script.enabled = false;
            }
        }
    }
}