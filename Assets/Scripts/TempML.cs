using System;
using System.Collections.Generic;
using System.Linq;
using Python.Runtime; // Make sure to include this

class Program
{
    static void Main()
    {
        // Initialize the Python runtime
        using (Py.GIL())
        {
            dynamic np = Py.Import("numpy");
            dynamic skLearn = Py.Import("sklearn.cluster");
            dynamic warnings = Py.Import("warnings");

            // Suppress warnings from scikit-learn for demonstration purposes
            warnings.filterwarnings("ignore", ".*");

            // Example usage:
            List<double[]> houseCoords = new List<double[]>
            {
                new double[] {1.0, 2.0},
                new double[] {3.0, 4.0},
                new double[] {5.0, 6.0},
                // Add more coordinates as needed
            };

            int optimalK = BestKValue(houseCoords, np, skLearn);
            Console.WriteLine($"Optimal K: {optimalK}");

            dynamic clusters = GetCluster(houseCoords, optimalK, np, skLearn);
            Console.WriteLine("Clusters:");
            foreach (var cluster in clusters)
            {
                Console.WriteLine($"{cluster.Key}:");
                foreach (var point in cluster.Value)
                {
                    Console.WriteLine($"  ({string.Join(", ", point)})");
                }
            }
        }
    }

    static int BestKValue(List<double[]> houseCoords, dynamic np, dynamic skLearn)
    {
        // To find the best value of k, which will cluster the given points into k clusters
        List<int> kValues = Enumerable.Range(2, 10).ToList();
        List<double> silhouetteScores = new List<double>();

        // Perform the k-means clustering for each value of k
        foreach (int k in kValues)
        {
            double[,] data = ConvertTo2DArray(houseCoords);
            dynamic kMeans = skLearn.KMeans(n_clusters: k);

            dynamic clusterLabels = kMeans.fit_predict(data);
            double silhouetteAvg = SilhouetteScoreFunc(data, clusterLabels,skLearn);
            silhouetteScores.Add(silhouetteAvg);
        }

        // Find the index of the maximum silhouette score and add 2 to get the optimal k
        int maxIndex = silhouetteScores.IndexOf(silhouetteScores.Max()) + 2;

        return maxIndex;
    }

    static dynamic GetCluster(List<double[]> houseCoords, int kOptimal, dynamic np, dynamic skLearn)
    {
        // Get the coordinate locations along with the cluster numbers to which they belong
        double[,] data = ConvertTo2DArray(houseCoords);
        dynamic kMeans = skLearn.KMeans(n_clusters: kOptimal);

        dynamic clusterLabels = kMeans.fit_predict(data);
        dynamic centers = kMeans.cluster_centers_;

        Dictionary<string, List<double[]>> clusters = new Dictionary<string, List<double[]>>();
        for (int i = 0; i < kOptimal; i++)
        {
            List<double[]> clusterPoints = houseCoords.Where((coord, index) => clusterLabels[index] == i).ToList();
            clusters.Add($"Cluster {i + 1}", clusterPoints);
        }

        return clusters;
    }

    static double SilhouetteScoreFunc(double[,] data, dynamic clusterLabels, dynamic skLearn)
    {
        // Convert the clusterLabels to a Python list
        dynamic pyClusterLabels = ToPythonList(clusterLabels);

        // Import the silhouette_score function from scikit-learn
        dynamic silhouetteScoreFunc = skLearn.metrics.silhouette_score;

        // Call the silhouette_score function with the data and clusterLabels
        dynamic silhouetteScore = silhouetteScoreFunc(data, pyClusterLabels);

        // Convert the result back to C# double
        double result = Convert.ToDouble(silhouetteScore);

        return result;
    }

    // Helper function to convert a C# list to a Python list
    static dynamic ToPythonList(IEnumerable<int> list)
    {
        using (Py.GIL())
        {
            dynamic np = Py.Import("numpy");
            return np.array(list.ToArray());
        }
    }

    static double[,] ConvertTo2DArray(List<double[]> data)
    {
        // Convert List<double[]> to 2D array
        int rows = data.Count;
        int cols = data[0].Length;
        double[,] result = new double[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = data[i][j];
            }
        }

        return result;
    }
}