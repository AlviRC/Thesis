/*This script handles the disappearing and appearing of the bus stop and the deanery, to the user, from a certain given distance.*/
using UnityEngine;
using TMPro;

public class DistanceVisibility : MonoBehaviour
{
    public Transform player;             // Reference to the player or camera
    public float visibleDistance = 10f;  // Distance within which the item is visible

    private Renderer itemRenderer;
    private TMP_Text tmpText;

    void Start()
    {
        itemRenderer = GetComponent<Renderer>();
        tmpText = GetComponent<TMP_Text>();

        if (player == null)
        {
            player = Camera.main.transform; // Default to Main Camera
        }
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= visibleDistance)
        {
            // Visible case
            if (itemRenderer != null)
                itemRenderer.enabled = true;

            if (tmpText != null)
                tmpText.enabled = true;
        }
        else
        {
            // Not visible case
            if (itemRenderer != null)
                itemRenderer.enabled = false;

            if (tmpText != null)
                tmpText.enabled = false;
        }
    }
}
