using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowController : MonoBehaviour
{
    public CheckpointManager checkpointManager;
    public string checkpointName;
    public Renderer objectRenderer;
    public Color glowColor;
    public float glowIntensity = 1.0f;

    private Material originalMaterial;
    private Material glowMaterial;

    void Start()
    {
        // Cache the original material
        originalMaterial = objectRenderer.material;

        // Create a new material for the glow effect
        glowMaterial = new Material(originalMaterial);
        glowMaterial.EnableKeyword("_EMISSION");
        glowMaterial.SetColor("_EmissionColor", glowColor * glowIntensity);

        // Initially, make sure the object is not glowing
        DisableGlow();
    }

    void Update()
    {
        // Check if the flag is set
        if (checkpointManager.GetCheckpoint(checkpointName))
        {
            EnableGlow();
        }
        else
        {
            DisableGlow();
        }
    }

    private void EnableGlow()
    {
        objectRenderer.material = glowMaterial;
    }

    private void DisableGlow()
    {
        objectRenderer.material = originalMaterial;
    }
}
