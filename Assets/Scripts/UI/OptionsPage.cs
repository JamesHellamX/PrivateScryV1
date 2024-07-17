using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class OptionsPage : MonoBehaviour
{
    public GameObject title;
    public GameObject optionsMenu;

    // Update is called once per frame
    void Update()
    {
        if (optionsMenu.activeSelf)
        {
            title.SetActive(false);
        }
        else
        {

        }
    }
}
