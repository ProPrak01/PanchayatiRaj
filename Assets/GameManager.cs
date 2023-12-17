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
    private void Start()
    {
        uicontroller.OnRoadPlacement += RoadPlacementHandler;
        uicontroller.OnHousePlacement += HousePlacementHandler;
        uicontroller.OnSpecialPlacement += SpecialPlacementHandler;

    }

    private void SpecialPlacementHandler()
    {
        throw new NotImplementedException();
    }

    private void HousePlacementHandler()
    {
        throw new NotImplementedException();
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
