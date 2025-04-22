//Original
/*
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARTrackingToggle : MonoBehaviour
{
    public ARPlaneManager arPlaneManager;
    public ARRaycastManager arRaycastManager;
    public ARSession arSession;
    public List<GameObject> spawnedObjects = new List<GameObject>();
    private bool isTrackingEnabled = true;

    public void ToggleTracking()
    {
        if (isTrackingEnabled)
        {
            // disable planes
            arPlaneManager.enabled = false;
            foreach (var plane in arPlaneManager.trackables)
            {
                plane.gameObject.SetActive(false);
            }
            //arSession.enabled = false;

            arRaycastManager.enabled = false;  // disable raycast
            
            foreach (var obj in spawnedObjects)
            {
                obj.SetActive(false);
            }
        }
        else
        {
            // enable planes
            //arSession.enabled = true;

            arRaycastManager.enabled = true;
            
            arPlaneManager.enabled = true;
            
            foreach (var obj in spawnedObjects)
            {
                obj.SetActive(true);
            }
        }

        isTrackingEnabled = !isTrackingEnabled;
    }

    public void RegisterSpawnedObject(GameObject obj)
    {
        spawnedObjects.Add(obj);
    }
}
*/




// 2nd Script (working)
/*
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARTrackingToggle : MonoBehaviour
{
    public ARPlaneManager arPlaneManager;
    public ARRaycastManager arRaycastManager;
    public ARSession arSession;
    public List<GameObject> spawnedObjects = new List<GameObject>();
    private bool isTrackingEnabled = true;

    public void ToggleTracking()
    {
        if (isTrackingEnabled)
        {
            // Disable all planes
            arPlaneManager.enabled = false;
            foreach (var plane in arPlaneManager.trackables)
            {
                plane.gameObject.SetActive(false);
            }

            arRaycastManager.enabled = false;  // Disable raycasting

            foreach (var obj in spawnedObjects)
            {
                obj.SetActive(false);
            }
        }
        else
        {
            // Enable tracking components
            arRaycastManager.enabled = true;
            arPlaneManager.enabled = true;

            // Identify the lowest Y-plane
            ARPlane lowestPlane = null;
            foreach (var plane in arPlaneManager.trackables)
            {
                if (lowestPlane == null || plane.transform.position.y < lowestPlane.transform.position.y)
                {
                    lowestPlane = plane;
                }
            }

            // Activate only the lowest plane, disable others
            foreach (var plane in arPlaneManager.trackables)
            {
                plane.gameObject.SetActive(plane == lowestPlane);
            }

            // Enable spawned objects
            foreach (var obj in spawnedObjects)
            {
                obj.SetActive(true);
            }
        }

        isTrackingEnabled = !isTrackingEnabled;
    }

    public void RegisterSpawnedObject(GameObject obj)
    {
        spawnedObjects.Add(obj);
    }
}
*/




// 3rd script
/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARTrackingToggle : MonoBehaviour
{
    public ARPlaneManager arPlaneManager;
    public ARRaycastManager arRaycastManager;
    public ARSession arSession;
    public List<GameObject> spawnedObjects = new List<GameObject>();
    private bool isTrackingEnabled = true;

    public void ToggleTracking()
    {
        if (isTrackingEnabled)
        {
            arPlaneManager.enabled = false;
            foreach (var plane in arPlaneManager.trackables)
            {
                plane.gameObject.SetActive(false);
            }

            arRaycastManager.enabled = false;

            foreach (var obj in spawnedObjects)
            {
                obj.SetActive(false);
            }
        }
        else
        {
            arRaycastManager.enabled = true;
            arPlaneManager.enabled = true;

            ARPlane lowestPlane = null;
            foreach (var plane in arPlaneManager.trackables)
            {
                if (lowestPlane == null || plane.transform.position.y < lowestPlane.transform.position.y)
                {
                    lowestPlane = plane;
                }
            }

            foreach (var plane in arPlaneManager.trackables)
            {
                plane.gameObject.SetActive(plane == lowestPlane);
            }

            foreach (var obj in spawnedObjects)
            {
                obj.SetActive(true);
            }
        }

        isTrackingEnabled = !isTrackingEnabled;
    }

    public void RegisterSpawnedObject(GameObject obj)
    {
        spawnedObjects.Add(obj);
    }

    public void RestartPlaneDetection()
    {
        List<ARPlane> planes = new List<ARPlane>();
        foreach (var plane in arPlaneManager.trackables)
        {
            planes.Add(plane);
        }

        foreach (var plane in planes)
        {
            Destroy(plane.gameObject);
        }

        foreach (var obj in spawnedObjects)
        {
            Destroy(obj);
        }
        spawnedObjects.Clear();

        StartCoroutine(RestartARSession());
    }

    private IEnumerator RestartARSession()
    {
        arSession.Reset();
        yield return null;

        arPlaneManager.enabled = true;
        arRaycastManager.enabled = true;
    }
}
*/




