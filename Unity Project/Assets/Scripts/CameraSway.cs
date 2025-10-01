using UnityEngine;

public class CameraSway : MonoBehaviour
{
    public float swayAmount = 10f; // Max angle in degrees (left/right)
    public float swaySpeed = 1f;   // Speed of the sway

    private float initialYRotation;

    void Start()
    {
        initialYRotation = transform.eulerAngles.y;
    }

    void Update()
    {
        float angleOffset = Mathf.Sin(Time.time * swaySpeed) * swayAmount;
        Vector3 newRotation = new Vector3(
            transform.eulerAngles.x,
            initialYRotation + angleOffset,
            transform.eulerAngles.z
        );
        transform.eulerAngles = newRotation;
    }
}
