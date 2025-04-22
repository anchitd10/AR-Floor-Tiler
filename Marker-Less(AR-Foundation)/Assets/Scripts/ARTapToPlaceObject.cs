// original
/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class ARTapToPlaceObject : MonoBehaviour
{
    public GameObject gameObjectToInstantiate;

    private GameObject spawnedObject;
    private ARRaycastManager _arRaycastManager;
    private Vector2 touchposition;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>(); 

    private void Awake()
    {
        _arRaycastManager = GetComponent<ARRaycastManager>();
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if(Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;
        return false;
    }

    void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPosition)) 
            return;

        if (_arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;

            if (spawnedObject == null)
            {
                spawnedObject = Instantiate(gameObjectToInstantiate, hitPose.position, hitPose.rotation);
            }
            else
            {
                spawnedObject.transform.position = hitPose.position;
            }
        }
    }
}
*/


// 2nd script
/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class ARTapToPlaceObject : MonoBehaviour
{
    public GameObject object1;  // Assign first object in Inspector
    public GameObject object2;  // Assign second object in Inspector

    private GameObject selectedObjectToInstantiate; // Stores the selected prefab
    private GameObject spawnedObject;
    private ARRaycastManager _arRaycastManager;
    private Vector2 touchPosition;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Awake()
    {
        _arRaycastManager = GetComponent<ARRaycastManager>();
        selectedObjectToInstantiate = object1; // Default selection
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;
        return false;
    }

    void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPosition))
            return;

        if (_arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;

            if (spawnedObject == null)
            {
                spawnedObject = Instantiate(selectedObjectToInstantiate, hitPose.position, hitPose.rotation);
            }
            else
            {
                spawnedObject.transform.position = hitPose.position;
            }
        }
    }

    // Function to select Object 1
    public void SelectObject1()
    {
        selectedObjectToInstantiate = object1;
        Debug.Log("Selected Object 1");
    }

    // Function to select Object 2
    public void SelectObject2()
    {
        selectedObjectToInstantiate = object2;
        Debug.Log("Selected Object 2");
    }
}
*/





// 3rd script
/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.EventSystems;

[RequireComponent(typeof(ARRaycastManager))]
public class ARTapToPlaceObject : MonoBehaviour
{
    public GameObject object1;  // Assign first object in Inspector
    public GameObject object2;  // Assign second object in Inspector

    private GameObject selectedObjectToInstantiate; // Stores the selected prefab
    private GameObject spawnedObject;
    private ARRaycastManager _arRaycastManager;
    private Vector2 touchPosition;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Awake()
    {
        _arRaycastManager = GetComponent<ARRaycastManager>();
        selectedObjectToInstantiate = object1; // Default selection
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;
        return false;
    }

    void Update()
    {
        if (Input.touchCount > 0 && IsTouchOverUI())
        {
            Debug.Log("Touch detected over UI element, ignoring.");
            return;
        }

        if (!TryGetTouchPosition(out Vector2 touchPosition))
            return;

        if (_arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;

            if (spawnedObject != null)
            {
                Destroy(spawnedObject);  // Remove the previous object
            }

            spawnedObject = Instantiate(selectedObjectToInstantiate, hitPose.position, hitPose.rotation);
            Debug.Log("Spawned an object at: " + hitPose.position);
        }
    }

    // Function to select Object 1
    public void SelectObject1()
    {
        selectedObjectToInstantiate = object1;
        Debug.Log("Selected Object 1");
    }

    // Function to select Object 2
    public void SelectObject2()
    {
        selectedObjectToInstantiate = object2;
        Debug.Log("Selected Object 2");
    }

    private bool IsTouchOverUI()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current)
        {
            position = Input.GetTouch(0).position
        };

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        return results.Count > 0;
    }
}
*/



/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.EventSystems;

public class ARTapToPlaceObject : MonoBehaviour
{
    public ARRaycastManager arRaycastManager;
    public GameObject objectPrefab; // Prefab to be instantiated

    private GameObject currentObject; // Reference to the currently moving object
    private List<GameObject> spawnedObjects = new List<GameObject>(); // List to store placed objects
    private List<ARRaycastHit> hitResults = new List<ARRaycastHit>();

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Prevent spawning if touch is over UI
            if (IsTouchOverUI()) return;

            if (arRaycastManager.Raycast(touch.position, hitResults, TrackableType.Planes))
            {
                Pose hitPose = hitResults[0].pose;

                if (touch.phase == TouchPhase.Began)
                {
                    // Instantiate new object only if no object is currently being moved
                    if (currentObject == null)
                    {
                        currentObject = Instantiate(objectPrefab, hitPose.position, hitPose.rotation);
                        spawnedObjects.Add(currentObject);
                    }
                }
                else if (touch.phase == TouchPhase.Moved && currentObject != null)
                {
                    // Move the object with the touch
                    currentObject.transform.position = hitPose.position;
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    // Fix the object in place and allow a new one to be placed next time
                    currentObject = null;
                }
            }
        }
    }

    private bool IsTouchOverUI()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current)
        {
            position = Input.GetTouch(0).position
        };

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        return results.Count > 0;
    }
}
*/



