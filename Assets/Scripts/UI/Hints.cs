using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hints : MonoBehaviour
{
    public CheckpointManager checkpointManager;

    public TMP_Text HintText;

    public string checkpointName;
    public float displayDuration = 7f;

    private Coroutine hintCoroutine;

    private void Start()
    {
        hintCoroutine = StartCoroutine(DisplayHintRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (checkpointManager != null)
        {
            //call the getcheckpointfunction with the appropriate checkpoint name
            bool isFlagOn = checkpointManager.GetCheckpoint("TESTObtainEnergyDrink");

            if (isFlagOn)
            {
                HintText.text = "HINT: Open Inventory Using 'I'.";
            }
            else
            { 
                
            }

        }

    }

    private IEnumerator DisplayHintRoutine()
    {
        while (true)
        {
            // Check if the checkpoint flag is on
            bool isFlagOn = checkpointManager.GetCheckpoint(checkpointName);

            // Update the hint text based on the checkpoint flag
            if (isFlagOn)
            {
                // Set the hint text to display when the flag is on
                HintText.text = "Your hint text here...";

                // Wait for the specified duration
                yield return new WaitForSeconds(displayDuration);

                // Clear the hint text after the duration
                HintText.text = string.Empty;
            }
            else
            {
                // Clear the hint text if the flag is off
                HintText.text = string.Empty;
            }

            yield return null;
        }
    }
}
