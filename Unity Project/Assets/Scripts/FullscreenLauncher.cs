// using UnityEngine;
// using TMPro;
// using System.Collections;

// public class FullscreenManager : MonoBehaviour
// {
//     public GameObject overlayUI; // Black "Tap to Begin" screen
//     public TextMeshProUGUI LoadingLabel;

//     private bool cursorWasVisible = true;
//     private bool isTryingToEnterFullscreen = false;

//     void Start()
//     {
//         // Show overlay if not fullscreen at start
//         if (!Screen.fullScreen)
//         {
//             ShowOverlay();
//         }
//     }

//     void Update()
//     {
//         // If fullscreen exits at any point (e.g. user presses Escape)
//         if (!isTryingToEnterFullscreen && !Screen.fullScreen && !overlayUI.activeSelf)
//         {
//             // Save current cursor visibility before showing overlay
//             cursorWasVisible = Cursor.visible;

//             ShowOverlay();
//         }
//     }

//     public void OnUserTap()
//     {
//         // Only try fullscreen if we're not in it
//         if (!Screen.fullScreen && !isTryingToEnterFullscreen)
//         {
//             StartCoroutine(ActivateFullscreenProperly());
//         }
//         else if (Screen.fullScreen)
//         {
//             // Already fullscreen, just dismiss overlay and restore cursor
//             HideOverlayAndRestoreCursor();
//         }
//     }

//     private IEnumerator ActivateFullscreenProperly()
//     {
//         isTryingToEnterFullscreen = true;
//         string originalText = LoadingLabel.text;
//         LoadingLabel.text = "Loading...";

//         // Step 1: Unlock mouse so UI works
//         // Cursor.lockState = CursorLockMode.None;
//         // Cursor.visible = true;

//         // Step 2: Request fullscreen
//         Screen.fullScreen = true;

//         // Step 3: Wait for fullscreen to activate
//         float timeout = 1f;
//         float elapsed = 0f;
//         while (!Screen.fullScreen && elapsed < timeout)
//         {
//             elapsed += Time.deltaTime;
//             yield return null;
//         }

//         // Step 4: Hide overlay if fullscreen succeeded
//         if (Screen.fullScreen)
//         {
//             HideOverlayAndRestoreCursor();
//         }

//         LoadingLabel.text = originalText;
//         isTryingToEnterFullscreen = false;
//     }

//     private void ShowOverlay()
//     {
//         overlayUI.SetActive(true);
//         // Cursor.lockState = CursorLockMode.None;
//         // Cursor.visible = true;
//     }

//     private void HideOverlayAndRestoreCursor()
//     {
//         overlayUI.SetActive(false);

//         // if (!cursorWasVisible)
//         // {
//         //     Cursor.lockState = CursorLockMode.Locked;
//         //     Cursor.visible = false;
//         // }
//     }
// }
using UnityEngine;
using TMPro;

public class FullscreenManager : MonoBehaviour
{
    public GameObject overlayUI; // Black "Tap to Begin" screen
    public TextMeshProUGUI LoadingLabel;
    public GameObject Mobile;
    public GameObject PC;
    public GameObject Arrow;
    public GameObject player;

    private bool hasStarted = false;

    void Start()
    {
        #if UNITY_WEBGL
        Debug.Log("This is a WebGL build");
        if (Application.isMobilePlatform)
        {
            Debug.Log("Running WebGL on Mobile");
            ShowOverlay();
        }
        else
        {
            Debug.Log("Running WebGL on Desktop");
            this.enabled = false; // disable fullscreen logic on desktop
        }
        #endif
    }

    void Update()
    {
        // If fullscreen is lost (e.g. ESC pressed), show overlay again
        if (!Screen.fullScreen)
        {
            // player.GetComponent<Movement_Player>().enabled = false;
            // player.GetComponent<ItemCollector>().enabled = false;
            ShowOverlay();
        }
        else
        {
            ShowLoadingThenStart();
        }
    }

    public void OnUserTap()
    {
        // This MUST be directly inside a UI event (like a button)
        if (!Screen.fullScreen)
        {
            // Set immediately on user input — not in coroutine
            Screen.fullScreen = true;
            hasStarted = true;

            // Assume fullscreen will succeed; let Unity handle failure silently
            ShowLoadingThenStart();
        }
        else
        {
            ShowLoadingThenStart();
        }
    }

    private void ShowLoadingThenStart()
    {
        Mobile.SetActive(false);
        // PC.SetActive(false);
        // Arrow.SetActive(false);
        // player.GetComponent<Movement_Player>().enabled = true;
        // player.GetComponent<ItemCollector>().enabled = true;
        LoadingLabel.gameObject.SetActive(true);
        // LoadingLabel.text = "Loading...";
        Invoke(nameof(HideOverlayAndStart), 0.5f); // slight delay to simulate load
    }

    private void HideOverlayAndStart()
    {
        LoadingLabel.gameObject.SetActive(false);
        // LoadingLabel.text = "";
        overlayUI.SetActive(false);
    }

    private void ShowOverlay()
    {
        overlayUI.SetActive(true);
        Mobile.SetActive(true);
        // PC.SetActive(true);
        // Arrow.SetActive(true);
        // LoadingLabel.text = "Tap to Fullscreen";
    }
}
