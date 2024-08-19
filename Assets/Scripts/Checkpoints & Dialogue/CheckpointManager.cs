using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    // Singleton instance
    public static CheckpointManager Instance { get; private set; }

    // Dictionary to store checkpoints and their statuses
    private Dictionary<string, bool> checkpoints = new Dictionary<string, bool>();

    private void Awake()
    {
        // Implement Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional: keep the instance between scenes
        }
        else
        {
            Destroy(gameObject); // Ensure there's only one instance
        }
    }

    private void Start()
    {
        // Initialize checkpoints if necessary
        InitializeCheckpoints();
    }

    // Initialize default checkpoints
    private void InitializeCheckpoints()
    {
        // Add default checkpoints (can be adjusted or replaced as needed)
        AddCheckpoint("[C]Bookshelf", false);
        AddCheckpoint("[C]takeaway", false);
        AddCheckpoint("[C]LaundryRoom", false);
        AddCheckpoint("[C]Bathroomcupboard", false);
        AddCheckpoint("SpectralBootprint", false);
        AddCheckpoint("PortalKeyAquired", false);
        AddCheckpoint("[C]Alan2", false);
        AddCheckpoint("[C]Alan3", false);
        AddCheckpoint("GoHome", false);
    }

    // Method to add a checkpoint to the dictionary
    public void AddCheckpoint(string checkpointName, bool status)
    {
        if (!checkpoints.ContainsKey(checkpointName))
        {
            checkpoints.Add(checkpointName, status);
        }
        else
        {
            Debug.LogWarning("Checkpoint already exists: " + checkpointName);
        }
    }

    // Method to set or update a checkpoint's status
    public void SetCheckpoint(string checkpointName, bool status)
    {
        if (checkpoints.ContainsKey(checkpointName))
        {
            checkpoints[checkpointName] = status;
            Debug.Log("Checkpoint set: " + checkpointName + " = " + status);
        }
        else
        {
            Debug.LogWarning("Checkpoint '" + checkpointName + "' not found.");
        }
    }

    // Method to get the status of a checkpoint
    public bool GetCheckpoint(string checkpointName)
    {
        if (checkpoints.TryGetValue(checkpointName, out bool status))
        {
            return status;
        }
        else
        {
            Debug.LogWarning("Checkpoint '" + checkpointName + "' not found.");
            return false;
        }
    }

    // Method to check if a checkpoint exists
    public bool CheckCheckpointExists(string checkpointName)
    {
        return checkpoints.ContainsKey(checkpointName);
    }
}


