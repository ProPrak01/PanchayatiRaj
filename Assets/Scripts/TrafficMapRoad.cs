using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficMapRoad : MonoBehaviour
{
    public Material blackMaterial;
    public Material GreenHeatMaterial;
    public Material YellowHeatMaterial;
    public Material RedHeatMaterial;


    public int Heat = 0; // Heat variable to track the cumulative heat

    // Define the radius of the imaginary sphere

 
    


    public float sphereRadius = 6f;
    public bool RunLoop = true;

    private void Update()
    {
        // Check for objects with specific tags within the sphere
        Collider[] colliders = Physics.OverlapSphere(transform.position, sphereRadius);
        Heat = 0; // Reset heat value in each update
        int colliderCountVar = colliders.Length;

        
        foreach (var collider in colliders)
        {
                // Check for specific tags and update the Heat value accordingly

            if (collider.CompareTag("Hospital"))
            {
                Heat += 1;
            }
            else if (collider.CompareTag("Bank"))
            {
                Heat += 3;
            }
            else if (collider.CompareTag("Market"))
            {
                Heat += 3;
            }
            else if (collider.CompareTag("OverheadTank"))
            {

                Heat += 4;

            }


            else if (collider.CompareTag("Transformer"))
            {
                Heat += 5;

            }


            else if (collider.CompareTag("PublicToilet"))
            {
                Heat += 2;

            }
            else if (collider.CompareTag("FireStation"))
            {
                Heat += 4;

            }
            else if (collider.CompareTag("PostOffice"))
            {
                Heat += 4;

            }
            else if (collider.CompareTag("PoliceStation"))
            {
                Heat += 6;

            }
            else if (collider.CompareTag("CSC"))
            {
                Heat += 2;

            }

            else if (collider.CompareTag("Panchayat"))
            {
                Heat += 1;

            }

            else if (collider.CompareTag("AanganWadi"))
            {
                Heat += 4;

            }








            // You can add more conditions for other tags as needed
        }

        // Change material based on the Heat value
        if (Heat >= 10)
        {
            //GetComponent<Renderer>().material.;
            GetComponentInChildren<Renderer>().materials[0] = RedHeatMaterial;
        }
        else if(Heat >= 5 && Heat < 10)
        {
            GetComponentInChildren<Renderer>().materials[0] = YellowHeatMaterial;
        }
        else if(Heat > 0 && Heat <  5)
        {
            GetComponentInChildren<Renderer>().materials[0] = GreenHeatMaterial;

        }
        else
        {
            GetComponentInChildren<Renderer>().materials[0] = blackMaterial;

        }

        // Debug visual of the sphere
        // DebugDrawSphere(transform.position, sphereRadius, Color.red);
    }

    // Debug draw sphere method
    /**
    private void DebugDrawSphere(Vector3 center, float radius, Color color)
    {
#if UNITY_EDITOR
        UnityEditor.Handles.color = color;
        UnityEditor.Handles.DrawWireDisc(center, Vector3.up, radius);
#endif
    }
    **/
}
