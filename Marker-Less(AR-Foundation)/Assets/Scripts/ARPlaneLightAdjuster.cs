/*
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARPlaneLightAdjuster : MonoBehaviour
{
    public ARCameraManager arCameraManager;  // Reference to AR Camera Manager
    public ARPlaneManager arPlaneManager;    // Reference to AR Plane Manager
    public Material planeMaterial;           // The material used for AR planes

    private void OnEnable()
    {
        if (arCameraManager != null)
        {
            arCameraManager.frameReceived += OnCameraFrameReceived;
        }
    }

    private void OnDisable()
    {
        if (arCameraManager != null)
        {
            arCameraManager.frameReceived -= OnCameraFrameReceived;
        }
    }

    private void OnCameraFrameReceived(ARCameraFrameEventArgs args)
    {
        // Check if brightness data is available
        if (args.lightEstimation.averageBrightness.HasValue)
        {
            float brightness = args.lightEstimation.averageBrightness.Value; // Get the brightness value (0 = dark, 1 = bright)

            if (planeMaterial != null)
            {
                // Adjust brightness by multiplying material color with brightness factor
                Color baseColor = planeMaterial.color;
                Color adjustedColor = baseColor * brightness;  // Scale brightness dynamically
                planeMaterial.color = adjustedColor;
            }

            // Apply updated material to all planes
            foreach (ARPlane plane in arPlaneManager.trackables)
            {
                MeshRenderer renderer = plane.GetComponentInChildren<MeshRenderer>();
                if (renderer != null)
                {
                    renderer.material = planeMaterial;
                }
            }
        }
    }
}
*/





using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARPlaneLightAdjuster : MonoBehaviour
{
    public ARCameraManager arCameraManager;    // Reference to AR Camera Manager
    public ARPlaneManager arPlaneManager;      // Reference to AR Plane Manager
    public Material[] planeMaterials;          // Array of materials for AR planes

    private int currentMaterialIndex = 0;       // Tracks the currently selected material

    private void OnEnable()
    {
        if (arCameraManager != null)
        {
            arCameraManager.frameReceived += OnCameraFrameReceived;
        }
    }

    private void OnDisable()
    {
        if (arCameraManager != null)
        {
            arCameraManager.frameReceived -= OnCameraFrameReceived;
        }
    }

    // Function to assign a material from the array based on UI selection
    public void SetMaterial(int index)
    {
        if (index < 0 || index >= planeMaterials.Length)
        {
            Debug.LogError("Invalid material index.");
            return;
        }

        currentMaterialIndex = index; // Store selected material

        foreach (ARPlane plane in arPlaneManager.trackables)
        {
            MeshRenderer renderer = plane.GetComponentInChildren<MeshRenderer>();

            if (renderer != null)
            {
                renderer.material = planeMaterials[index];
            }
        }
    }

    // Light Estimation - Adjust brightness dynamically
    private void OnCameraFrameReceived(ARCameraFrameEventArgs args)
    {
        if (args.lightEstimation.averageBrightness.HasValue)
        {
            float brightness = args.lightEstimation.averageBrightness.Value;

            foreach (ARPlane plane in arPlaneManager.trackables)
            {
                MeshRenderer renderer = plane.GetComponentInChildren<MeshRenderer>();

                if (renderer != null)
                {
                    Material planeMaterial = renderer.material;
                    Color baseColor = planeMaterial.color;
                    Color adjustedColor = baseColor * brightness;
                    planeMaterial.color = adjustedColor;
                }
            }
        }
    }
}
