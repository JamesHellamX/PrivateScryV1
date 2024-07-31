using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateInventory : MonoBehaviour
{
    public GameObject Inventory;
    public GameObject SpectralPanel;
    public GameObject Portal_A;
    public GameObject EscapeMenu;
    //public GameObject Journal;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (Inventory.activeSelf)
            {
                //if inventory is active, deactivate it
                Inventory.SetActive(false);
            }
            else
            {
                //activate it if not
                //Debug.Log("Inventory is inactive, activating now");
                Inventory.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (SpectralPanel.activeSelf)
            {
                SpectralPanel.SetActive(false);
            }
            else
            {
                SpectralPanel.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            if (Portal_A.activeSelf)
            {
                Portal_A.SetActive(false);
            }
            else
            {
                Portal_A.SetActive(true);
            }
        }


        /*if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("Input recognised");
            if (Journal.activeSelf)
            {
                Journal.SetActive(false);
            }
            else
            {
                Debug.Log("Journal is inactive, activaing now");
                Journal.SetActive(true);
            }
        }*/
    }
}