using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
public class UIcontroller : MonoBehaviour

{
    public Action OnRoadPlacement, OnHousePlacement, OnSpecialPlacement, OnHospitalPlacement;
    public Button placeRoadButton, placeHouseButton, placeSpecialButton, placeHospitalButton;
   

    public Color outlineColor;
    List<Button> buttonList;

    public GameObject BuildMenuUI;
    public GameObject LocationsMenuUI;


    private void Start()
    {
        BuildMenuUI.SetActive(false);
        LocationsMenuUI.SetActive(false);


        buttonList = new List<Button> { placeHouseButton, placeRoadButton, placeSpecialButton , placeHospitalButton};

        placeRoadButton.onClick.AddListener(() =>
        {
            ResetButtonColor();
            ModifyOutline(placeRoadButton);
            OnRoadPlacement?.Invoke();
        });


        placeHouseButton.onClick.AddListener(() =>
        {
            ResetButtonColor();
            ModifyOutline(placeHouseButton);
            OnHousePlacement?.Invoke();
        });

        placeSpecialButton.onClick.AddListener(() =>
        {
            ResetButtonColor();
            ModifyOutline(placeSpecialButton);
            OnSpecialPlacement?.Invoke();
        });

        placeHospitalButton.onClick.AddListener(() =>
        {
            ResetButtonColor();
            ModifyOutline(placeHospitalButton);
            OnHospitalPlacement?.Invoke();
        });
    }

    private void ModifyOutline(Button button)
    {
        var outline = button.GetComponent<Outline>();
        outline.effectColor = outlineColor;
        outline.enabled = true;
    }

    private void ResetButtonColor()
    {

        foreach (Button button in buttonList)
        {
            button.GetComponent<Outline>().enabled = false;
        }
    }
    public void CloseBuildMenuButton()
    {
        BuildMenuUI.SetActive(false);
    }
    public void OpenBuildMenu()
    {
        BuildMenuUI.SetActive(true);
    }
    public void CloseLocationsMenuButton()
    {
        BuildMenuUI.SetActive(false);
    }
    public void OpenLocationsMenu()
    {
        LocationsMenuUI.SetActive(true);
    }
}
