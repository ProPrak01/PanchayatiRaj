using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficMapRoad : MonoBehaviour
{
   // public Material originalMaterial;
    //public Material HeatMaterial;

    public int Heat = 0; // Heat variable to track the cumulative heat

    // Define the radius of the imaginary sphere
    public float sphereRadius = 5f;

    private void Update()
    {
        // Check for objects with specific tags within the sphere
        Collider[] colliders = Physics.OverlapSphere(transform.position, sphereRadius);
        Heat = 0; // Reset heat value in each update

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
                Heat += 7;
            }

            // You can add more conditions for other tags as needed
        }

        // Change material based on the Heat value
        if (Heat >= 10)
        {
            //GetComponent<Renderer>().material.;
            GetComponent<Renderer>().material.SetFloat("_YourFloatPropertyName", 0.1f);
        }
        else
        {
            GetComponent<Renderer>().material.SetFloat("_YourFloatPropertyName", 10f);
        }

        // Debug visual of the sphere
        DebugDrawSphere(transform.position, sphereRadius, Color.red);
    }

    // Debug draw sphere method
    private void DebugDrawSphere(Vector3 center, float radius, Color color)
    {
#if UNITY_EDITOR
        UnityEditor.Handles.color = color;
        UnityEditor.Handles.DrawWireDisc(center, Vector3.up, radius);
#endif
    }
}
