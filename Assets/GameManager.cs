using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SVS;

public class GameManager : MonoBehaviour
{
    public CameraMovement cameraMovement;

    public InputManager inputManager;
    public RoadManager roadManager;


    private void Start()
    {
        inputManager.onMouseClick += HandleMouseClick;
    }

    public void HandleMouseClick(Vector3Int position)
    {
        Debug.Log(position);

        roadManager.PlaceRoad(position);

    }
    private void Update()
    {
        cameraMovement.MoveCamera(new Vector3(inputManager.CameraMovementVector.x, 0,
        inputManager.CameraMovementVector.y));
    }
}
