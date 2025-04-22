// original
/*
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using System.Collections.Generic;

public class ARPlaneMaterialManager : MonoBehaviour
{
    public ARPlaneManager arPlaneManager;
    private MeshRenderer planeRenderer;
    public Material[] materials; // Assign in Inspector

    void Start()
    {
        arPlaneManager.planesChanged += OnPlanesChanged;
    }

    private void OnPlanesChanged(ARPlanesChangedEventArgs args)
    {
        if (args.added.Count > 0)
        {
            // Get the first detected plane
            ARPlane firstPlane = args.added[0];
            planeRenderer = firstPlane.GetComponentInChildren<MeshRenderer>();

            if (planeRenderer == null)
            {
                Debug.LogError("No MeshRenderer found on the AR Plane!");
            }
            else
            {
                planeRenderer.material = materials[0];
            }
        }
    }

    public void SetMaterial(int index)
    {
        if (planeRenderer != null && index >= 0 && index < materials.Length)
        {
            planeRenderer.material = materials[index];
            Debug.Log("Material switched to: " + materials[index].name);
        }
        else
        {
            Debug.LogError("Material change failed! MeshRenderer or material index invalid.");
        }
    }

    public void SetMaterial1() { SetMaterial(0); }
    public void SetMaterial2() { SetMaterial(1); }
    public void SetMaterial3() { SetMaterial(2); }
    public void SetMaterial4() { SetMaterial(3); }
    public void SetMaterial5() { SetMaterial(4); }
    public void SetMaterial6() { SetMaterial(5); }
    public void SetMaterial7() { SetMaterial(6); }
    public void SetMaterial8() { SetMaterial(7); }
}
*/




// 2nd script
/*
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using System.Collections.Generic;

public class ARPlaneMaterialManager : MonoBehaviour
{
    public ARPlaneManager arPlaneManager;
    public Material initialMaterial; // Material for first render (Assign in Inspector)
    public Material[] materials; // Assign 8 different materials in Inspector

    private bool isInitialMaterialSet = false; // Flag to ensure initial material is applied

    void Start()
    {
        arPlaneManager.planesChanged += OnPlanesChanged;
    }

    private void OnPlanesChanged(ARPlanesChangedEventArgs args)
    {
        if (!isInitialMaterialSet && args.added.Count > 0)
        {
            foreach (ARPlane plane in args.added)
            {
                MeshRenderer renderer = plane.GetComponentInChildren<MeshRenderer>();

                if (renderer != null)
                {
                    renderer.material = initialMaterial;
                    Debug.Log("Initial material assigned: " + initialMaterial.name);
                }
                else
                {
                    Debug.LogError("No MeshRenderer found on the AR Plane!");
                }
            }

            isInitialMaterialSet = true; // Ensure this runs only once
        }
    }

    public void SetMaterial(int index)
    {
        foreach (ARPlane plane in arPlaneManager.trackables)
        {
            MeshRenderer renderer = plane.GetComponentInChildren<MeshRenderer>();

            if (renderer != null && index >= 0 && index < materials.Length)
            {
                renderer.material = materials[index];
                Debug.Log("Material switched to: " + materials[index].name);
            }
        }
    }

    // Button Functions
    public void SetMaterial1() { SetMaterial(0); }
    public void SetMaterial2() { SetMaterial(1); }
    public void SetMaterial3() { SetMaterial(2); }
    public void SetMaterial4() { SetMaterial(3); }
    public void SetMaterial5() { SetMaterial(4); }
    public void SetMaterial6() { SetMaterial(5); }
    public void SetMaterial7() { SetMaterial(6); }
    public void SetMaterial8() { SetMaterial(7); }
}
*/





