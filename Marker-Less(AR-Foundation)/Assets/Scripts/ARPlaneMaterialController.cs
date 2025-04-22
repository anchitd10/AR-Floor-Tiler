// Original
/*
using UnityEngine;

public class ARPlaneMaterialController : MonoBehaviour
{
    public Material[] materials; // Array of materials (Assign 8 materials in Inspector)
    private MeshRenderer meshRenderer;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        // Ensure MeshRenderer and materials are assigned
        if (meshRenderer == null || materials.Length < 8)
        {
            Debug.LogError("MeshRenderer is missing or not enough materials assigned!");
            return;
        }

        // Set default material (optional)
        meshRenderer.material = materials[0];
    }

    // Functions for each button to set a specific material
    public void SetMaterial1() { SetMaterial(0); }
    public void SetMaterial2() { SetMaterial(1); }
    public void SetMaterial3() { SetMaterial(2); }
    public void SetMaterial4() { SetMaterial(3); }
    public void SetMaterial5() { SetMaterial(4); }
    public void SetMaterial6() { SetMaterial(5); }
    public void SetMaterial7() { SetMaterial(6); }
    public void SetMaterial8() { SetMaterial(7); }

    // Private function to set the material
    private void SetMaterial(int index)
    {
        if (index >= 0 && index < materials.Length)
        {
            meshRenderer.material = materials[index];
            Debug.Log("Material switched to: " + materials[index].name);
        }
        else
        {
            Debug.LogError("Invalid material index!");
        }
    }
}
*/

using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARPlaneMaterialController : MonoBehaviour
{
    public Material[] materials; // Assign 8 materials in Inspector
    private MeshRenderer meshRenderer;
    private ARPlane arPlane;  // Reference to AR Plane component

    void Start()
    {
        arPlane = GetComponent<ARPlane>();  // Get AR Plane component

        // Ensure AR Plane exists
        if (arPlane == null)
        {
            Debug.LogError("ARPlane component not found!");
            return;
        }

        // Find the MeshRenderer (sometimes it's on a child object)
        meshRenderer = GetComponentInChildren<MeshRenderer>();

        if (meshRenderer == null || materials.Length < 8)
        {
            Debug.LogError("MeshRenderer is missing or not enough materials assigned!");
            return;
        }

        // Set default material (optional)
        meshRenderer.material = materials[0];
    }

    // Public functions for UI buttons
    public void SetMaterial1() { SetMaterial(0); }
    public void SetMaterial2() { SetMaterial(1); }
    public void SetMaterial3() { SetMaterial(2); }
    public void SetMaterial4() { SetMaterial(3); }
    public void SetMaterial5() { SetMaterial(4); }
    public void SetMaterial6() { SetMaterial(5); }
    public void SetMaterial7() { SetMaterial(6); }
    public void SetMaterial8() { SetMaterial(7); }

    // Private function to change material
    private void SetMaterial(int index)
    {
        if (meshRenderer != null && index >= 0 && index < materials.Length)
        {
            meshRenderer.material = materials[index];
            Debug.Log("Material changed to: " + materials[index].name);
        }
        else
        {
            Debug.LogError("Invalid material index or MeshRenderer not found!");
        }
    }
}