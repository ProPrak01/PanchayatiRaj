using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ClusterAnalysis : MonoBehaviour
{
   // public List<Vector3> houseCoords; // Change the type to List<Vector3>

    public int BestKValue(List<Vector3> houseCoords) // Change the parameter type to List<Vector3>
    {
        int[] kValues = new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        List<double> silhouetteScores = new List<double>();

        foreach (int k in kValues)
        {
            int[] assignments = PerformKMeans(houseCoords.ToArray(), k); // Convert List<Vector3> to Vector3[]
            double silhouetteAvg = CalculateSilhouetteScore(houseCoords.ToArray(), assignments); // Convert List<Vector3> to Vector3[]
            silhouetteScores.Add(silhouetteAvg);
        }

        double maxValue = silhouetteScores.Max();
        int maxIndex = silhouetteScores.IndexOf(maxValue) + 2;

        return maxIndex;
    }

    public int[] PerformKMeans(Vector3[] points, int k)
    {
        int[] assignments = new int[points.Length];
        Vector3[] centroids = new Vector3[k];

        // Randomly initialize centroids
        for (int i = 0; i < k; i++)
        {
            centroids[i] = Random.insideUnitSphere;
        }

        bool converged = false;

        while (!converged)
        {
            // Assign points to nearest centroid
            for (int i = 0; i < points.Length; i++)
            {
                float minDistance = float.MaxValue;
                int minIndex = -1;

                for (int j = 0; j < centroids.Length; j++)
                {
                    float distance = Vector3.Distance(points[i], centroids[j]);

                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        minIndex = j;
                    }
                }

                assignments[i] = minIndex;
            }

            // Update centroids
            Vector3[] newCentroids = new Vector3[centroids.Length];
            int[] centroidCounts = new int[centroids.Length];

            for (int i = 0; i < points.Length; i++)
            {
                int clusterIndex = assignments[i];
                newCentroids[clusterIndex] += points[i];
                centroidCounts[clusterIndex]++;
            }

            for (int i = 0; i < centroids.Length; i++)
            {
                if (centroidCounts[i] > 0)
                {
                    newCentroids[i] /= centroidCounts[i];
                }
            }

            // Check convergence
            converged = true;

            for (int i = 0; i < centroids.Length; i++)
            {
                if (Vector3.Distance(centroids[i], newCentroids[i]) > 0.01f)
                {
                    converged = false;
                    break;
                }
            }

            centroids = newCentroids;
        }

        return assignments;
    }

    public double CalculateSilhouetteScore(Vector3[] points, int[] assignments)
    {
        double silhouetteSum = 0.0;
        int totalPoints = points.Length;

        for (int i = 0; i < totalPoints; i++)
        {
            int clusterIndex = assignments[i];
            Vector3 point = points[i];

            double a = 0.0; // Average distance to other points in the same cluster (intra-cluster distance)
            double b = double.MaxValue; // Minimum average distance to points in different clusters (inter-cluster distance)

            int clusterSize = 0;

            for (int j = 0; j < totalPoints; j++)
            {
                if (assignments[j] == clusterIndex)
                {
                    a += Vector3.Distance(point, points[j]);
                    clusterSize++;
                }
                else
                {
                    double distance = Vector3.Distance(point, points[j]);
                    b = Mathf.Min((float)b, (float)distance);
                }
            }

            if (clusterSize > 0)
            {
                a /= clusterSize;

                double silhouette = (b - a) / Mathf.Max((float)a, (float)b);

                silhouetteSum += silhouette;
            }
        }

        double silhouetteAvg = silhouetteSum / totalPoints;
        return silhouetteAvg;
    }

    public Dictionary<string, List<Vector3>> GetCluster(List<Vector3> houseCoords) // Change the parameter type to List<Vector3>
    {
        int kOptimal = BestKValue(houseCoords);
        int[] clusterLabels = PerformKMeans(houseCoords.ToArray(), kOptimal); // Convert List<Vector3> to Vector3[]

        Dictionary<string, List<Vector3>> clusters = new Dictionary<string, List<Vector3>>();
        for (int i = 0; i < kOptimal; i++)
        {
            List<Vector3> clusterPoints = new List<Vector3>();

            for (int j = 0; j < houseCoords.Count; j++) // Change the array length to List count
            {
                if (clusterLabels[j] == i)
                {
                    clusterPoints.Add(houseCoords[j]);
                }
            }

            clusters.Add($"Cluster {i + 1}", clusterPoints);
        }

        return clusters;
    }
}