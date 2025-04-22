using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class FlashlightController : MonoBehaviour
{
    public ARCameraManager arCameraManager; // Reference to the AR Camera Manager
    private Light flashlight; // Reference to the Light component
    private bool isFlashlightOn = false; // Track flashlight state

    // Threshold brightness value (adjust as needed)
    private float brightnessThreshold = 0.2f;

    void Start()
    {
        // Find the AR Camera Manager in the scene
        arCameraManager = FindObjectOfType<ARCameraManager>();

        // Get the Light component from the AR Camera
        flashlight = Camera.main?.GetComponent<Light>();

        // Ensure we have a valid light component
        if (flashlight == null)
        {
            Debug.LogError("No Light component found on Camera. Add a Light to enable the flashlight.");
            return;
        }

        // Ensure flashlight is off at start
        flashlight.enabled = false;

        // Subscribe to AR Camera Frame event for light estimation
        if (arCameraManager != null)
        {
            arCameraManager.frameReceived += OnFrameReceived;
        }
    }

    private void OnFrameReceived(ARCameraFrameEventArgs args)
    {
        // Check if the AR session provides brightness data
        if (args.lightEstimation.averageBrightness.HasValue)
        {
            float brightness = args.lightEstimation.averageBrightness.Value;

            Debug.Log("Current Brightness: " + brightness);

            // Turn ON flashlight if brightness is too low
            if (brightness < brightnessThreshold && !isFlashlightOn)
            {
                flashlight.enabled = true;
                isFlashlightOn = true;
                Debug.Log("Flashlight ON - Environment is too dark.");
            }
            // Turn OFF flashlight if brightness is sufficient
            else if (brightness >= brightnessThreshold && isFlashlightOn)
            {
                flashlight.enabled = false;
                isFlashlightOn = false;
                Debug.Log("Flashlight OFF - Environment is bright enough.");
            }
        }
    }

    private void OnDestroy()
    {
        // Unsubscribe from AR Camera frame event when destroyed
        if (arCameraManager != null)
        {
            arCameraManager.frameReceived -= OnFrameReceived;
        }
    }
}
