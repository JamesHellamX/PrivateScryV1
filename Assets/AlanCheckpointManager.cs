using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlanCheckpointManager : MonoBehaviour
{
    public AlanDialogue AlanDialogue;

    private void Start()
    {

    }

    private void Update()
    {
        if (CheckpointManager.Instance.GetCheckpoint("[C]Alan1"))
        {
            if (CheckpointManager.Instance.GetCheckpoint("[C]LaundryRoom"))
            {
                if (CheckpointManager.Instance.GetCheckpoint("[C]Bookshelf]"))
                {
                    if (CheckpointManager.Instance.GetCheckpoint("bathroomcupboard"))
                    {
                        if (CheckpointManager.Instance.GetCheckpoint("takeaway"))
                        {
                            CheckpointManager.Instance.SetCheckpoint("[C]Alan2", true);
                        }
                        else { }
                    }
                    else { }
                }
                else { }
            }
            else { }
        }
        if (CheckpointManager.Instance.GetCheckpoint("[C]Alan2Comp"))
        {
            if (CheckpointManager.Instance.GetCheckpoint("SpectralSense01"))
            {
                if (CheckpointManager.Instance.GetCheckpoint("PortalKeyAquired"))
                {
                    if (CheckpointManager.Instance.GetCheckpoint("SpectralBootprint"))
                    {
                        CheckpointManager.Instance.SetCheckpoint("[C]Alan3", true);
                    }
                    else { }
                }
                else { }
            }
            else { }
        }
        else { }

    }


}
