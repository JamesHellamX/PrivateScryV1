using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerItemRange : MonoBehaviour
{
    public GameObject CanvasEtoPickup; // Controls the "[E] Pickup" canvas element


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ItemPickup()
    {
        CanvasEtoPickup.SetActive(true);

    }
    public void ItemEnd()
    {
        CanvasEtoPickup.SetActive(false);
    }
}