/*This script handles the player's and camera's movement, both on Pc and Mobile.*/
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI; // Required for UI elements
using TMPro;
using System.Collections;

public class Movement_Player : MonoBehaviour
{
    [Header("General")]
    public bool useMobileControls = false;


    public float speed = 6f; // Movement speed
    public float gravity = -9.81f; // Gravity value
    public float jumpHeight = 1.5f; // Jump height
    public Transform cameraTransform; // Reference to the camera

    public float mouseSensitivity = 20f; // Sensitivity for mouse movement
    public float cameraSpeed = 1.2f;
    private float xRotation = 0f; // Current vertical rotation of the camera

    private CharacterController controller;
    private Vector3 velocity; // Player's current velocity
    private bool isGrounded; // Check if player is on the ground

    public float smoothingFactor = 0.1f; // Smooth the mouse movement
    public float clampfactor = 5f;
    private Vector2 currentMouseLook;
    private Vector2 smoothV;
    private bool mobileusage = false;


    [Header("Mobile Joysticks")]
    public RectTransform leftBG;
    public RectTransform leftHandle;
    public RectTransform rightBG;
    public RectTransform rightHandle;
    private Vector2 leftInput;
    private Vector2 rightInput;
    public float joystickRange = 50f;
    public Slider CameraSlider;
    public WaypointSystem player;
    public bool hide = false;
    public GameObject ChangeDevice;

    public TMP_Text changedevicelabel;
    public bool isdeactivated = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    /*Changes the position of the camera for Pc or both movements for Mobile*/
    void Update()
    {
        if (mobileusage == true)
        {
            GetJoystickInput();
            ApplyMobileRotation();
        }
        else
        {
            // Handle mouse input for rotation with smoothing
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            // Clamp extreme values to suppress random spikes (adjust limits if needed)
            mouseX = Mathf.Clamp(mouseX, -clampfactor, clampfactor);
            mouseY = Mathf.Clamp(mouseY, -clampfactor, clampfactor);

            // Smooth the input
            smoothV.x = Mathf.Lerp(smoothV.x, mouseX, 1f / smoothingFactor);
            smoothV.y = Mathf.Lerp(smoothV.y, mouseY, 1f / smoothingFactor);
            currentMouseLook += smoothV;

            // Rotate the player horizontally
            transform.Rotate(Vector3.up * smoothV.x);

            // Rotate the camera vertically
            xRotation -= smoothV.y;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limit vertical rotation
            cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        }
    }

    /*Changes the movement of the player for Pc.*/
    void FixedUpdate()
    {
        if (mobileusage == true)
        {
            // Check if player is on the ground
            isGrounded = controller.isGrounded;

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f; // Reset downward velocity when grounded
            }

            // Get input for movement
            float horizontal = leftInput.x;
            float vertical = leftInput.y;
            if ((horizontal != 0f || vertical != 0f) && hide == false)
            {
                hide = true;
                StartCoroutine(DeactivateAfterSeconds());
            }

            // Move the player
            Vector3 move = (transform.right * horizontal + transform.forward * vertical) * speed * Time.fixedDeltaTime;
            velocity.y += gravity * Time.fixedDeltaTime; // Apply gravity
            controller.Move(move + velocity * Time.fixedDeltaTime); // Combine movement and gravity
        }
        else
        {
            // Check if player is on the ground
            isGrounded = controller.isGrounded;

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f; // Reset downward velocity when grounded
            }

