using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnapToItem : MonoBehaviour
{
    public ScrollRect scrollRect;
    public RectTransform contentPanel;
    public RectTransform sampleListItem;
    public HorizontalLayoutGroup HLG;

    public float scrollSpeed = 10f;

    private void Update()
    {
        // Move to next item on right arrow key press
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveToNextItem();
        }
        // Move to previous item on left arrow key press
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveToPreviousItem();
        }
        // Trigger click event on currently visible item when R key is pressed
        else if (Input.GetKeyDown(KeyCode.R))
        {
            TriggerClickOnVisibleItem();
        }
    }

    private void MoveToNextItem()
    {
        int currentItem = Mathf.RoundToInt((0 - contentPanel.localPosition.x) / (sampleListItem.rect.width + HLG.spacing));
        int nextItem = currentItem + 1;
        float targetPosition = Mathf.Clamp(nextItem * (sampleListItem.rect.width + HLG.spacing), 0f, contentPanel.rect.width - scrollRect.viewport.rect.width);
        contentPanel.localPosition = new Vector2(-targetPosition, contentPanel.localPosition.y);
    }

    private void MoveToPreviousItem()
    {
        int currentItem = Mathf.RoundToInt((0 - contentPanel.localPosition.x) / (sampleListItem.rect.width + HLG.spacing));
        int previousItem = currentItem - 1;
        float targetPosition = Mathf.Clamp(previousItem * (sampleListItem.rect.width + HLG.spacing), 0f, contentPanel.rect.width - scrollRect.viewport.rect.width);
        contentPanel.localPosition = new Vector2(-targetPosition, contentPanel.localPosition.y);
    }

    private void TriggerClickOnVisibleItem()
    {
        // Find the currently visible item
        foreach (Transform child in contentPanel)
        {
            if (IsItemVisible(child))
            {
                // Trigger the click event on the button component of the item
                Button button = child.GetComponent<Button>();
                if (button != null)
                {
                    button.onClick.Invoke();
                }
                break;
            }
        }
    }

    private bool IsItemVisible(Transform item)
    {
        // Check if the item is currently visible in the viewport
        Rect itemRect = new Rect(item.position, item.GetComponent<RectTransform>().sizeDelta);
        Rect viewportRect = new Rect(scrollRect.viewport.position, scrollRect.viewport.sizeDelta);
        return viewportRect.Overlaps(itemRect);
    }
}



