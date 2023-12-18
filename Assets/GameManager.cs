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
