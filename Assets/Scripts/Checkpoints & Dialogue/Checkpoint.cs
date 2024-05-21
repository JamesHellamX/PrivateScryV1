using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Checkpoint", menuName = "Create new Checkpoint")]
public class Checkpoint : ScriptableObject
{
    public string checkpointName;
    public string description;
    public bool isAchieved; // This is your yes/no flag
}
