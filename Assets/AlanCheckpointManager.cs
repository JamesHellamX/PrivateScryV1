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
            bool allAchieved = true;
            foreach (string checkpoint in requiredCheckpoints)
            {
                bool isCheckpointSet = CheckpointManager.Instance.GetCheckpoint(checkpoint);
                //Debug.Log($"Checkpoint '{checkpoint}' achieved: {isCheckpointSet}");

                if (!isCheckpointSet)
                {
                    allAchieved = false;
                    break;
                }
            }

            if (allAchieved)
            {
                //Debug.Log($"All required checkpoints achieved. Setting target checkpoint: {targetCheckpoint}");
                CheckpointManager.Instance.SetCheckpoint("[C]Alan2", true);
                CheckpointManager.Instance.SetCheckpoint(targetCheckpoint, true);
                yield break;
            }

            yield return new WaitForSeconds(1f);
        }
    }

}

