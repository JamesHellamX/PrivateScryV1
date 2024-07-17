using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfInventoryIsActive : MonoBehaviour
{
    public GameObject SpectralPanel;
    // Update is called once per frame
    void Update()
    {
        SpectralPanel.SetActive(false);
    }
}
