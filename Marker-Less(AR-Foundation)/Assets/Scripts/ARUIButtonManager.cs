// Original
/*
using UnityEngine;

public class ARUIButtonManager : MonoBehaviour
{
    public GameObject menuButton;        // The main menu button (Always visible)
    public GameObject[] mainButtons;     // Array for Add-Object, Toggle-Plane, Floor-Tiles
    public GameObject[] floorTileButtons; // Array for 8 floor tile buttons

    void Start()
    {
        // Ensure initial visibility state
        ShowMainButtons(true);
        ShowFloorTileButtons(false);
    }

    public void ToggleMenu()
    {
        // Toggle visibility of main buttons
        bool isActive = mainButtons[0].activeSelf;
        ShowMainButtons(!isActive);
    }

    public void ShowFloorTiles()
    {
        // Hide main buttons and show floor tile buttons
        ShowMainButtons(false);
        ShowFloorTileButtons(true);
    }

    public void BackToMainMenu()
    {
        // Hide floor tile buttons and show main buttons
        ShowFloorTileButtons(false);
        ShowMainButtons(true);
    }

    private void ShowMainButtons(bool state)
    {
        foreach (GameObject button in mainButtons)
        {
            button.SetActive(state);
        }
    }

    private void ShowFloorTileButtons(bool state)
    {
        foreach (GameObject button in floorTileButtons)
        {
            button.SetActive(state);
        }
    }
}
*/


using UnityEngine;

public class ARUIButtonManager : MonoBehaviour
{
    public GameObject menuButton;        // The main menu button (Always visible)
    public GameObject[] mainButtons;     // Array for Add-Object, Toggle-Plane, Floor-Tiles
    public GameObject[] floorTileButtons; // Array for 8 floor tile buttons

    private bool isMainButtonsVisible = true;
    private bool isFloorTilesActive = false;

    void Start()
    {
        // Ensure initial visibility state
        ShowMainButtons(true);
        ShowFloorTileButtons(false);
    }

    public void ToggleMenu()
    {
        if (isFloorTilesActive)
        {
            // If floor tile buttons are active, return to main menu
            ShowFloorTileButtons(false);
            ShowMainButtons(true);
            isFloorTilesActive = false;  // Reset floor tiles state
        }
        else
        {
            // Otherwise, toggle main buttons visibility
            isMainButtonsVisible = !isMainButtonsVisible;
            ShowMainButtons(isMainButtonsVisible);
        }
    }

    public void ShowFloorTiles()
    {
        // Hide main buttons and show floor tile buttons
        ShowMainButtons(false);
        ShowFloorTileButtons(true);
        isFloorTilesActive = true;  // Track if floor tiles are active
    }

    private void ShowMainButtons(bool state)
    {
        foreach (GameObject button in mainButtons)
        {
            button.SetActive(state);
        }
    }

    private void ShowFloorTileButtons(bool state)
    {
        foreach (GameObject button in floorTileButtons)
        {
            button.SetActive(state);
        }
    }
}
