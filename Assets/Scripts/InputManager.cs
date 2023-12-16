using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Action<Vector3Int> onMouseClick, OnMouseHold;
    public Action OnMouseUp;
    private Vector2 cameraMovementVector;

    [SerializeField]
    Camera mainCamera;

    public LayerMask groundMask;


    public Vector2 CameraMovementVector
    {
        get { return cameraMovementVector;  }

    }
    private void Update()
    {
        CheckClickDownEvent();
        CheckClickUpEvent();
        CheckClickHoldEvent();
        CheckArrowInput();
    }

    private Vector3Int? RaycastGround()
    {
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundMask))
        {
            Vector3Int positionInt = Vector3Int.RoundToInt(hit.point);
            return positionInt;
        }
        return null;
    }

    private void CheckClickDownEvent()
    {
        throw new NotImplementedException();
    }

    private void CheckClickUpEvent()
    {
        throw new NotImplementedException();
    }
    private void CheckClickHoldEvent()
    {
        throw new NotImplementedException();
    }
    private void CheckArrowInput()
    {
        throw new NotImplementedException();
    }
}
