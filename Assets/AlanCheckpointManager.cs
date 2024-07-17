using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlanCheckpointManager : MonoBehaviour
{
    public AlanDialogue AlanDialogue;

    private void Start()
    {
        CheckpointManager.Instance.SetCheckpoint("[C]Alan1", true);
    }

    private void Update()
    {
        CheckAlan1();
        CheckAlan2();
    }

    private void CheckAlan1()
    {
        if (CheckpointManager.Instance.GetCheckpoint("[C]Alan1") &&
            CheckpointManager.Instance.GetCheckpoint("[C]LaundryRoom") &&
            CheckpointManager.Instance.GetCheckpoint("[C]Bookshelf") &&
            CheckpointManager.Instance.GetCheckpoint("bathroomcupboard") &&
            CheckpointManager.Instance.GetCheckpoint("takeaway"))
        {
            CheckpointManager.Instance.SetCheckpoint("[C]Alan2", true);
            AlanDialogue.isInteractable = true;
        }
    }

    private void CheckAlan2()
    {
        if (CheckpointManager.Instance.GetCheckpoint("[C]Alan2Comp") &&
            CheckpointManager.Instance.GetCheckpoint("SpectralSense01") &&
            CheckpointManager.Instance.GetCheckpoint("PortalKeyAquired") &&
            CheckpointManager.Instance.GetCheckpoint("SpectralBootprint"))
        {
            CheckpointManager.Instance.SetCheckpoint("[C]Alan3", true);
            AlanDialogue.isInteractable = true;
        }
    }
}