// 3rd script
/*
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using TMPro;

public class ARPlaneMaterialManager : MonoBehaviour
{
    public ARPlaneManager arPlaneManager;
    public Material initialMaterial;
    public Material[] materials;
    public float[] materialPrices; // Price per square meter for each material

    public TextMeshProUGUI areaText;      // Displays total area of the detected plane
    public TextMeshProUGUI priceText;     // Displays price per 1 sq.m of selected material
    public TextMeshProUGUI costText;      // Displays total cost (area * price)

    private bool isInitialMaterialSet = false;

    void Start()
    {
        arPlaneManager.planesChanged += OnPlanesChanged;
    }

    private void OnPlanesChanged(ARPlanesChangedEventArgs args)
    {
        if (!isInitialMaterialSet && args.added.Count > 0)
        {
            foreach (ARPlane plane in args.added)
            {
                MeshRenderer renderer = plane.GetComponentInChildren<MeshRenderer>();

                if (renderer != null)
                {
                    renderer.material = initialMaterial;
                    Debug.Log("Initial material assigned: " + initialMaterial.name);
                }
                else
                {
                    Debug.LogError("No MeshRenderer found on the AR Plane!");
                }
            }

            isInitialMaterialSet = true;
        }
    }

    public void SetMaterial(int index)
    {
        if (index < 0 || index >= materials.Length || index >= materialPrices.Length)
        {
            Debug.LogError("Invalid material index.");
            return;
        }

        foreach (ARPlane plane in arPlaneManager.trackables)
        {
            MeshRenderer renderer = plane.GetComponentInChildren<MeshRenderer>();

            if (renderer != null)
            {
                renderer.material = materials[index];
                Debug.Log("Material switched to: " + materials[index].name);

                // Compute area and cost
                float area = CalculatePlaneArea(plane);
                float pricePerSqM = materialPrices[index];
                float totalCost = area * pricePerSqM;

                // Update UI Text
                if (areaText != null) areaText.text = $"Area: {area:F2} sq.m";
                if (priceText != null) priceText.text = $"Price: Rs{pricePerSqM:F2}";
                if (costText != null) costText.text = $"Cost: Rs{totalCost:F2}";
            }
        }
    }

    private float CalculatePlaneArea(ARPlane plane)
    {
        List<Vector2> boundary = new List<Vector2>(plane.boundary);
        if (boundary.Count < 3) return 0f;

        float area = 0f;
        int j = boundary.Count - 1;

        for (int i = 0; i < boundary.Count; i++)
        {
            area += (boundary[j].x + boundary[i].x) * (boundary[j].y - boundary[i].y);
            j = i;
        }

        return Mathf.Abs(area * 0.5f);
    }

    // Button Functions
    public void SetMaterial1() { SetMaterial(0); }
    public void SetMaterial2() { SetMaterial(1); }
    public void SetMaterial3() { SetMaterial(2); }
    public void SetMaterial4() { SetMaterial(3); }
    public void SetMaterial5() { SetMaterial(4); }
    public void SetMaterial6() { SetMaterial(5); }
    public void SetMaterial7() { SetMaterial(6); }
    public void SetMaterial8() { SetMaterial(7); }
}
*/




// 4th script
/*
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using TMPro;

public class ARPlaneMaterialManager : MonoBehaviour
{
    public ARPlaneManager arPlaneManager;
    public Material initialMaterial;
    public Material[] materials;
    public float[] materialPrices; // Price per square meter for each material

    public TextMeshProUGUI areaText;
    public TextMeshProUGUI priceText;
    public TextMeshProUGUI costText;

    private bool isInitialMaterialSet = false;
    private int currentMaterialIndex = 0; // Track the current material index

    void Start()
    {
        arPlaneManager.planesChanged += OnPlanesChanged;
    }

    private void OnPlanesChanged(ARPlanesChangedEventArgs args)
    {
        // Assign initial material once
        if (!isInitialMaterialSet && args.added.Count > 0)
        {
            foreach (ARPlane plane in args.added)
            {
                MeshRenderer renderer = plane.GetComponentInChildren<MeshRenderer>();

                if (renderer != null)
                {
                    renderer.material = initialMaterial;
                    Debug.Log("Initial material assigned: " + initialMaterial.name);
                }
                else
                {
                    Debug.LogError("No MeshRenderer found on the AR Plane!");
                }
            }

            isInitialMaterialSet = true;
        }

        // Update cost dynamically when planes are updated
        UpdateCost();
    }

    public void SetMaterial(int index)
    {
        if (index < 0 || index >= materials.Length || index >= materialPrices.Length)
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
                renderer.material = materials[index];
                Debug.Log("Material switched to: " + materials[index].name);
            }
        }

        // Update cost immediately after changing the material
        UpdateCost();
    }

    private void UpdateCost()
    {
        float totalArea = 0f;

        // Sum up the area of all tracked planes
        foreach (ARPlane plane in arPlaneManager.trackables)
        {
            totalArea += CalculatePlaneArea(plane);
        }

        // Get the price of the currently selected material
        float pricePerSqM = materialPrices[currentMaterialIndex];
        float totalCost = totalArea * pricePerSqM;

        // Update UI Text
        if (areaText != null) areaText.text = $"Area: {totalArea:F2} sq.m";
        if (priceText != null) priceText.text = $"Price: Rs{pricePerSqM:F2}";
        if (costText != null) costText.text = $"Cost: Rs{totalCost:F2}";
    }

    private float CalculatePlaneArea(ARPlane plane)
    {
        List<Vector2> boundary = new List<Vector2>(plane.boundary);
        if (boundary.Count < 3) return 0f;

        float area = 0f;
        int j = boundary.Count - 1;

        for (int i = 0; i < boundary.Count; i++)
        {
            area += (boundary[j].x + boundary[i].x) * (boundary[j].y - boundary[i].y);
            j = i;
        }

        return Mathf.Abs(area * 0.5f);
    }

    // Button Functions
    public void SetMaterial1() { SetMaterial(0); }
    public void SetMaterial2() { SetMaterial(1); }
    public void SetMaterial3() { SetMaterial(2); }
    public void SetMaterial4() { SetMaterial(3); }
    public void SetMaterial5() { SetMaterial(4); }
    public void SetMaterial6() { SetMaterial(5); }
    public void SetMaterial7() { SetMaterial(6); }
    public void SetMaterial8() { SetMaterial(7); }
}
*/



