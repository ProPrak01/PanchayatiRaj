using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    public PlacementManager placementManager;

    public List<Vector3Int> temporaryPlacementPosition = new List<Vector3Int>();
    public List<Vector3Int> roadPositiontoRecheck= new List<Vector3Int>();


    public GameObject roadStraight;


    public RoadFixer roadFixer;

    public void PlaceRoad(Vector3Int position)
    {

        if (placementManager.CheckIfPositionInBound(position) == false)
        {
            return;
        }
        if (placementManager.CheckIfPositionIsFree(position) == false)
        {
            return;
        }

        temporaryPlacementPosition.Clear();
        temporaryPlacementPosition.Add(position);
        placementManager.PlaceTemporaryStructure(position, roadStraight, CellType.Road);
        FixRoadPrefab();
    }

    private void FixRoadPrefab()
    {

        foreach (var temporaryPosition in temporaryPlacementPosition)
        {
            roadFixer.FixRoadAtPosition(placementManager, temporaryPosition);
            var neighbours = placementManager.GetNeighboursOfTypeFor(temporaryPosition,CellType.Road);
            foreach (var roadposition in neighbours)
            {
                roadPositiontoRecheck.Add(roadposition);
            }
        }
        foreach (var positionToFix in roadPositiontoRecheck)
        {
            roadFixer.FixRoadAtPosition(placementManager, positionToFix);
        }
    }
}
