using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;


public class UIcontroller : MonoBehaviour

{

    public CostManagement costmanagement;

    public Action OnRoadPlacement, OnHousePlacement, OnSpecialPlacement, OnHospitalPlacement, OnLakePlacement, OnWaterSupplyPlacement,OnSchoolPlacement,OnShopPlacement,OnPanchayatPlacement,OnBankPlacement, OnAanganWadiPlacement, OnPoliceStationPlacement, OnFireStationPlacement, OnMeditationHallPlacement, OnMarketHallPlacement, OnHouse1Placement, OnHouse2Placement;
    public Button placeRoadButton, placeHouseButton, placeSpecialButton, placeHospitalButton, placeLakeButton,placeWaterSupplyButton,placeSchoolButton,placeShopButton,placePanchayatButton, placeBankButton, placeAanganWadiButton, placePoliceStationButton, placeFireStationButton, placeMeditationButton, placeMarketButton, placeHouse1Button, placeHouse2Button;
   

    public Color outlineColor;
    List<Button> buttonList;

    public GameObject BuildMenuUI;
    public GameObject LocationsMenuUI;


    private void Start()
    {
        BuildMenuUI.SetActive(false);
        LocationsMenuUI.SetActive(false);


        buttonList = new List<Button> { placeHouseButton, placeRoadButton, placeSpecialButton , placeHospitalButton, placeLakeButton, placeWaterSupplyButton, placeSchoolButton, placeShopButton, placePanchayatButton, placeBankButton , placeFireStationButton, placeMeditationButton ,placeMarketButton, placePoliceStationButton, placeHouse1Button, placeHouse2Button };

        placeHouse2Button.onClick.AddListener(() =>
        {
            //   ResetButtonColor();
            costmanagement.DecreaseCost(1000000);
            ModifyOutline(placeHouse2Button);

            OnHouse2Placement?.Invoke();
        });

        placeHouse1Button.onClick.AddListener(() =>
        {
            //   ResetButtonColor();
            costmanagement.DecreaseCost(1000000);

            ModifyOutline(placeHouse1Button);
            OnHouse1Placement?.Invoke();
        });

       


        placeMarketButton.onClick.AddListener(() =>
        {
            //   ResetButtonColor();
            costmanagement.DecreaseCost(5000000);

            ModifyOutline(placeMarketButton);
            OnMarketHallPlacement?.Invoke();
        });



        placePoliceStationButton.onClick.AddListener(() =>
        {
            //   ResetButtonColor();
            costmanagement.DecreaseCost(2000000);


            ModifyOutline(placePoliceStationButton);
            OnPoliceStationPlacement?.Invoke();
        });

        placeMeditationButton.onClick.AddListener(() =>
        {
            costmanagement.DecreaseCost(20000000);


            //   ResetButtonColor();
            ModifyOutline(placeMeditationButton);
            OnMeditationHallPlacement?.Invoke();
        });

        placeFireStationButton.onClick.AddListener(() =>
        {
            costmanagement.DecreaseCost(10000000);


            //   ResetButtonColor();
            ModifyOutline(placeFireStationButton);
            OnFireStationPlacement?.Invoke();
        });

        placeRoadButton.onClick.AddListener(() =>
        {


            costmanagement.DecreaseCost(10000);

            //   ResetButtonColor();
            ModifyOutline(placeRoadButton);
            OnRoadPlacement?.Invoke();
        });


        placeHouseButton.onClick.AddListener(() =>
        {
         //   ResetButtonColor();
            ModifyOutline(placeHouseButton);
            OnHousePlacement?.Invoke();
        });

        placeSpecialButton.onClick.AddListener(() =>
        {
          //  ResetButtonColor();
            ModifyOutline(placeSpecialButton);
            OnSpecialPlacement?.Invoke();
        });

        placeHospitalButton.onClick.AddListener(() =>
        {
            costmanagement.DecreaseCost(10000000);

            //   ResetButtonColor();
            // ModifyOutline(placeHospitalButton);
            OnHospitalPlacement?.Invoke();
        });
        placeLakeButton.onClick.AddListener(() =>
        {
            costmanagement.DecreaseCost(100000);

            //  ResetButtonColor();
            //  ModifyOutline(placeLakeButton);
            OnLakePlacement?.Invoke();
        });
        placeWaterSupplyButton.onClick.AddListener(() =>
        {
            costmanagement.DecreaseCost(1000000);

            // ResetButtonColor();
            //  ModifyOutline(placeHospitalButton);
            OnWaterSupplyPlacement?.Invoke();
        });
        placeSchoolButton.onClick.AddListener(() =>
        {
            costmanagement.DecreaseCost(10000000);

            //  ResetButtonColor();
            // ModifyOutline(placeSchoolButton);
            OnSchoolPlacement?.Invoke();
        });
        placeShopButton.onClick.AddListener(() =>
        {
            costmanagement.DecreaseCost(100000);

            //  ResetButtonColor();
            //  ModifyOutline(placeShopButton);
            OnShopPlacement?.Invoke();
        });
        placePanchayatButton.onClick.AddListener(() =>
        {
            costmanagement.DecreaseCost(1000000);

            // ResetButtonColor();
            // ModifyOutline(placePanchayatButton);
            OnPanchayatPlacement?.Invoke();
        });
        placeBankButton.onClick.AddListener(() =>
        {
            costmanagement.DecreaseCost(1000000);

            // ResetButtonColor();
            //  ModifyOutline(placeBankButton);
            OnBankPlacement?.Invoke();
        });
        placeAanganWadiButton.onClick.AddListener(() =>
        {
            costmanagement.DecreaseCost(100000);

            //  ResetButtonColor();
            //  ModifyOutline(placeAanganWadiButton);
            OnAanganWadiPlacement?.Invoke();
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
