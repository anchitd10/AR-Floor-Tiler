using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITween : MonoBehaviour
{
    [SerializeField]
    GameObject Menu, Toggle, Add_Object, Floor_Tile, Restart,
        Object_1, Object_2,
        Floor_1, Floor_2, Floor_3, Floor_4, Floor_5, Floor_6, Floor_7, Floor_8;

    private bool floorsActive = false;
    private bool menuActive = false;
    private bool objectActive = false;

    void Start()
    {
        // LeanTween.scale(Menu, new Vector3(1.5f, 1.5f, 1.5f),2f).setDelay(.5f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(Menu, new Vector3(1f, 1f, 1f), 2f).setDelay(2f).setEase(LeanTweenType.easeOutElastic);
    }

    public void ToggleMenu()
    {
        if(menuActive == false)
        {
            menuActive = true;

            LeanTween.scale(Floor_1, new Vector3(0f, 0f, 0f), 0.5f).setDelay(0.1f).setOnComplete(Floor1).setEase(LeanTweenType.easeOutElastic);
            LeanTween.scale(Floor_2, new Vector3(0f, 0f, 0f), 0.5f).setDelay(0.1f).setOnComplete(Floor2).setEase(LeanTweenType.easeOutElastic);
            LeanTween.scale(Floor_3, new Vector3(0f, 0f, 0f), 0.5f).setDelay(0.1f).setOnComplete(Floor3).setEase(LeanTweenType.easeOutElastic);
            LeanTween.scale(Floor_4, new Vector3(0f, 0f, 0f), 0.5f).setDelay(0.1f).setOnComplete(Floor4).setEase(LeanTweenType.easeOutElastic);
            LeanTween.scale(Floor_5, new Vector3(0f, 0f, 0f), 0.5f).setDelay(0.1f).setOnComplete(Floor5).setEase(LeanTweenType.easeOutElastic);
            LeanTween.scale(Floor_6, new Vector3(0f, 0f, 0f), 0.5f).setDelay(0.1f).setOnComplete(Floor6).setEase(LeanTweenType.easeOutElastic);
            LeanTween.scale(Floor_7, new Vector3(0f, 0f, 0f), 0.5f).setDelay(0.1f).setOnComplete(Floor7).setEase(LeanTweenType.easeOutElastic);
            LeanTween.scale(Floor_8, new Vector3(0f, 0f, 0f), 0.5f).setDelay(0.1f).setOnComplete(Floor8).setEase(LeanTweenType.easeOutElastic);

            LeanTween.scale(Object_1, new Vector3(0f, 0f, 0f), 0.5f).setDelay(0.1f).setOnComplete(showObjectButton1).setEase(LeanTweenType.easeOutElastic);
            LeanTween.scale(Object_2, new Vector3(0f, 0f, 0f), 0.5f).setDelay(0.1f).setOnComplete(showObjectButton2).setEase(LeanTweenType.easeOutElastic);

            LeanTween.scale(Toggle, new Vector3(1f, 1f, 1f), 0.5f).setDelay(0.1f).setOnComplete(ShowToggle).setEase(LeanTweenType.easeOutElastic);
            LeanTween.scale(Floor_Tile, new Vector3(1f, 1f, 1f), 0.5f).setDelay(0.1f).setOnComplete(ShowFloorIcon).setEase(LeanTweenType.easeOutElastic);
            LeanTween.scale(Add_Object, new Vector3(1f, 1f, 1f), 0.5f).setDelay(0.1f).setOnComplete(ShowObject).setEase(LeanTweenType.easeOutElastic);
            LeanTween.scale(Restart, new Vector3(1f, 1f, 1f), 0.5f).setDelay(0.1f).setOnComplete(showRestart).setEase(LeanTweenType.easeOutElastic);
        }

        else if(menuActive == true)
        {
            menuActive = false;

            LeanTween.scale(Toggle, new Vector3(0f, 0f, 0f), 0.5f).setDelay(0.1f).setOnComplete(ShowToggle).setEase(LeanTweenType.easeOutElastic);
            LeanTween.scale(Add_Object, new Vector3(0f, 0f, 0f), 0.5f).setDelay(0.1f).setOnComplete(ShowObject).setEase(LeanTweenType.easeOutElastic);
            LeanTween.scale(Floor_Tile, new Vector3(0f, 0f, 0f), 0.5f).setDelay(0.1f).setOnComplete(ShowFloorIcon).setEase(LeanTweenType.easeOutElastic);
            LeanTween.scale(Restart, new Vector3(0f, 0f, 0f), 0.5f).setDelay(0.1f).setOnComplete(showRestart).setEase(LeanTweenType.easeOutElastic);
        }
    }

    public void ToggleFloors()
    {
        if(floorsActive == false)
        {
            floorsActive = true;
            menuActive = false;

            LeanTween.scale(Toggle, new Vector3(0f, 0f, 0f), 0.5f).setDelay(0.1f).setOnComplete(ShowToggle).setEase(LeanTweenType.easeOutElastic);
            LeanTween.scale(Add_Object, new Vector3(0f, 0f, 0f), 0.5f).setDelay(0.1f).setOnComplete(ShowObject).setEase(LeanTweenType.easeOutElastic);
            LeanTween.scale(Floor_Tile, new Vector3(0f, 0f, 0f), 0.5f).setDelay(0.1f).setOnComplete(ShowFloorIcon).setEase(LeanTweenType.easeOutElastic);
            LeanTween.scale(Restart, new Vector3(0f, 0f, 0f), 0.5f).setDelay(0.1f).setOnComplete(showRestart).setEase(LeanTweenType.easeOutElastic);

            LeanTween.scale(Floor_1, new Vector3(1f, 1f, 1f), 0.5f).setDelay(0.1f).setOnComplete(Floor1).setEase(LeanTweenType.easeOutElastic);
            LeanTween.scale(Floor_2, new Vector3(1f, 1f, 1f), 0.5f).setDelay(0.1f).setOnComplete(Floor2).setEase(LeanTweenType.easeOutElastic);
            LeanTween.scale(Floor_3, new Vector3(1f, 1f, 1f), 0.5f).setDelay(0.1f).setOnComplete(Floor3).setEase(LeanTweenType.easeOutElastic);
            LeanTween.scale(Floor_4, new Vector3(1f, 1f, 1f), 0.5f).setDelay(0.1f).setOnComplete(Floor4).setEase(LeanTweenType.easeOutElastic);
            LeanTween.scale(Floor_5, new Vector3(1f, 1f, 1f), 0.5f).setDelay(0.1f).setOnComplete(Floor5).setEase(LeanTweenType.easeOutElastic);
            LeanTween.scale(Floor_6, new Vector3(1f, 1f, 1f), 0.5f).setDelay(0.1f).setOnComplete(Floor6).setEase(LeanTweenType.easeOutElastic);
            LeanTween.scale(Floor_7, new Vector3(1f, 1f, 1f), 0.5f).setDelay(0.1f).setOnComplete(Floor7).setEase(LeanTweenType.easeOutElastic);
            LeanTween.scale(Floor_8, new Vector3(1f, 1f, 1f), 0.5f).setDelay(0.1f).setOnComplete(Floor8).setEase(LeanTweenType.easeOutElastic);
        }

        else if(floorsActive == true)
        {
            floorsActive = false;

            LeanTween.scale(Toggle, new Vector3(1f, 1f, 1f), 0.5f).setDelay(0.1f).setOnComplete(ShowToggle).setEase(LeanTweenType.easeOutElastic);
            LeanTween.scale(Add_Object, new Vector3(1f, 1f, 1f), 0.5f).setDelay(0.1f).setOnComplete(ShowObject).setEase(LeanTweenType.easeOutElastic);
            LeanTween.scale(Floor_Tile, new Vector3(1f, 1f, 1f), 0.5f).setDelay(0.1f).setOnComplete(ShowFloorIcon).setEase(LeanTweenType.easeOutElastic);
            LeanTween.scale(Restart, new Vector3(1f, 1f, 1f), 0.5f).setDelay(0.1f).setOnComplete(showRestart).setEase(LeanTweenType.easeOutElastic);

            LeanTween.scale(Floor_1, new Vector3(0f, 0f, 0f), 0.5f).setDelay(0.1f).setOnComplete(Floor1).setEase(LeanTweenType.easeOutElastic);
            LeanTween.scale(Floor_2, new Vector3(0f, 0f, 0f), 0.5f).setDelay(0.1f).setOnComplete(Floor2).setEase(LeanTweenType.easeOutElastic);
            LeanTween.scale(Floor_3, new Vector3(0f, 0f, 0f), 0.5f).setDelay(0.1f).setOnComplete(Floor3).setEase(LeanTweenType.easeOutElastic);
            LeanTween.scale(Floor_4, new Vector3(0f, 0f, 0f), 0.5f).setDelay(0.1f).setOnComplete(Floor4).setEase(LeanTweenType.easeOutElastic);
            LeanTween.scale(Floor_5, new Vector3(0f, 0f, 0f), 0.5f).setDelay(0.1f).setOnComplete(Floor5).setEase(LeanTweenType.easeOutElastic);
            LeanTween.scale(Floor_6, new Vector3(0f, 0f, 0f), 0.5f).setDelay(0.1f).setOnComplete(Floor6).setEase(LeanTweenType.easeOutElastic);
            LeanTween.scale(Floor_7, new Vector3(0f, 0f, 0f), 0.5f).setDelay(0.1f).setOnComplete(Floor7).setEase(LeanTweenType.easeOutElastic);
            LeanTween.scale(Floor_8, new Vector3(0f, 0f, 0f), 0.5f).setDelay(0.1f).setOnComplete(Floor8).setEase(LeanTweenType.easeOutElastic);
        }
    }

    public void ToggleObjects()
    {
        if(objectActive == false)
        {
            objectActive = true;
            menuActive = false;

            LeanTween.scale(Toggle, new Vector3(0f, 0f, 0f), 0.5f).setDelay(0.1f).setOnComplete(ShowToggle).setEase(LeanTweenType.easeOutElastic);
            LeanTween.scale(Add_Object, new Vector3(0f, 0f, 0f), 0.5f).setDelay(0.1f).setOnComplete(ShowObject).setEase(LeanTweenType.easeOutElastic);
            LeanTween.scale(Floor_Tile, new Vector3(0f, 0f, 0f), 0.5f).setDelay(0.1f).setOnComplete(ShowFloorIcon).setEase(LeanTweenType.easeOutElastic);
            LeanTween.scale(Restart, new Vector3(0f, 0f, 0f), 0.5f).setDelay(0.1f).setOnComplete(showRestart).setEase(LeanTweenType.easeOutElastic);

            LeanTween.scale(Object_1, new Vector3(1f, 1f, 1f), 0.5f).setDelay(0.1f).setOnComplete(showObjectButton1).setEase(LeanTweenType.easeOutElastic);
            LeanTween.scale(Object_2, new Vector3(1f, 1f, 1f), 0.5f).setDelay(0.1f).setOnComplete(showObjectButton2).setEase(LeanTweenType.easeOutElastic);
        }

        else if(objectActive == true)
        {
            objectActive = false;

            LeanTween.scale(Object_1, new Vector3(0f, 0f, 0f), 0.5f).setDelay(0.1f).setOnComplete(showObjectButton1).setEase(LeanTweenType.easeOutElastic);
            LeanTween.scale(Object_2, new Vector3(0f, 0f, 0f), 0.5f).setDelay(0.1f).setOnComplete(showObjectButton2).setEase(LeanTweenType.easeOutElastic);
        }
    }

    void ShowMenu()
    {
        LeanTween.scale(Toggle, new Vector3(1f, 1f, 1f), 0.5f).setDelay(0.1f).setOnComplete(ShowToggle).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(Floor_Tile, new Vector3(1f, 1f, 1f), 0.5f).setDelay(0.1f).setOnComplete(ShowFloorIcon).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(Add_Object, new Vector3(1f, 1f, 1f), 0.5f).setDelay(0.1f).setOnComplete(ShowObject).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(Restart, new Vector3(1f, 1f, 1f), 0.5f).setDelay(0.1f).setOnComplete(showRestart).setEase(LeanTweenType.easeOutElastic);
    }

    void HideMenu()
    {
        LeanTween.scale(Toggle, new Vector3(0f, 0f, 0f), 0.5f).setDelay(0.1f).setOnComplete(ShowToggle).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(Add_Object, new Vector3(0f, 0f, 0f), 0.5f).setDelay(0.1f).setOnComplete(ShowObject).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(Floor_Tile, new Vector3(0f, 0f, 0f), 0.5f).setDelay(0.1f).setOnComplete(ShowFloorIcon).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(Restart, new Vector3(0f, 0f, 0f), 0.5f).setDelay(0.1f).setOnComplete(showRestart).setEase(LeanTweenType.easeOutElastic);
    }

    // Menu Buttons
    void ShowToggle()
    {
        Toggle.SetActive(true);
    }

    public void HideToggle()
    {
        Toggle.SetActive(false);
    }

    void ToggleObject()
    {
        Add_Object.SetActive(false);
    }

    void showObjectButton1()
    {
        Object_1.SetActive(true);
    }

    void showObjectButton2()
    {
        Object_2.SetActive(true);
    }

    void hideObjectButton1()
    {
        Object_2.SetActive(false);
    }

    void hideObjectButton2()
    {
        Object_2.SetActive(false);
    }

    void HideObject()
    {
        Add_Object.SetActive(false);
    }

    public void HideFloorIcon()
    {
        Floor_Tile.SetActive(false);
    }

    void ShowFloorIcon()
    {
        Floor_Tile.SetActive(true);
    }

    void ShowObject()
    {
        Add_Object.SetActive(true);
    }

    void showRestart()
    {
        Restart.SetActive(true);
    }

    void hideRestart()
    {
        Restart.SetActive(false);
    }


    // Floor Tiles ---> 8 buttons
    void Floor1()
    {
        Floor_1.SetActive(true);
    }

    void Floor2()
    {
        Floor_2.SetActive(true);
    }

    void Floor3()
    {
        Floor_3.SetActive(true);
    }

    void Floor4()
    {
        Floor_4.SetActive(true);
    }

    void Floor5()
    {
        Floor_5.SetActive(true);
    }

    void Floor6()
    {
        Floor_6.SetActive(true);
    }

    void Floor7()
    {
        Floor_7.SetActive(true);
    }

    void Floor8()
    {
        Floor_8.SetActive(true);
    }

    void ToggleFloor1()
    {
        Floor_1.SetActive(false);
    }

    void ToggleFloor2()
    {
        Floor_2.SetActive(false);
    }

    void ToggleFloor3()
    {
        Floor_3.SetActive(false);
    }

    void ToggleFloor4()
    {
        Floor_4.SetActive(false);
    }

    void ToggleFloor5()
    {
        Floor_5.SetActive(false);
    }

    void ToggleFloor6()
    {
        Floor_6.SetActive(false);
    }

    void ToggleFloor7()
    {
        Floor_7.SetActive(false);
    }

    void ToggleFloor8()
    {
        Floor_8.SetActive(false);
    }
}
