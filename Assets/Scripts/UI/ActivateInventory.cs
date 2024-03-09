using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;

public class ActivateInventory : MonoBehaviour
{
    public GameObject Inventory;
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