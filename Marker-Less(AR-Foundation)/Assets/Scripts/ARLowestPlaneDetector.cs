/*
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using System.Collections.Generic;

public class ARLowestPlaneDetector : MonoBehaviour
{
    public ARPlaneManager arPlaneManager;
    private ARPlane lowestPlane;  // Stores the lowest Y plane
    public float heightThreshold = 0.1f; // Allow planes slightly above the lowest plane

    void Start()
    {
        arPlaneManager.planesChanged += OnPlanesChanged;
    }

    private void OnPlanesChanged(ARPlanesChangedEventArgs args)
    {
        // Find the lowest plane
        foreach (ARPlane plane in arPlaneManager.trackables)
        {
            if (lowestPlane == null || plane.transform.position.y < lowestPlane.transform.position.y)
            {
                lowestPlane = plane;
            }
        }

        if (lowestPlane == null) return; // No valid planes detected yet

        float lowestY = lowestPlane.transform.position.y;

        // Enable planes within the threshold range and disable others
        foreach (ARPlane plane in arPlaneManager.trackables)
        {
            if (plane.transform.position.y <= lowestY + heightThreshold)
            {
                plane.gameObject.SetActive(true);  // Keep plane active if it's within range
            }
            else
            {
                plane.gameObject.SetActive(false); // Disable higher planes
            }
        }
    }
}
*/


// 2nd script
/*
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using System.Collections.Generic;

public class ARLowestPlaneDetector : MonoBehaviour
{
    public ARPlaneManager arPlaneManager;
    private ARPlane lowestPlane;
    public float heightThreshold = 0.1f; // Allow planes slightly above the lowest plane
    public float verticalThreshold = 0.3f; // Sensitivity to filter out vertical planes

    void Start()
    {
        arPlaneManager.planesChanged += OnPlanesChanged;
    }

    private void OnPlanesChanged(ARPlanesChangedEventArgs args)
    {
        lowestPlane = null;
        float lowestY = float.MaxValue;

        // Find the lowest horizontal plane
        foreach (ARPlane plane in arPlaneManager.trackables)
        {
            Vector3 normal = plane.transform.up; // Get plane's normal vector

            // Check if the plane is **horizontal** by verifying its normal is mostly (0,1,0)
            if (Mathf.Abs(normal.y) >= (1f - verticalThreshold)) // If it's close to (0,1,0), it's horizontal
            {
                if (plane.transform.position.y < lowestY)
                {
                    lowestY = plane.transform.position.y;
                    lowestPlane = plane;
                }
            }
        }

        if (lowestPlane == null) return; // No valid planes found

        // Enable planes within the height threshold range & disable all others
        foreach (ARPlane plane in arPlaneManager.trackables)
        {
            Vector3 normal = plane.transform.up;
            if (Mathf.Abs(normal.y) >= (1f - verticalThreshold) && plane.transform.position.y <= lowestY + heightThreshold)
            {
                plane.gameObject.SetActive(true);  // Keep valid horizontal planes active
            }
            else
            {
                plane.gameObject.SetActive(false); // Hide vertical and higher planes
            }
        }
    }
}
*/




using UnityEngine;
using UnityEngine.XR.ARFoundation;
using System.Collections.Generic;

public class ARLowestPlaneDetector : MonoBehaviour
{
    public ARPlaneManager arPlaneManager;
    private ARPlane lowestPlane;
    public float heightThreshold = 0.1f;  // Allow slight variation above the lowest plane
    public float verticalThreshold = 0.99f; // Disable all non-horizontal planes

    void Start()
    {
        arPlaneManager.planesChanged += OnPlanesChanged;
    }

    private void OnPlanesChanged(ARPlanesChangedEventArgs args)
    {
        lowestPlane = null;
        float lowestY = float.MaxValue;

        // First, disable all vertical planes
        foreach (ARPlane plane in arPlaneManager.trackables)
        {
            Vector3 normal = plane.normal;

            // Disable plane if it's not mostly horizontal
            if (Mathf.Abs(normal.y) < verticalThreshold)
            {
                plane.gameObject.SetActive(false);
            }
        }

        // Find the lowest horizontal plane
        foreach (ARPlane plane in arPlaneManager.trackables)
        {
            if (!plane.gameObject.activeSelf) continue; // Skip disabled planes

            float planeY = plane.transform.position.y;
            if (planeY < lowestY)
            {
                lowestY = planeY;
                lowestPlane = plane;
            }
        }

        if (lowestPlane == null) return; // No valid horizontal planes found

        // Enable only planes within the height threshold from the lowest plane
        foreach (ARPlane plane in arPlaneManager.trackables)
        {
            if (!plane.gameObject.activeSelf) continue; // Skip disabled (vertical) planes

            bool isWithinThreshold = plane.transform.position.y <= (lowestY + heightThreshold);
            plane.gameObject.SetActive(isWithinThreshold);
        }
    }
}