using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARPlaneAreaCalculator : MonoBehaviour
{
    public ARPlaneManager arPlaneManager;  // Reference to ARPlaneManager
    public TMPro.TextMeshProUGUI areaText; // UI Text to display area (optional)

    private void OnEnable()
    {
        arPlaneManager.planesChanged += OnPlanesChanged;
    }

    private void OnDisable()
    {
        arPlaneManager.planesChanged -= OnPlanesChanged;
    }

    private void OnPlanesChanged(ARPlanesChangedEventArgs args)
    {
        foreach (ARPlane plane in args.added)
        {
            CalculatePlaneArea(plane);
        }

        foreach (ARPlane plane in args.updated)
        {
            CalculatePlaneArea(plane);
        }
    }

    private void CalculatePlaneArea(ARPlane plane)
    {
        if (plane.alignment == PlaneAlignment.HorizontalUp)
        {
            float area = GetPlaneArea(plane);
            Debug.Log($"Plane Area: {area} sq. meters");

            // Display on UI (if assigned)
            if (areaText != null)
            {
                areaText.text = $"Area: {area:F2} sq. meters";
            }
        }
    }

    private float GetPlaneArea(ARPlane plane)
    {
        // Get the convex boundary points of the detected plane
        List<Vector2> boundary = new List<Vector2>(plane.boundary);

        if (boundary.Count < 3)
            return 0f; // A valid area needs at least 3 points

        float area = 0f;
        int j = boundary.Count - 1;

        // Shoelace formula to calculate polygon area
        for (int i = 0; i < boundary.Count; i++)
        {
            area += (boundary[j].x + boundary[i].x) * (boundary[j].y - boundary[i].y);
            j = i;
        }

        return Mathf.Abs(area * 0.5f); // Convert to absolute value
    }
}
