using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffects : MonoBehaviour
{
    public static ItemEffects Instance;

    public GameObject Journal;
    public GameObject SpectralKeyItem;
    public GameObject SpectralKeyButton;

    private void Awake()
    {
        Instance = this;
    }


    public void ItemEffectIDDefault()
    {
        Debug.Log("Item has no specified method or effect");
    }

    public void ItemEffectID1()
    {
        if (Journal.activeSelf)
        {
            Journal.SetActive(false);
        }
        else
        {
            Journal.SetActive(true);
        }
    }

    public void ItemEffectID2()
    {

    }

    public void ItemEffectID3()
    {

    }

    public void ItemEffectID4()
    {
        SpectralKeyButton.SetActive(true);
    }

    public void ItemEffectID5()
    {

    }





}
