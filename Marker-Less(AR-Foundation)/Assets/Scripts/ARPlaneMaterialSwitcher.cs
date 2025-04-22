using UnityEngine;

public class ARPlaneMaterialSwitcher : MonoBehaviour
{
    public Material[] materials; // Array of materials
    private MeshRenderer meshRenderer;
    private int currentMaterialIndex = 0;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        // Ensure MeshRenderer and materials are assigned
        if (meshRenderer == null || materials.Length == 0)
        {
            Debug.LogError("MeshRenderer or materials array is missing!");
            return;
        }

        // Set the initial material
        meshRenderer.material = materials[currentMaterialIndex];
    }

    // Function to be assigned to UI Button
    public void SwitchMaterial()
    {
        if (materials.Length == 0) return;

        currentMaterialIndex = (currentMaterialIndex + 1) % materials.Length;
        meshRenderer.material = materials[currentMaterialIndex];

        Debug.Log("Material switched to: " + materials[currentMaterialIndex].name);
    }
}
