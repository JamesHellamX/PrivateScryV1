using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject Optionsmenu;
    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OptionsMenu()
    {
        Optionsmenu.SetActive(true);

        if (Optionsmenu.activeInHierarchy == true)
        {
            Optionsmenu.SetActive(false);
        }
    }

    public void doExitGame()
    {
        Application.Quit();
    }
}
