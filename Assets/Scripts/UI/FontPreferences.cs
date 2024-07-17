using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FontPreferences : MonoBehaviour
{
    public static FontPreferences singleton;

    [Header("Font options")]
    public TMP_FontAsset currentFontAsset;
    public TMP_Dropdown fontDropdown;
    public TMP_FontAsset[] fonts;

    void Start()
    {
        //pupulate the singleton
        if (!singleton) singleton = this;

        //Clear the dropdown just in case
        fontDropdown.ClearOptions();

        List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();
        for (int i = 0; i < fonts.Length; i++)
        {
            //<Font=FontAssetName> Whatever text </font>
            string fontName = "<font=" + fonts[i].name + ">" + fonts[i].name + "</font>";

            TMP_Dropdown.OptionData option = new TMP_Dropdown.OptionData(fontName);
            options.Add(option);
        }
        fontDropdown.AddOptions(options);
    }
}
