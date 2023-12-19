using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;


public class UIcontroller : MonoBehaviour

{


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
            
           // ModifyOutline(placeHouse2Button);

            OnHouse2Placement?.Invoke();
        });

        placeHouse1Button.onClick.AddListener(() =>
        {
            //   ResetButtonColor();
          

           // ModifyOutline(placeHouse1Button);
            OnHouse1Placement?.Invoke();
        });

       


        placeMarketButton.onClick.AddListener(() =>
        {
            //   ResetButtonColor();
          

           // ModifyOutline(placeMarketButton);
            OnMarketHallPlacement?.Invoke();
        });



        placePoliceStationButton.onClick.AddListener(() =>
        {
            //   ResetButtonColor();
          


           // ModifyOutline(placePoliceStationButton);
            OnPoliceStationPlacement?.Invoke();
        });

        placeMeditationButton.onClick.AddListener(() =>
        {
         


            //   ResetButtonColor();
           // ModifyOutline(placeMeditationButton);
            OnMeditationHallPlacement?.Invoke();
        });

        placeFireStationButton.onClick.AddListener(() =>
        {
           


            //   ResetButtonColor();
           // ModifyOutline(placeFireStationButton);
            OnFireStationPlacement?.Invoke();
        });

        placeRoadButton.onClick.AddListener(() =>
        {

          //  costmanagement.DecreaseCost(10000);


            //   ResetButtonColor();
           // ModifyOutline(placeRoadButton);
            OnRoadPlacement?.Invoke();
        });


        placeHouseButton.onClick.AddListener(() =>
        {
         //   ResetButtonColor();
          //  ModifyOutline(placeHouseButton);
            OnHousePlacement?.Invoke();
        });

        placeSpecialButton.onClick.AddListener(() =>
        {
          //  ResetButtonColor();
          //  ModifyOutline(placeSpecialButton);
            OnSpecialPlacement?.Invoke();
        });

        placeHospitalButton.onClick.AddListener(() =>
        {
        

            //   ResetButtonColor();
            // ModifyOutline(placeHospitalButton);
            OnHospitalPlacement?.Invoke();
        });
        placeLakeButton.onClick.AddListener(() =>
        {
           

            //  ResetButtonColor();
            //  ModifyOutline(placeLakeButton);
            OnLakePlacement?.Invoke();
        });
        placeWaterSupplyButton.onClick.AddListener(() =>
        {
           

            // ResetButtonColor();
            //  ModifyOutline(placeHospitalButton);
            OnWaterSupplyPlacement?.Invoke();
        });
        placeSchoolButton.onClick.AddListener(() =>
        {
           

            //  ResetButtonColor();
            // ModifyOutline(placeSchoolButton);
            OnSchoolPlacement?.Invoke();
        });
        placeShopButton.onClick.AddListener(() =>
        {
         

            //  ResetButtonColor();
            //  ModifyOutline(placeShopButton);
            OnShopPlacement?.Invoke();
        });
        placePanchayatButton.onClick.AddListener(() =>
        {
          

            // ResetButtonColor();
            // ModifyOutline(placePanchayatButton);
            OnPanchayatPlacement?.Invoke();
        });
        placeBankButton.onClick.AddListener(() =>
        {
          

            // ResetButtonColor();
            //  ModifyOutline(placeBankButton);
            OnBankPlacement?.Invoke();
        });
        placeAanganWadiButton.onClick.AddListener(() =>
        {
           

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
        LocationsMenuUI.SetActive(false);
    }
    public void OpenLocationsMenu()
    {
        LocationsMenuUI.SetActive(true);
    }
}
