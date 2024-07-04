using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfPortalActive : MonoBehaviour
{
    public GameObject Portal_A;
    public GameObject PortalDoor;

    // Update is called once per frame
    void Update()
    {
        if (Portal_A.activeSelf)
        {
            PortalDoor.SetActive(false);
        }
        else
        {

        }
    }
}
