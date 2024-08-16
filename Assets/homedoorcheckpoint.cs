using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homedoorcheckpoint : MonoBehaviour
{
    public GameObject door;
    // Update is called once per frame
    void Update()
    {
        if (CheckpointManager.Instance.GetCheckpoint("GoHome"))
        {
            door.gameObject.SetActive(true);
        }
        else { }
    }
}
