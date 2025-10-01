using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    public Transform[] cameraPositions; // Array to hold the positions or rotations the camera can move to.
    public float transitionSpeed = 5f; // Speed at which the camera moves.

    private int currentPositionIndex = 0; // Tracks the current position index.

    void Update()
    {
        // Check for input to switch the camera.
        if (Input.GetKeyDown(KeyCode.A))
        {
            SwitchCamera(-1); // Move to the previous position.
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            SwitchCamera(1); // Move to the next position.
        }

        // Smoothly move the camera to the target position.
        if (cameraPositions.Length > 0)
        {
            transform.position = Vector3.Lerp(transform.position, cameraPositions[currentPositionIndex].position, Time.deltaTime * transitionSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, cameraPositions[currentPositionIndex].rotation, Time.deltaTime * transitionSpeed);
        }
    }

    void SwitchCamera(int direction)
    {
        // Update the current position index based on the direction.
        currentPositionIndex += direction;

        // Clamp the index to stay within bounds.
        if (currentPositionIndex < 0)
        {
            currentPositionIndex = cameraPositions.Length - 1;
        }
        else if (currentPositionIndex >= cameraPositions.Length)
        {
            currentPositionIndex = 0;
        }
    }
}

