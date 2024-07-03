using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject TeleportMenu;
    public GameObject CanvasEToUse;

    public bool _active = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CanvasEToUse.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E) && !_active)
            {
                TeleportMenu.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.E) && _active)
            {
                TeleportMenu.SetActive(false);
            }
        }
        else
        {

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CanvasEToUse.SetActive(false);
        }
    }
}