/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARTrackingToggle : MonoBehaviour
{
    public ARPlaneManager arPlaneManager;
    public ARRaycastManager arRaycastManager;
    public ARSession arSession;
    public List<GameObject> spawnedObjects = new List<GameObject>();
    private bool isTrackingEnabled = true;

    public ARPlaneMaterialManager materialManager; // Reference to ARPlaneMaterialManager

    //initial setup for toggling on/off AR Plane
    public void ToggleTracking()
    {
        if (isTrackingEnabled)
        {
            arPlaneManager.enabled = false;
            foreach (var plane in arPlaneManager.trackables)
            {
                plane.gameObject.SetActive(false);
            }
            arRaycastManager.enabled = false;
            foreach (var obj in spawnedObjects)
            {
                obj.SetActive(false);
            }
        }
        else
        {
            arRaycastManager.enabled = true;
            arPlaneManager.enabled = true;

            ARPlane lowestPlane = null;
            foreach (var plane in arPlaneManager.trackables)
            {
                if (lowestPlane == null || plane.transform.position.y < lowestPlane.transform.position.y)
                {
                    lowestPlane = plane;
                }
            }

            foreach (var plane in arPlaneManager.trackables)
            {
                plane.gameObject.SetActive(plane == lowestPlane);
            }

            foreach (var obj in spawnedObjects)
            {
                obj.SetActive(true);
            }
        }

        isTrackingEnabled = !isTrackingEnabled;
    }

    public void RegisterSpawnedObject(GameObject obj)
    {
        spawnedObjects.Add(obj);
    }

    public void RestartPlaneDetection()
    {
        List<ARPlane> planes = new List<ARPlane>();
        foreach (var plane in arPlaneManager.trackables)
        {
            planes.Add(plane);
        }

        foreach (var plane in planes)
        {
            Destroy(plane.gameObject);
        }

        foreach (var obj in spawnedObjects)
        {
            Destroy(obj);
        }
        spawnedObjects.Clear();

        materialManager?.ResetUI(); // Reset UI values

        StartCoroutine(RestartARSession());
    }

    private IEnumerator RestartARSession()
    {
        arSession.Reset();
        yield return null;

        arPlaneManager.enabled = true;
        arRaycastManager.enabled = true;
    }
}
*/




using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARTrackingToggle : MonoBehaviour
{
    public ARPlaneManager arPlaneManager;
    public ARRaycastManager arRaycastManager;
    public ARSession arSession;
    public List<GameObject> spawnedObjects = new List<GameObject>();
    private bool isTrackingEnabled = true;

    public ARPlaneMaterialManager materialManager; // Reference to ARPlaneMaterialManager

    public Material customMaterial; // Material assigned via editor
    private Material originalMaterial; // Store original material
    private bool isCustomMaterialApplied = false;

    /*
    [Header("Plane Prefabs")]
    public GameObject defaultPlanePrefab;
    public GameObject alternatePlanePrefab;

    private bool isUsingDefaultPrefab = true;
    */


    public void ToggleTracking()
    {
        if (isTrackingEnabled)
        {
            arPlaneManager.enabled = false;
            foreach (var plane in arPlaneManager.trackables)
            {
                plane.gameObject.SetActive(false);
            }
            arRaycastManager.enabled = false;
            foreach (var obj in spawnedObjects)
            {
                obj.SetActive(false);
            }
        }
        else
        {
            arRaycastManager.enabled = true;
            arPlaneManager.enabled = true;

            ARPlane lowestPlane = null;
            foreach (var plane in arPlaneManager.trackables)
            {
                if (lowestPlane == null || plane.transform.position.y < lowestPlane.transform.position.y)
                {
                    lowestPlane = plane;
                }
            }

            foreach (var plane in arPlaneManager.trackables)
            {
                plane.gameObject.SetActive(plane == lowestPlane);
            }

            foreach (var obj in spawnedObjects)
            {
                obj.SetActive(true);
            }
        }

        isTrackingEnabled = !isTrackingEnabled;
    }

    public void RegisterSpawnedObject(GameObject obj)
    {
        spawnedObjects.Add(obj);
    }

    public void RestartPlaneDetection()
    {
        List<ARPlane> planes = new List<ARPlane>();
        foreach (var plane in arPlaneManager.trackables)
        {
            planes.Add(plane);
        }

        foreach (var plane in planes)
        {
            Destroy(plane.gameObject);
        }

        foreach (var obj in spawnedObjects)
        {
            Destroy(obj);
        }
        spawnedObjects.Clear();

        materialManager?.ResetUI(); // Reset UI values

        StartCoroutine(RestartARSession());
    }

    private IEnumerator RestartARSession()
    {
        arSession.Reset();
        yield return null;

        arPlaneManager.enabled = true;
        arRaycastManager.enabled = true;
    }


    // Function to toggle the custom material on the AR plane
    public void TogglePlaneMaterial()
    {
        foreach (var plane in arPlaneManager.trackables)
        {
            MeshRenderer renderer = plane.GetComponent<MeshRenderer>();
            if (renderer != null)
            {
                if (!isCustomMaterialApplied)
                {
                    originalMaterial = renderer.material; // Store original material
                    renderer.material = customMaterial;
                }
                else
                {
                    renderer.material = originalMaterial; // Revert to original material
                }
            }
        }
        isCustomMaterialApplied = !isCustomMaterialApplied;
    }

    // Function to toggle between two different AR Plane prefabs
    /*
    public void TogglePlanePrefab()
    {
        if (arPlaneManager == null) return;

        // Get the current prefab and swap it
        arPlaneManager.planePrefab = isUsingDefaultPrefab ? alternatePlanePrefab : defaultPlanePrefab;
        isUsingDefaultPrefab = !isUsingDefaultPrefab;

        // Restart AR Plane Detection to apply changes
        RestartPlaneDetection();
    }
    */
}