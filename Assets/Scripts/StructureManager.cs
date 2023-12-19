using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SVS;
using UnityEngine;

public class StructureManager : MonoBehaviour
{

    public CostManagement costmanagement;
    public LaborManager laborManager;



    public GameObject Hospital;
    public GameObject Lake;
    public GameObject WaterSupply;
    public GameObject School;
    public GameObject Shop;
    public GameObject PostOffice;
    public GameObject Panchayat;
    public GameObject Bank;
    public GameObject PoliceStation;
    public GameObject FireStation;
    public GameObject MeditationHall;
    public GameObject Market;
    public GameObject AananWadi;
    public GameObject Home1;
    public GameObject Home2;


    public StructurePrefabWeighted[] housePrefab, specialPrefab;
    public PlacementManager placementManager;


    private float[] houseWeights, specialWeights;



    private void Start()
    {
        houseWeights = housePrefab.Select(prefabStats => prefabStats.weight).ToArray();
        specialWeights = specialPrefab.Select(prefabStats => prefabStats.weight).ToArray();

    }





    internal void PlaceHouse1(Vector3Int position)
    {
        if (!costmanagement.CanAfford(1000000))
        {
            Debug.Log("Insufficient funds!");


            return;
        }
        if (checkPositionBeforePlacement(position))
        {
            laborManager.AssignLaborForStructure(1,3);
            // int randomIndex = GetRandomWeightedIndex(houseWeights);
            placementManager.PlaceObjectOnTheMap(position, Home1, CellType.House1);
            AudioPlayer.instance.PlayPlacementSound();
            costmanagement.DecreaseCost(1000000);
        }
    }

    internal void PlaceHouse2(Vector3Int position)
    {
        if (!costmanagement.CanAfford(1000000))
        {
            Debug.Log("Insufficient funds!");


            return;
        }
        if (checkPositionBeforePlacement(position))
        {
            laborManager.AssignLaborForStructure(1, 3);

            // int randomIndex = GetRandomWeightedIndex(houseWeights);
            placementManager.PlaceObjectOnTheMap(position, Home2, CellType.House2);
            AudioPlayer.instance.PlayPlacementSound();
            costmanagement.DecreaseCost(1000000);
        }
    }






    internal void PlaceMarket(Vector3Int position)
    {
        if (!costmanagement.CanAfford(5000000))
        {
            Debug.Log("Insufficient funds!");


            return;
        }
        if (checkPositionBeforePlacement(position))
        {
            laborManager.AssignLaborForStructure(1, 3);

            // int randomIndex = GetRandomWeightedIndex(houseWeights);
            placementManager.PlaceObjectOnTheMap(position, Market, CellType.Market);
            AudioPlayer.instance.PlayPlacementSound();
            costmanagement.DecreaseCost(5000000);
        }
    }

    internal void PlaceMeditationHall(Vector3Int position)
    {
        if (!costmanagement.CanAfford(20000000))
        {
            Debug.Log("Insufficient funds!");


            return;
        }
        if (checkPositionBeforePlacement(position))
        {
            laborManager.AssignLaborForStructure(1, 3);

            // int randomIndex = GetRandomWeightedIndex(houseWeights);
            placementManager.PlaceObjectOnTheMap(position, MeditationHall, CellType.MeditationHall);
            AudioPlayer.instance.PlayPlacementSound();
            costmanagement.DecreaseCost(20000000);
        }
    }

    internal void PlaceFireStation(Vector3Int position)
    {
        if (!costmanagement.CanAfford(10000000))
        {
            Debug.Log("Insufficient funds!");


            return;
        }
        if (checkPositionBeforePlacement(position))
        {
            laborManager.AssignLaborForStructure(1, 3);

            // int randomIndex = GetRandomWeightedIndex(houseWeights);
            placementManager.PlaceObjectOnTheMap(position, FireStation, CellType.FireStation);
            AudioPlayer.instance.PlayPlacementSound();
            costmanagement.DecreaseCost(10000000);
        }
    }

    internal void PlacePoliceStation(Vector3Int position)
    {
        if (!costmanagement.CanAfford(2000000))
        {
            Debug.Log("Insufficient funds!");


            return;
        }
        if (checkPositionBeforePlacement(position))
        {
            laborManager.AssignLaborForStructure(1, 3);

            // int randomIndex = GetRandomWeightedIndex(houseWeights);
            placementManager.PlaceObjectOnTheMap(position, PoliceStation, CellType.PoliceStation);
            AudioPlayer.instance.PlayPlacementSound();
            costmanagement.DecreaseCost(2000000);
        }
    }



