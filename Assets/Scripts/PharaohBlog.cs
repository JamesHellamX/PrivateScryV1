using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PharaohBlog : MonoBehaviour
{
    public void OpenBlog()
    {
        Application.OpenURL("http://pharaohreddesigns.weebly.com/");
        Debug.Log("is this working?");
    }

}
