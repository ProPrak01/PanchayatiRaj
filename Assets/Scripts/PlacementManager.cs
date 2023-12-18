using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlacementManager : MonoBehaviour
{

    public int width, height;
    Grid placementGrid;
    public TextMeshProUGUI textOutputLocations;

    private Dictionary<Vector3Int, StructureModel> temporaryRoadobjects = new Dictionary<Vector3Int, StructureModel>();
    private Dictionary<Vector3Int, StructureModel> structureDictionary = new Dictionary<Vector3Int, StructureModel>();

    private void Start()
    {
        placementGrid = new Grid(width, height);
    }

    internal bool CheckIfPositionInBound(Vector3Int position)
    {
        if(position.x >= 0 && position.x < width && position.z >= 0 && position.z < height)
        {
            return true;
        }
        
        
            return false;
        
    }
    internal bool CheckIfPositionIsFree(Vector3Int position)
    {

        return CheckIfpositionIsOfType(position,CellType.Empty);
    }

    private bool CheckIfpositionIsOfType(Vector3Int position, CellType type)
    {
        return placementGrid[position.x,position.z] == type;
    }

    internal void PlaceTemporaryStructure(Vector3Int position, GameObject structurePrefab, CellType type)
    {

        placementGrid[position.x, position.z] = type;
        StructureModel structure = CreateANewStructureModel(position, structurePrefab, type);
        temporaryRoadobjects.Add(position, structure);
    }

    private StructureModel CreateANewStructureModel(Vector3Int position, GameObject structurePrefab, CellType type)
    {
        GameObject structure = new GameObject(type.ToString());
        structure.transform.SetParent(transform);
        structure.transform.localPosition = position;
        var structureModel = structure.AddComponent<StructureModel>();
        structureModel.CreateModel(structurePrefab);
        return structureModel;
    }
    public void ModifyStructureModel(Vector3Int position, GameObject newModel, Quaternion rotation) 
    {
        if (temporaryRoadobjects.ContainsKey(position))
        {
            temporaryRoadobjects[position].SwapModel(newModel, rotation);
        }
        else if (structureDictionary.ContainsKey(position))
        {
            structureDictionary[position].SwapModel(newModel, rotation);
        }
    }

    internal CellType[] GetNeighbourTypesFor(Vector3Int position)
    {
       return placementGrid.GetAllAdjacentCellTypes(position.x, position.z);
    }

    internal List<Vector3Int> GetNeighboursOfTypeFor(Vector3Int position, CellType type)
    {
        // throw new NotImplementedException();

        var neighbourVertices = placementGrid.GetAdjacentCellsOfType(position.x,position.z,type);
        List<Vector3Int> neighbours = new List<Vector3Int>();

        foreach(var point in neighbourVertices)
        {
            neighbours.Add(new Vector3Int(point.X, 0, point.Y));
        }
        return neighbours;
    }

    internal void removeAllTemporaryStructures()
    {
        foreach (var structure in temporaryRoadobjects.Values)
        {
            var position = Vector3Int.RoundToInt(structure.transform.position);
            placementGrid[position.x, position.z] = CellType.Empty;
            Destroy(structure.gameObject);
        }
        temporaryRoadobjects.Clear();
    }

    internal List<Vector3Int> getPathBetween(Vector3Int startPosition, Vector3Int endposition)
    {
        var resultPath = GridSearch.AStarSearch(placementGrid, new Point(startPosition.x, startPosition.z),new Point(endposition.x,endposition.z));
        List<Vector3Int> path = new List<Vector3Int>();
        foreach (Point point  in resultPath)
        {
            path.Add(new Vector3Int(point.X, 0, point.Y));
        }
        return path;
    }

    internal void AddtemporaryStructuresToStructureDictionary()
    {

        foreach (var structure in temporaryRoadobjects)
        {
            structureDictionary.Add(structure.Key, structure.Value);
            DestroyNatureAt(structure.Key);
        }
        temporaryRoadobjects.Clear();
    }

    internal void PlaceObjectOnTheMap(Vector3Int position, GameObject structurePrefab, CellType type)
    {
        placementGrid[position.x, position.z] = type;
        StructureModel structure = CreateANewStructureModel(position, structurePrefab, type);
        structureDictionary.Add(position, structure);
        DestroyNatureAt(position);
    }

    private void DestroyNatureAt(Vector3Int position)
    {
        RaycastHit[] hits = Physics.BoxCastAll(position + new Vector3(0, 0.5f, 0), new Vector3(0.5f, 0.5f, 0.5f), transform.up, Quaternion.identity, 1f, 1 << LayerMask.NameToLayer("Nature"));

        foreach (var item in hits)
        {
            Destroy(item.collider.gameObject);
        }
    }
    public  void PrintStructureDictionary()
    {
        textOutputLocations.text = "";
        foreach (var pair in structureDictionary)
        {
            Vector3Int key = pair.Key;
            StructureModel value = pair.Value;

            // Log key and value to the Unity console
            textOutputLocations.text += $" Key: {key}, Value: {value} \n";
            //Debug.Log($"Key: {key}, Value: {value}");
        }
    }

    public float[] FindCentroidOfHouses()
    {
        float avgX = 0;
        float avgZ = 0;

        foreach (var pair in structureDictionary)
        {
            avgX += pair.Key.x;
            avgZ += pair.Key.y;
        }
        avgX = avgX / structureDictionary.Count;
        avgX = avgZ / structureDictionary.Count;

        float[] centroid = { avgX, avgZ };

        return centroid;
    }
    public float FindDistanceFromCentroid(Vector3Int position)
    {
        float[] centroid = FindCentroidOfHouses();
       

        double Distance = Math.Sqrt((centroid[0] - position.x) * (centroid[0] - position.x) + (centroid[1] - position.z) * (centroid[1] - position.z));

        return (float)Distance;

    }

}