    internal void PlaceAanganWadi(Vector3Int position)
    {
        if (!costmanagement.CanAfford(100000))
        {
            Debug.Log("Insufficient funds!");


            return;
        }
        if (checkPositionBeforePlacement(position))
        {
            laborManager.AssignLaborForStructure(1, 3);

            // int randomIndex = GetRandomWeightedIndex(houseWeights);
            placementManager.PlaceObjectOnTheMap(position, AananWadi, CellType.AanganWadi);
            AudioPlayer.instance.PlayPlacementSound();
            costmanagement.DecreaseCost(100000);
        }
    }
    internal void PlaceBank(Vector3Int position)
    {
        if (!costmanagement.CanAfford(100000))
        {
            Debug.Log("Insufficient funds!");


            return;
        }
        if (checkPositionBeforePlacement(position))
        {
            laborManager.AssignLaborForStructure(1, 3);

            // int randomIndex = GetRandomWeightedIndex(houseWeights);
            placementManager.PlaceObjectOnTheMap(position, Bank, CellType.Bank);
            AudioPlayer.instance.PlayPlacementSound();
            costmanagement.DecreaseCost(1000000);
        }
    }

    internal void PlacePanchayat(Vector3Int position)
    {
        if (!costmanagement.CanAfford(1000000))
        {
            Debug.Log("Insufficient funds!");


            return;
        }

        if (checkPositionBeforePlacement(position))
        {
            laborManager.AssignLaborForStructure(1, 3);

            // int randomIndex = GetRandomWeightedIndex(houseWeights);
            placementManager.PlaceObjectOnTheMap(position, Panchayat, CellType.Panchayat);
            AudioPlayer.instance.PlayPlacementSound();
            costmanagement.DecreaseCost(1000000);
        }
    }

    internal void PlaceShop(Vector3Int position)
    {
        if (!costmanagement.CanAfford(100000))
        {
            Debug.Log("Insufficient funds!");


            return;
        }

        if (checkPositionBeforePlacement(position))
        {
            laborManager.AssignLaborForStructure(1, 3);

            // int randomIndex = GetRandomWeightedIndex(houseWeights);
            placementManager.PlaceObjectOnTheMap(position, Shop, CellType.Shop);
            AudioPlayer.instance.PlayPlacementSound();
            costmanagement.DecreaseCost(100000);
        }
    }

    internal void PlaceSchool(Vector3Int position)
    {
        if (!costmanagement.CanAfford(10000000))
        {
            Debug.Log("Insufficient funds!");


            return;
        }

        if (checkPositionBeforePlacement(position))
        {
            laborManager.AssignLaborForStructure(1, 3);

            // int randomIndex = GetRandomWeightedIndex(houseWeights);
            placementManager.PlaceObjectOnTheMap(position, School, CellType.School);
            AudioPlayer.instance.PlayPlacementSound();
            costmanagement.DecreaseCost(10000000);
        }
    }

    internal void PlaceWaterSupply(Vector3Int position)
    {
        if (!costmanagement.CanAfford(100000))
        {
            Debug.Log("Insufficient funds!");


            return;
        }

        if (checkPositionBeforePlacement(position))
        {
            laborManager.AssignLaborForStructure(1, 3);

            // int randomIndex = GetRandomWeightedIndex(houseWeights);
            placementManager.PlaceObjectOnTheMap(position, WaterSupply, CellType.WaterSupply);
            AudioPlayer.instance.PlayPlacementSound();
            costmanagement.DecreaseCost(1000000);
        }
    }

    internal void PlaceLake(Vector3Int position)
    {
        if (!costmanagement.CanAfford(1000000))
        {
            Debug.Log("Insufficient funds!");


            return;
        }
        if (checkPositionBeforePlacement(position))
        {
            laborManager.AssignLaborForStructure(1, 3);

            // int randomIndex = GetRandomWeightedIndex(houseWeights);
            placementManager.PlaceObjectOnTheMap(position, Lake, CellType.Lake);
            AudioPlayer.instance.PlayPlacementSound();
            costmanagement.DecreaseCost(1000000);

        }
    }
    public void PlaceHouse(Vector3Int position)
    {
        if (!costmanagement.CanAfford(1000000))
        {
            Debug.Log("Insufficient funds!");


            return;
        }
        if (checkPositionBeforePlacement(position) )
        {

            int randomIndex = GetRandomWeightedIndex(houseWeights);
            placementManager.PlaceObjectOnTheMap(position, housePrefab[randomIndex].prefab, CellType.Structure);
            AudioPlayer.instance.PlayPlacementSound();
            costmanagement.DecreaseCost(1000000);

        }
    }

    public void PlaceHospital(Vector3Int position)
    {
        if (checkPositionBeforePlacement(position))
        {
            laborManager.AssignLaborForStructure(1, 3);

            // int randomIndex = GetRandomWeightedIndex(houseWeights);
            placementManager.PlaceObjectOnTheMap(position, Hospital, CellType.Hospital);
            AudioPlayer.instance.PlayPlacementSound();
            costmanagement.DecreaseCost(1000000);
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