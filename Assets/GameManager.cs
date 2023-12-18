using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SVS;
using System;

public class GameManager : MonoBehaviour
{
    public CameraMovement cameraMovement;

    public InputManager inputManager;
    public RoadManager roadManager;

    public UIcontroller uicontroller;

    public StructureManager structureManager;
    private void Start()
    {
        uicontroller.OnRoadPlacement += RoadPlacementHandler;
        uicontroller.OnHousePlacement += HousePlacementHandler;
        uicontroller.OnSpecialPlacement += SpecialPlacementHandler;
        uicontroller.OnHospitalPlacement += HospitalPlacementHandler;
        uicontroller.OnLakePlacement += LakePlacementHandler;
        uicontroller.OnWaterSupplyPlacement += WaterSupplyPlacementHandler;
        uicontroller.OnSchoolPlacement += SchoolPlacementHandler;
        uicontroller.OnShopPlacement += ShopPlacementHandler;
        uicontroller.OnPanchayatPlacement += PanchayatPlacementHandler;
        uicontroller.OnHospitalPlacement += HospitalPlacementHandler;
        uicontroller.OnBankPlacement += BankPlacementHandler;
        uicontroller.OnAanganWadiPlacement += AanganWadiPlacementHandler;


    }

    private void AanganWadiPlacementHandler()
    {
        ClearInputActions();
        inputManager.onMouseClick += structureManager.PlaceAanganWadi;
    }

    private void BankPlacementHandler()
    {
        ClearInputActions();
        inputManager.onMouseClick += structureManager.PlaceBank;
    }

    private void PanchayatPlacementHandler()
    {
        ClearInputActions();
        inputManager.onMouseClick += structureManager.PlacePanchayat;
    }

    private void ShopPlacementHandler()
    {
        ClearInputActions();
        inputManager.onMouseClick += structureManager.PlaceShop;
    }

    private void SchoolPlacementHandler()
    {
        ClearInputActions();
        inputManager.onMouseClick += structureManager.PlaceSchool;
    }

    private void WaterSupplyPlacementHandler()
    {
        ClearInputActions();
        inputManager.onMouseClick += structureManager.PlaceWaterSupply;
    }

    private void LakePlacementHandler()
    {
        ClearInputActions();
        inputManager.onMouseClick += structureManager.PlaceLake;
    }

    private void HospitalPlacementHandler()
    {
        ClearInputActions();
        inputManager.onMouseClick += structureManager.PlaceHospital;
    }
    private void SpecialPlacementHandler()
    {
        ClearInputActions();
        inputManager.onMouseClick += structureManager.PlaceSpecial;
    }

    private void HousePlacementHandler()
    {
        ClearInputActions();
        inputManager.onMouseClick += structureManager.PlaceHouse;
    }

    private void RoadPlacementHandler()
    {
        ClearInputActions();

        inputManager.onMouseClick += roadManager.PlaceRoad;
        inputManager.OnMouseHold += roadManager.PlaceRoad;
        inputManager.OnMouseUp += roadManager.FinishPlacingRoad;
        // throw new NotImplementedException();
    }

    private void ClearInputActions()
    {
        inputManager.onMouseClick = null;
        inputManager.OnMouseHold = null;
        inputManager.OnMouseUp  = null;
    }

    /**
public void HandleMouseClick(Vector3Int position)
{
   Debug.Log(position);

   roadManager.PlaceRoad(position);

}
**/
    private void Update()
    {
        cameraMovement.MoveCamera(new Vector3(inputManager.CameraMovementVector.x, 0,
        inputManager.CameraMovementVector.y));
    }
}
