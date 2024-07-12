using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TeleportManager : MonoBehaviour
{

    public GameObject teleportMenu;

    public void TeleportMenu()
    {

        if (teleportMenu.activeInHierarchy == true)
        {
            teleportMenu.SetActive(false);
        }
    }

    public void CrimeScene()
    {

        SceneManager.LoadScene("Crimescene");

    }

    public void Home()
    {
        SceneManager.LoadScene("Home");
    }
}
