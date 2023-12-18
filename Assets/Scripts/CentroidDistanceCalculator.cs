using UnityEngine;

public class CentroidDistanceCalculator : MonoBehaviour
{
    private void Start()
    {
        double[,] coordinates = {
            { 3, 5 },
            { 12, 18 },
            { 25, 9 },
            { 8, 22 },
            { 20, 7 },
            { 1, 15 },
            { 16, 4 },
            { 28, 11 },
            { 9, 29 },
            { 6, 26 },
            { 14, 19 },
            { 24, 2 },
            { 11, 12 },
            { 27, 23 },
            { 5, 10 },
            { 17, 27 },
            { 30, 14 },
            { 22, 6 },
            { 4, 21 },
            { 19, 8 },
            { 2, 17 },
            { 10, 25 },
            { 21, 1 },
            { 13, 13 },
            { 29, 24 }
        };

        double[] centroid = CalculateCentroid(coordinates);

        Debug.Log($"Centroid: ({centroid[0]}, {centroid[1]})");

        // For simplicity, you can input the point directly here, or you can create a UI for user input
        double pointX = 15; // Example x-coordinate of the point
        double pointY = 20; // Example y-coordinate of the point

        double distance = CalculateDistance(centroid[0], centroid[1], pointX, pointY);
        Debug.Log($"Distance between centroid and provided point: {distance}");
    }

    public double[] CalculateCentroid(double[,] coordinates)
    {
        int numOfPoints = coordinates.GetLength(0);
        double sumX = 0, sumY = 0;

        for (int i = 0; i < numOfPoints; i++)
        {
            sumX += coordinates[i, 0];
            sumY += coordinates[i, 1];
        }

        double centroidX = sumX / numOfPoints;
        double centroidY = sumY / numOfPoints;

        return new double[] { centroidX, centroidY };
    }

    public double CalculateDistance(double x1, double y1, double x2, double y2)
    {
        double distance = Mathf.Sqrt(Mathf.Pow((float)(x2 - x1), 2) + Mathf.Pow((float)(y2 - y1), 2));
        return distance;
    }
}
