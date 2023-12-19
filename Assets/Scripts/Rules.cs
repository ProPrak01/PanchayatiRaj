using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Rules : MonoBehaviour
{
    
    public string building;
    public Vector3 buildingPos;

    [SerializeField]
    List<Vector3> allclustercenters = new List<Vector3>();
    int centerpos;

    public int clusterNo;

    int happinessindex;

    public int h;

    [SerializeField]
    public Image happinessSlider;

    public int trafficFactor;

    public Dictionary<string, Vector3[]> Clusters;
    // Start is called before the first frame update
    void Start()
    {
        trafficFactor = 0;
    }
    public void FindCentroidOfHouses(Dictionary<string, Vector3[]> structureDictionary)
    {
      
        List<Vector3> centroidOfClusters = new List<Vector3>();
        foreach (var pair in structureDictionary)
        {
            if(pair.Value == null)
            {
                continue;
            }
            Vector3[] list = pair.Value;
            int length = list.Length;
            Vector3 sum = new Vector3(0,0,0);
            for (int i = 0; i < length; i++)
            {
                sum += list[i] ;
            }
            sum = sum / length;
            centroidOfClusters.Add(sum);

           
        }

        allclustercenters = centroidOfClusters;
    }
    // Update is called once per frame
    void Update()
    {

        float d = calculatingdistancefromCluster(allclustercenters, buildingPos);
       

       // int trafficfactor;
        if (building == "Hospital" || building =="Police Station")
        {
            if (d> (4*clusterNo)  && d<(6*clusterNo))
            {
                int y = (2 * clusterNo);
                float g = (d - (4*clusterNo))/y;
                h = (int)g;
                float f = (float)((h/2)+0.5f);
                happinessSlider.fillAmount = f;
            }
            else if (d < (4 * clusterNo))
            {
                int y = (4 * clusterNo);
                float g = (d - y) / y;
                happinessSlider.fillAmount = g;

            }
            else if(d>(6*clusterNo) && d<(8*clusterNo))
            {
                int y = (2 * clusterNo);
                float g = (d - (6*clusterNo)) / y;

                g = 1 - (g / 2);
                happinessSlider.fillAmount = g;
            }

            else if( d>(8*clusterNo) && d<(16*clusterNo))
            {
                int y = (8 * clusterNo);
                float g = (d - y) / y;
                happinessSlider.fillAmount = 1-g;
            }
            else
            {
                happinessSlider.fillAmount = 0;
            }

        }
        else if(building=="Shop" || building=="Fire Station" || building=="Post Office"|| building=="CSC")
        {
            if (d < (4 * clusterNo)) {
                happinessSlider.fillAmount = 0.5f;
            }
            else if ( trafficFactor>5f  && (d > (4 * clusterNo))){

            }
            else if(d>(8*clusterNo) && d < (16 * clusterNo))
            {

            }
        }

        else if(building=="Bank")
        {
            if (true)
            {

            }
        }
        else if(building=="Public Toilet")
        {
            if (d<(4*(clusterNo)))
            {
                happinessSlider.fillAmount = 0.6f;
            }
            else if (trafficFactor > 5 && ((d>(4*clusterNo)) && (d<(8*clusterNo))))
            {
                happinessSlider.fillAmount = 0.6f ;
            }
        }
        else if (building=="Religious Place")
        {
            if (d < (4 * clusterNo))// inside cluster
            {
                int y = (4 * clusterNo);
                float g = (d - y) / y;
                happinessSlider.fillAmount = -g;
            }
            else if(/*OnRoad side*/ true && (d>(4*clusterNo) && (d<8*clusterNo) )) {
                happinessSlider.fillAmount = 0.5f;
            }
            else if(d > (8 * clusterNo))
            {
                happinessSlider.fillAmount = 0f;
            }
        }else if (building== "Lake")
        {
            if (d < (4 * clusterNo))
            {
                int y = (4 * clusterNo);
                float g = (d - y) / y;
                happinessSlider.fillAmount = -g;
            }
            else if (d>(4*clusterNo) && (d < (8 * clusterNo))){
                int y = (4 * clusterNo);
                float g = (d - y) / y;
                happinessSlider.fillAmount = -g;
            }
            else if(d < (8 * clusterNo)){
                happinessSlider.fillAmount = 0;
                    
            }
        }
        
    }


    private float calculatingdistancefromCluster(List<Vector3> clusterPositns, Vector3 buildingpos)
    {
        float distance=0;
        for(int i=0; i < clusterPositns.Count; i++)
        {
            distance += Vector3.Distance(clusterPositns[i], buildingpos);
        }
        return distance;


    }
}