/*
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using TMPro;

public class ARPlaneMaterialManager : MonoBehaviour
{
    public ARPlaneManager arPlaneManager;
    public Material initialMaterial;
    public Material[] materials;
    public float[] materialPrices;

    public TextMeshProUGUI areaText;
    public TextMeshProUGUI priceText;
    public TextMeshProUGUI costText;

    private bool isInitialMaterialSet = false;
    private int currentMaterialIndex = 0;

    void Start()
    {
        arPlaneManager.planesChanged += OnPlanesChanged;
    }

    private void OnPlanesChanged(ARPlanesChangedEventArgs args)
    {
        if (!isInitialMaterialSet && args.added.Count > 0)
        {
            foreach (ARPlane plane in args.added)
            {
                MeshRenderer renderer = plane.GetComponentInChildren<MeshRenderer>();
                if (renderer != null)
                {
                    renderer.material = initialMaterial;
                    Debug.Log("Initial material assigned: " + initialMaterial.name);
                }
            }
            isInitialMaterialSet = true;
        }
        UpdateCost();
    }

    public void SetMaterial(int index)
    {
        if (index < 0 || index >= materials.Length || index >= materialPrices.Length)
        {
            Debug.LogError("Invalid material index.");
            return;
        }

        currentMaterialIndex = index;
        foreach (ARPlane plane in arPlaneManager.trackables)
        {
            MeshRenderer renderer = plane.GetComponentInChildren<MeshRenderer>();
            if (renderer != null)
            {
                renderer.material = materials[index];
                Debug.Log("Material switched to: " + materials[index].name);
            }
        }
        UpdateCost();
    }

    private void UpdateCost()
    {
        float totalArea = 0f;
        foreach (ARPlane plane in arPlaneManager.trackables)
        {
            totalArea += CalculatePlaneArea(plane);
        }

        float pricePerSqM = materialPrices[currentMaterialIndex];
        float totalCost = totalArea * pricePerSqM;

        if (areaText != null) areaText.text = $"Area: {totalArea:F2} sq.m";
        if (priceText != null) priceText.text = $"Price: Rs{pricePerSqM:F2}";
        if (costText != null) costText.text = $"Cost: Rs{totalCost:F2}";
    }

    private float CalculatePlaneArea(ARPlane plane)
    {
        List<Vector2> boundary = new List<Vector2>(plane.boundary);
        if (boundary.Count < 3) return 0f;

        float area = 0f;
        int j = boundary.Count - 1;
        for (int i = 0; i < boundary.Count; i++)
        {
            area += (boundary[j].x + boundary[i].x) * (boundary[j].y - boundary[i].y);
            j = i;
        }
        return Mathf.Abs(area * 0.5f);
    }

    public void ResetUI()
    {
        if (areaText != null) areaText.text = "Area: 0.00 sq.m";
        if (priceText != null) priceText.text = "Price: Rs0.00";
        if (costText != null) costText.text = "Cost: Rs0.00";
    }

    public void SetMaterial1() { SetMaterial(0); }
    public void SetMaterial2() { SetMaterial(1); }
    public void SetMaterial3() { SetMaterial(2); }
    public void SetMaterial4() { SetMaterial(3); }
    public void SetMaterial5() { SetMaterial(4); }
    public void SetMaterial6() { SetMaterial(5); }
    public void SetMaterial7() { SetMaterial(6); }
    public void SetMaterial8() { SetMaterial(7); }
}
*/




