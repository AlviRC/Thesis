using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class TMPLinkHandler : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    private TextMeshProUGUI tmpText;
    private int lastHoveredLink = -1;
    private Color32[] originalColors; // Array to store original colors

    void Start()
    {
        tmpText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        // Detect hover over a link
        Vector3 worldPoint;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(tmpText.rectTransform, Input.mousePosition, null, out worldPoint);
        int linkIndex = TMP_TextUtilities.FindIntersectingLink(tmpText, worldPoint, null);

        if (linkIndex != -1) // If hovering over a link
        {
            // Highlight the new link only if it's different from the last one
            if (linkIndex != lastHoveredLink)
            {
                if (lastHoveredLink != -1)
                {
                    HighlightLink(lastHoveredLink, false); // Remove highlight from the previous link
                }
                HighlightLink(linkIndex, true); // Highlight the new link
                lastHoveredLink = linkIndex;
            }
        }
        else if (lastHoveredLink != -1) // If no link is hovered, remove highlight
        {
            HighlightLink(lastHoveredLink, false);
            lastHoveredLink = -1;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Vector3 worldPoint;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(tmpText.rectTransform, eventData.position, eventData.pressEventCamera, out worldPoint);
        int linkIndex = TMP_TextUtilities.FindIntersectingLink(tmpText, worldPoint, eventData.pressEventCamera);

        if (linkIndex != -1) // If a link was clicked
        {
            TMP_LinkInfo linkInfo = tmpText.textInfo.linkInfo[linkIndex];
            string linkID = linkInfo.GetLinkID();

            // Open the link in a web browser
            Application.OpenURL(linkID);
        }
    }

    // ✅ Add this method to fix the error
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Required by IPointerEnterHandler but not used here
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // When exiting a link, remove the highlight if we were hovering over one
        if (lastHoveredLink != -1)
        {
            HighlightLink(lastHoveredLink, false);
            lastHoveredLink = -1;
        }
    }

    private void HighlightLink(int linkIndex, bool highlight)
    {
        TMP_LinkInfo linkInfo = tmpText.textInfo.linkInfo[linkIndex];

        // If we haven't stored the original colors yet, do so
        if (originalColors == null || originalColors.Length != tmpText.textInfo.meshInfo.Length)
        {
            originalColors = new Color32[tmpText.textInfo.meshInfo.Length];
            // Store original colors
            for (int meshIndex = 0; meshIndex < tmpText.textInfo.meshInfo.Length; meshIndex++)
            {
                originalColors[meshIndex] = tmpText.textInfo.meshInfo[meshIndex].colors32[0]; // Default to storing the first color of each mesh
            }
        }

        Color32 highlightColor = highlight ? new Color32(255, 255, 0, 255) : tmpText.color; // Yellow or default color

        for (int i = 0; i < linkInfo.linkTextLength; i++)
        {
            int characterIndex = linkInfo.linkTextfirstCharacterIndex + i;
            int meshIndex = tmpText.textInfo.characterInfo[characterIndex].materialReferenceIndex;
            int vertexIndex = tmpText.textInfo.characterInfo[characterIndex].vertexIndex;

            Color32[] newVertexColors = tmpText.textInfo.meshInfo[meshIndex].colors32;

            if (highlight)
            {
                // Highlighting the link
                newVertexColors[vertexIndex + 0] = highlightColor;
                newVertexColors[vertexIndex + 1] = highlightColor;
                newVertexColors[vertexIndex + 2] = highlightColor;
                newVertexColors[vertexIndex + 3] = highlightColor;
            }
            else
            {
                // Restoring the original color
                newVertexColors[vertexIndex + 0] = originalColors[meshIndex];
                newVertexColors[vertexIndex + 1] = originalColors[meshIndex];
                newVertexColors[vertexIndex + 2] = originalColors[meshIndex];
                newVertexColors[vertexIndex + 3] = originalColors[meshIndex];
            }
        }

        tmpText.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32); // Apply color changes
    }
}
