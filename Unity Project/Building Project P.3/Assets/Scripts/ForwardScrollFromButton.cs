/*This script fixes the issue of buttons that have hoverability functionality not being scrollable, i.e, when the mouse was on top
 of them, priority was given to the hoverability and therefore eliminated the ability to scroll further down or up the menu.*/
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ForwardScrollFromButton : MonoBehaviour, IScrollHandler
{
    private ScrollRect scrollRect;

    void Start()
    {
        scrollRect = GetComponentInParent<ScrollRect>();
    }

    public void OnScroll(PointerEventData eventData)
    {
        if (scrollRect != null)
            scrollRect.OnScroll(eventData);
    }
}
