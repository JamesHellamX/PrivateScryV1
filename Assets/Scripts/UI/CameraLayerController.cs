using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLayerController : MonoBehaviour
{
    public GameObject panel;
    public Camera mainCamera;

    void Update()
    {
        // Check if the panel is active
        bool panelActive = panel.activeSelf;

        // Set the culling mask based on panel activity
        if (panelActive)
        {
            mainCamera.cullingMask |= 1 << LayerMask.NameToLayer("Spectral");
        }
        else
        {
            mainCamera.cullingMask &= ~(1 << LayerMask.NameToLayer("Spectral"));
        }
    }
}