            // Get input for movement
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            if ((horizontal != 0f || vertical != 0f) && hide == false)
            {
                hide = true;
                StartCoroutine(DeactivateAfterSeconds());
            }
            // Move the player
            Vector3 move = (transform.right * horizontal + transform.forward * vertical) * speed * Time.fixedDeltaTime;
            velocity.y += gravity * Time.fixedDeltaTime; // Apply gravity
            controller.Move(move + velocity * Time.fixedDeltaTime); // Combine movement and gravity
        }
    }

    /*Terminates the label that says to Change Device */
    private IEnumerator DeactivateAfterSeconds()
    {
        Color color = changedevicelabel.color;
        color.a = Mathf.Clamp01(85 / 255f);
        changedevicelabel.color = color;
        yield return new WaitForSeconds(30f);
        if (ChangeDevice != null)
        {
            ChangeDevice.SetActive(false);
        }
        player.CbeingAbledToUse = false;
        isdeactivated = true;
    }

    /*Initial values for the movement of the camera for Pc and Mobile.*/

    public void Movement_Start(bool mobile)
    {
        if (mobile == true)
        {
            mobileusage = true;
            Cursor.lockState = CursorLockMode.None;
            CameraSlider.minValue = 1f;
            CameraSlider.maxValue = 2f;
            CameraSlider.value = cameraSpeed;
        }
        else
        {
            mobileusage = false;
            Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the game window
            CameraSlider.minValue = 0.1f;
            CameraSlider.maxValue = 2f;
            CameraSlider.value = mouseSensitivity;
        }
    }

    /*Changes the Speed of the player.*/
    public void ChangeSpeed(float NewSpeed)
    {
        speed = NewSpeed;
    }

    /*Change the Speed of the camera.*/
    public void ChangeCameraSpeed(float camera_speed)
    {
        if (mobileusage == true)
        {
            cameraSpeed = camera_speed;
        }
        else
        {
            mouseSensitivity = camera_speed;
        }
    }


    /*Receives joystick input on Mobile and translates it to moves for the camera and player.*/
    private int leftTouchId = -1;
    private int rightTouchId = -1;

    void GetJoystickInput()
    {
        leftInput = Vector2.zero;
        rightInput = Vector2.zero;

        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                if (IsTouchOnRectTransform(touch.position, leftBG))
                    leftTouchId = touch.fingerId;
                else if (IsTouchOnRectTransform(touch.position, rightBG))
                    rightTouchId = touch.fingerId;
            }

            if (touch.fingerId == leftTouchId)
            {
                if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                {
                    leftTouchId = -1;
                    leftHandle.anchoredPosition = Vector2.zero;
                    leftInput = Vector2.zero;
                }
                else
                {
                    Vector2 localPoint;
                    RectTransformUtility.ScreenPointToLocalPointInRectangle(leftBG, touch.position, null, out localPoint);
                    localPoint = Vector2.ClampMagnitude(localPoint, joystickRange);
                    leftHandle.anchoredPosition = localPoint;
                    leftInput = localPoint / joystickRange;
                }
            }
            else if (touch.fingerId == rightTouchId)
            {
                if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                {
                    rightTouchId = -1;
                    rightHandle.anchoredPosition = Vector2.zero;
                    rightInput = Vector2.zero;
                }
                else
                {
                    Vector2 localPoint;
                    RectTransformUtility.ScreenPointToLocalPointInRectangle(rightBG, touch.position, null, out localPoint);
                    localPoint = Vector2.ClampMagnitude(localPoint, joystickRange);
                    rightHandle.anchoredPosition = localPoint;
                    rightInput = localPoint / joystickRange;
                }
            }
        }

        // Reset handles if not actively touched
        if (leftTouchId == -1) leftHandle.anchoredPosition = Vector2.zero;
        if (rightTouchId == -1) rightHandle.anchoredPosition = Vector2.zero;
    }

    /*Checks if the touch input was on the joysticks exact areas and not outside.*/
    private bool IsTouchOnRectTransform(Vector2 screenPosition, RectTransform rect)
    {
        Vector2 localPoint;
        return RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rect, screenPosition, null, out localPoint
        ) && rect.rect.Contains(localPoint);
    }

    void ApplyMobileRotation()
    {
        float lookX = rightInput.x * cameraSpeed;// * Time.deltaTime;
        float lookY = rightInput.y * cameraSpeed;// * Time.deltaTime;

        // Clamp extreme values to suppress random spikes (adjust limits if needed)
        lookX = Mathf.Clamp(lookX, -clampfactor, clampfactor);
        lookY = Mathf.Clamp(lookY, -clampfactor, clampfactor);

        // Smooth the input
        smoothV.x = Mathf.Lerp(smoothV.x, lookX, 1f / smoothingFactor);
        smoothV.y = Mathf.Lerp(smoothV.y, lookY, 1f / smoothingFactor);
        currentMouseLook += smoothV;

        // Rotate the player horizontally
        transform.Rotate(Vector3.up * smoothV.x);

        xRotation -= smoothV.y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

    }
}
