using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlanCheckpointmanager : MonoBehaviour
{
    // List of checkpoint names to be checked
    public List<string> requiredCheckpoints = new List<string>();
    // Name of the checkpoint to activate when all required checkpoints are achieved
    public string targetCheckpoint;

    private void Start()
    {
        // Start checking checkpoints
        StartCoroutine(CheckCheckpoints());
    }

    private IEnumerator CheckCheckpoints()
    {
        while (true)
        {
            // Check if all required checkpoints are achieved
            bool allAchieved = true;
            foreach (string checkpoint in requiredCheckpoints)
            {
                if (!CheckpointManager.Instance.GetCheckpoint(checkpoint))
                {
                    allAchieved = false;
                    break;
                }
            }

            // If all required checkpoints are achieved, activate the target checkpoint
            if (allAchieved)
            {
                CheckpointManager.Instance.SetCheckpoint(targetCheckpoint, true);
                // Optionally, you can destroy this object if it is no longer needed
                Destroy(gameObject);
                // Exit the coroutine
                yield break;
            }

            // Wait for a short period before checking again
            yield return new WaitForSeconds(1f);
        }
    }
}

