using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HintManager : MonoBehaviour
{
    public static HintManager Instance;

    [System.Serializable]
    public class Hint
    {
        public string checkpointName;
        public string hintMessage;
    }

    public List<Hint> hints = new List<Hint>();
    public GameObject hintPanel;
    public TMP_Text hintText; // Use TMP_Text for TextMeshPro
    public float hintDisplayDuration = 5f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowHint(string checkpointName)
    {
        Hint hint = hints.Find(h => h.checkpointName == checkpointName);

        if (hint != null)
        {
            StartCoroutine(DisplayHint(hint.hintMessage));
        }
    }

    private IEnumerator DisplayHint(string message)
    {
        hintPanel.SetActive(true);
        hintText.text = message;
        yield return new WaitForSeconds(hintDisplayDuration);
        hintPanel.SetActive(false);
    }
}

