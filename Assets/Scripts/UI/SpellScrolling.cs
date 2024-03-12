using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellScrolling : MonoBehaviour
{
    public ScrollRect scrollRect;
    public RectTransform content;
    public float scrollSpeed = 10f;
    public float inactivityDuration = 10f;
    private float lastActivityTime;

    private CanvasGroup canvasGroup;
    private bool isVisible = true;
    private Coroutine fadeCoroutine;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        lastActivityTime = Time.time;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveToNextItem();
            lastActivityTime = Time.time;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveToPreviousItem();
            lastActivityTime = Time.time;
        }

        // Check for inactivity
        if (Time.time - lastActivityTime >= inactivityDuration)
        {
            // If inactive for 10 seconds, start fading out
            if (isVisible)
            {
                if (fadeCoroutine == null)
                {
                    fadeCoroutine = StartCoroutine(FadeOut());
                }
            }
        }
        else
        {
            // If active, ensure the spell scroll is visible
            if (!isVisible)
            {
                if (fadeCoroutine == null)
                {
                    fadeCoroutine = StartCoroutine(FadeIn());
                }
            }
        }
    }

    private void MoveToNextItem()
    {
        if (scrollRect.horizontal)
        {
            float targetPosition = Mathf.Clamp(content.anchoredPosition.x + scrollRect.viewport.rect.width, 0f, content.rect.width - scrollRect.viewport.rect.width);
            content.anchoredPosition = new Vector2(targetPosition, content.anchoredPosition.y);
        }
        else if (scrollRect.vertical)
        {
            float targetPosition = Mathf.Clamp(content.anchoredPosition.y - scrollRect.viewport.rect.height, 0f, content.rect.height - scrollRect.viewport.rect.height);
            content.anchoredPosition = new Vector2(content.anchoredPosition.x, targetPosition);
        }
    }

    private void MoveToPreviousItem()
    {
        if (scrollRect.horizontal)
        {
            float targetPosition = Mathf.Clamp(content.anchoredPosition.x - scrollRect.viewport.rect.width, 0f, content.rect.width - scrollRect.viewport.rect.width);
            content.anchoredPosition = new Vector2(targetPosition, content.anchoredPosition.y);
        }
        else if (scrollRect.vertical)
        {
            float targetPosition = Mathf.Clamp(content.anchoredPosition.y + scrollRect.viewport.rect.height, 0f, content.rect.height - scrollRect.viewport.rect.height);
            content.anchoredPosition = new Vector2(content.anchoredPosition.x, targetPosition);
        }
    }

    private IEnumerator FadeOut()
    {
        isVisible = false;
        float elapsedTime = 0f;
        while (canvasGroup.alpha > 0)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / inactivityDuration);
            canvasGroup.alpha = 1 - t;
            yield return null;
        }
        fadeCoroutine = null;
    }

    private IEnumerator FadeIn()
    {
        isVisible = true;
        float elapsedTime = 0f;
        while (canvasGroup.alpha < 1)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / inactivityDuration);
            canvasGroup.alpha = t;
            yield return null;
        }
        fadeCoroutine = null;
    }
}





