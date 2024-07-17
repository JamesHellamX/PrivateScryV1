using UnityEngine;
using TMPro;
public class UIFontUpdater : MonoBehaviour
{
    TMP_Text text;

    //Whever the TMP gameobject starts, check and update the font
    void Start()
    {
        text = gameObject.GetComponent<TMP_Text>();
        if (text && text.font != FontPreferences.singleton.currentFontAsset)
        {
            text.font = FontPreferences.singleton.currentFontAsset;
            text.ForceMeshUpdate(false, true);
        }

    }

    //Whever the TMP gameobject appears, check and update the font
    public void OnEnable()
    {
        if (text && text.font != FontPreferences.singleton.currentFontAsset)
        {
            text.font = FontPreferences.singleton.currentFontAsset;
            text.ForceMeshUpdate(false, true);
        }
    }

}