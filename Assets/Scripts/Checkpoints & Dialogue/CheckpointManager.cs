using System;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager Instance { get; private set; }

    public List<Checkpoint> checkpoints;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //Destroy(gameObject);
        }
    }

    public void SetCheckpoint(string checkpointName, bool value)
    {
        Checkpoint checkpoint = checkpoints.Find(c => c.checkpointName == checkpointName);
        if (checkpoint != null)
        {
            checkpoint.isAchieved = value;
            if (value)
            {
                HintManager.Instance.ShowHint(checkpointName);
            }
        }
        else
        {
            Debug.LogWarning($"Checkpoint '{checkpointName}' not found.");
        }
    }

    public bool GetCheckpoint(string checkpointName)
    {
        Checkpoint checkpoint = checkpoints.Find(c => c.checkpointName == checkpointName);
        return checkpoint != null && checkpoint.isAchieved;
    }

    private void OnDestroy()
    {
        Debug.Log("CheckpointManager is being destroyed by " + gameObject.name);
    }
}

