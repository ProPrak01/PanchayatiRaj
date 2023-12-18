using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SVS;
using UnityEngine;

public class StructureManager : MonoBehaviour
{
    public GameObject Hospital;

    public StructurePrefabWeighted[] housePrefab, specialPrefab;
    public PlacementManager placementManager;


    private float[] houseWeights, specialWeights;



    private void Start()
    {
        houseWeights = housePrefab.Select(prefabStats => prefabStats.weight).ToArray();
        specialWeights = specialPrefab.Select(prefabStats => prefabStats.weight).ToArray();

    }

    public void PlaceHouse(Vector3Int position)
    {
        if (checkPositionBeforePlacement(position))
        {
            int randomIndex = GetRandomWeightedIndex(houseWeights);
            placementManager.PlaceObjectOnTheMap(position, housePrefab[randomIndex].prefab, CellType.Structure);
            AudioPlayer.instance.PlayPlacementSound();
        }
    }

    public void PlaceHospital(Vector3Int position)
    {
        if (checkPositionBeforePlacement(position))
        {
           // int randomIndex = GetRandomWeightedIndex(houseWeights);
            placementManager.PlaceObjectOnTheMap(position, Hospital, CellType.Hospital);
            AudioPlayer.instance.PlayPlacementSound();
        }
    }

    public void PlaceSpecial(Vector3Int position)
    {
        if (checkPositionBeforePlacement(position))
        {
            int randomIndex = GetRandomWeightedIndex(specialWeights);
            placementManager.PlaceObjectOnTheMap(position, specialPrefab[randomIndex].prefab, CellType.SpecialStructure);
             AudioPlayer.instance.PlayPlacementSound();
        }
    }
    private int GetRandomWeightedIndex(float[] Weights)
    {

        float sum = 0f;
        for(int i = 0;i< Weights.Length; i++)
        {
            sum += Weights[i];
        }
        float randomValue = UnityEngine.Random.Range(0, sum);
        float tempSum = 0;
        for(int i = 0; i< Weights.Length; i++)
        {
            // 0-> weight[0]  
            if(randomValue >= tempSum && randomValue < tempSum + Weights[i])
            {
                return i;
            }
            tempSum += Weights[i];
        }
        return 0;
    }

    private bool checkPositionBeforePlacement(Vector3Int position)
    {
        if(placementManager.CheckIfPositionInBound(position) == false)
        {
            Debug.Log("This position is outofbounds");
            return false;
        }
        if (placementManager.CheckIfPositionIsFree(position) == false)
        {
            Debug.Log("This position is already taken");
            return false;
        }
        if(placementManager.GetNeighboursOfTypeFor(position,CellType.Road).Count <= 0)
        {
            Debug.Log("Must be placed near a road");
            return false;
        }
        return true;

    }
}
[Serializable]

public struct StructurePrefabWeighted
{
    public GameObject prefab;
    [Range(0,1)]
    public float weight;



}