/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.EventSystems;

public class ARTapToPlaceObject : MonoBehaviour
{
    public ARRaycastManager arRaycastManager;
    public GameObject objectPrefab1; // First prefab
    public GameObject objectPrefab2; // Second prefab

    private GameObject currentPrefab; // Selected prefab to spawn
    private GameObject currentObject; // Reference to the currently moving object
    private List<GameObject> spawnedObjects = new List<GameObject>(); // List to store placed objects
    private List<ARRaycastHit> hitResults = new List<ARRaycastHit>();

    void Start()
    {
        currentPrefab = objectPrefab1; // Set default prefab
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Prevent spawning if touch is over UI
            if (IsTouchOverUI()) return;

            if (arRaycastManager.Raycast(touch.position, hitResults, TrackableType.Planes))
            {
                Pose hitPose = hitResults[0].pose;

                if (touch.phase == TouchPhase.Began)
                {
                    // Instantiate new object only if no object is currently being moved
                    if (currentObject == null && currentPrefab != null)
                    {
                        currentObject = Instantiate(currentPrefab, hitPose.position, hitPose.rotation);
                        spawnedObjects.Add(currentObject);
                    }
                }
                else if (touch.phase == TouchPhase.Moved && currentObject != null)
                {
                    // Move the object with the touch
                    currentObject.transform.position = hitPose.position;
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    // Fix the object in place and allow a new one to be placed next time
                    currentObject = null;
                }
            }
        }
    }

    private bool IsTouchOverUI()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current)
        {
            position = Input.GetTouch(0).position
        };

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        return results.Count > 0;
    }

    // Function to select the first object prefab
    public void SelectObject1()
    {
        currentPrefab = objectPrefab1;
        Debug.Log("Prefab 1 selected: " + objectPrefab1.name);
    }

    // Function to select the second object prefab
    public void SelectObject2()
    {
        currentPrefab = objectPrefab2;
        Debug.Log("Prefab 2 selected: " + objectPrefab2.name);
    }
}
*/







using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.EventSystems;

public class ARTapToPlaceObject : MonoBehaviour
{
    public ARRaycastManager arRaycastManager;
    public ARCameraManager arCameraManager; // Added for light estimation
    public GameObject objectPrefab1;
    public GameObject objectPrefab2;

    private GameObject currentPrefab;
    private GameObject currentObject;
    private List<GameObject> spawnedObjects = new List<GameObject>();
    private List<ARRaycastHit> hitResults = new List<ARRaycastHit>();

    // Light estimation data
    private float currentLightIntensity = 1.0f;

    void Start()
    {
        currentPrefab = objectPrefab1;
        arCameraManager.frameReceived += OnCameraFrameReceived; // Subscribe to light estimation
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (IsTouchOverUI()) return;

            if (arRaycastManager.Raycast(touch.position, hitResults, TrackableType.Planes))
            {
                Pose hitPose = hitResults[0].pose;

                if (touch.phase == TouchPhase.Began)
                {
                    if (currentObject == null && currentPrefab != null)
                    {
                        currentObject = Instantiate(currentPrefab, hitPose.position, hitPose.rotation);
                        spawnedObjects.Add(currentObject);
                    }
                }
                else if (touch.phase == TouchPhase.Moved && currentObject != null)
                {
                    currentObject.transform.position = hitPose.position;
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    currentObject = null;
                }
            }
        }
    }

    // Light Estimation for Dynamic Shadows
    private void OnCameraFrameReceived(ARCameraFrameEventArgs args)
    {
        if (args.lightEstimation.averageBrightness.HasValue)
        {
            currentLightIntensity = args.lightEstimation.averageBrightness.Value;
        }

        UpdateShadows();
    }

    // Update shadow intensity based on environmental light
    private void UpdateShadows()
    {
        foreach (var obj in spawnedObjects)
        {
            Renderer objRenderer = obj.GetComponent<Renderer>();
            if (objRenderer != null)
            {
                // Assuming the shadow intensity is controlled via "_ShadowStrength" property
                objRenderer.material.SetFloat("_ShadowStrength", Mathf.Clamp01(currentLightIntensity));
            }
        }
    }

    private bool IsTouchOverUI()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current)
        {
            position = Input.GetTouch(0).position
        };

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        return results.Count > 0;
    }

    public void SelectObject1()
    {
        currentPrefab = objectPrefab1;
        Debug.Log("Prefab 1 selected: " + objectPrefab1.name);
    }

    public void SelectObject2()
    {
        currentPrefab = objectPrefab2;
        Debug.Log("Prefab 2 selected: " + objectPrefab2.name);
    }
}