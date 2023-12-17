using System;
using System.Collections;
using System.Collections.Generic;
using SVS;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    public PlacementManager placementManager;

    public List<Vector3Int> temporaryPlacementPosition = new List<Vector3Int>();
    public List<Vector3Int> roadPositiontoRecheck= new List<Vector3Int>();

    private Vector3Int startPosition;
    private bool placementMode = false;

    // public GameObject roadStraight;


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
        if (placementMode == false)
        {
            temporaryPlacementPosition.Clear();
            roadPositiontoRecheck.Clear();

            placementMode = true;
            startPosition = position;

            temporaryPlacementPosition.Add(position);
            placementManager.PlaceTemporaryStructure(position, roadFixer.deadEnd, CellType.Road);

        }
        else
        {
            placementManager.removeAllTemporaryStructures();
            temporaryPlacementPosition.Clear();

            foreach (var positionsToFix in roadPositiontoRecheck)
            {
                roadFixer.FixRoadAtPosition(placementManager, positionsToFix);
            }

            roadPositiontoRecheck.Clear();

            temporaryPlacementPosition = placementManager.getPathBetween(startPosition, position);

            foreach (var temporaryPosition in temporaryPlacementPosition)
            {
                if (placementManager.CheckIfPositionIsFree(temporaryPosition) == false)
                {
                    continue;
                }
                placementManager.PlaceTemporaryStructure(temporaryPosition, roadFixer.deadEnd, CellType.Road);
            }
        }
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
                if(roadPositiontoRecheck.Contains(roadposition) == false)
                {
                    roadPositiontoRecheck.Add(roadposition);
                }
                roadPositiontoRecheck.Add(roadposition);
            }
            
        }
        
        foreach (var positionToFix in roadPositiontoRecheck)
        {
            roadFixer.FixRoadAtPosition(placementManager, positionToFix);
        }
        
    }
    public void FinishPlacingRoad()
    {
        placementMode = false;
        placementManager.AddtemporaryStructuresToStructureDictionary();
        if(temporaryPlacementPosition.Count > 0)
        {
            AudioPlayer.instance.PlayPlacementSound();
        }
        temporaryPlacementPosition.Clear();
        startPosition = Vector3Int.zero;
    }
}
