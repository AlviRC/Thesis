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