using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using TMPro;

public class ARPlaneMaterialManager : MonoBehaviour
{
    public ARPlaneManager arPlaneManager;
    public ARCameraManager arCameraManager; // AR Camera Manager for light estimation
    public Material initialMaterial;
    public Material[] materials;
    public float[] materialPrices;

    public TextMeshProUGUI areaText;
    public TextMeshProUGUI priceText;
    public TextMeshProUGUI costText;

    private bool isInitialMaterialSet = false;
    private int currentMaterialIndex = 0;
    private float lightIntensity = 1.0f; // Default brightness level

    void Start()
    {
        arPlaneManager.planesChanged += OnPlanesChanged;
        if (arCameraManager != null)
        {
            arCameraManager.frameReceived += OnCameraFrameReceived;
        }
    }

    private void OnCameraFrameReceived(ARCameraFrameEventArgs args)
    {
        if (args.lightEstimation.averageBrightness.HasValue)
        {
            lightIntensity = args.lightEstimation.averageBrightness.Value;
            UpdatePlaneBrightness();
        }
    }

    private void OnPlanesChanged(ARPlanesChangedEventArgs args)
    {
        if (!isInitialMaterialSet && args.added.Count > 0)
        {
            foreach (ARPlane plane in args.added)
            {
                MeshRenderer renderer = plane.GetComponentInChildren<MeshRenderer>();
                if (renderer != null)
                {
                    renderer.material = initialMaterial;
                    Debug.Log("Initial material assigned: " + initialMaterial.name);
                }
            }
            isInitialMaterialSet = true;
        }
        UpdateCost();
        UpdatePlaneBrightness();
    }

    public void SetMaterial(int index)
    {
        if (index < 0 || index >= materials.Length || index >= materialPrices.Length)
        {
            Debug.LogError("Invalid material index.");
            return;
        }

        currentMaterialIndex = index;
        foreach (ARPlane plane in arPlaneManager.trackables)
        {
            MeshRenderer renderer = plane.GetComponentInChildren<MeshRenderer>();
            if (renderer != null)
            {
                renderer.material = materials[index];
                Debug.Log("Material switched to: " + materials[index].name);
            }
        }
        UpdateCost();
        UpdatePlaneBrightness();
    }

    private void UpdatePlaneBrightness()
    {
        foreach (ARPlane plane in arPlaneManager.trackables)
        {
            MeshRenderer renderer = plane.GetComponentInChildren<MeshRenderer>();
            if (renderer != null)
            {
                Color color = renderer.material.color;
                color *= lightIntensity; // Adjust brightness based on lighting
                renderer.material.color = color;
            }
        }
    }

    private void UpdateCost()
    {
        float totalArea = 0f;
        foreach (ARPlane plane in arPlaneManager.trackables)
        {
            totalArea += CalculatePlaneArea(plane);
        }

        float pricePerSqM = materialPrices[currentMaterialIndex];
        float totalCost = totalArea * pricePerSqM;

        if (areaText != null) areaText.text = $"Area: {totalArea:F2} sq.m";
        if (priceText != null) priceText.text = $"Price: Rs{pricePerSqM:F2}";
        if (costText != null) costText.text = $"Cost: Rs{totalCost:F2}";
    }

    private float CalculatePlaneArea(ARPlane plane)
    {
        List<Vector2> boundary = new List<Vector2>(plane.boundary);
        if (boundary.Count < 3) return 0f;

        float area = 0f;
        int j = boundary.Count - 1;
        for (int i = 0; i < boundary.Count; i++)
        {
            area += (boundary[j].x + boundary[i].x) * (boundary[j].y - boundary[i].y);
            j = i;
        }
        return Mathf.Abs(area * 0.5f);
    }

    public void ResetUI()
    {
        if (areaText != null) areaText.text = "Area: 0.00 sq.m";
        if (priceText != null) priceText.text = "Price: Rs0.00";
        if (costText != null) costText.text = "Cost: Rs0.00";
    }

    public void SetMaterial1() { SetMaterial(0); }
    public void SetMaterial2() { SetMaterial(1); }
    public void SetMaterial3() { SetMaterial(2); }
    public void SetMaterial4() { SetMaterial(3); }
    public void SetMaterial5() { SetMaterial(4); }
    public void SetMaterial6() { SetMaterial(5); }
    public void SetMaterial7() { SetMaterial(6); }
    public void SetMaterial8() { SetMaterial(7); }
}
