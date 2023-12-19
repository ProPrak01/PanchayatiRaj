using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra.Double.Solvers;
using MathNet.Numerics.LinearAlgebra.Double.Solvers.Iterative;
using MathNet.Numerics.Providers.LinearAlgebra;

using Accord.MachineLearning;
using Accord.MachineLearning.VectorMachines;
using Accord.MachineLearning.VectorMachines.Learning;
using Accord.MachineLearning.VectorMachines.SupportVectorMachines;
using Accord.MachineLearning.VectorMachines.Learning;
using Accord.Statistics.Kernels;

namespace Clustering
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix<double> houseCoords = DenseMatrix.OfArray(new double[,]{
                {1, 2},
                {3, 4},
                {5, 6},
                {7, 8},
                {9, 10}
            });

            int kOptimal = BestKValue(houseCoords);
            Dictionary<string, Matrix<double>> clusters = GetCluster(houseCoords, kOptimal);

            Console.WriteLine("Optimal k value: " + kOptimal);

            foreach (var cluster in clusters)
            {
                Console.WriteLine(cluster.Key);
                Console.WriteLine(cluster.Value);
                Console.WriteLine();
            }
        }

        static int BestKValue(Matrix<double> houseCoords)
        {
            List<int> kValues = Enumerable.Range(2, 9).ToList();
            List<double> silhouetteScores = new List<double>();

            for (int i = 0; i < kValues.Count; i++)
            {
                int k = kValues[i];
                KMeans kmeans = new KMeans(k);
                int[] clusterLabels = kmeans.Clustering(houseCoords.ToArray());

                double silhouetteAvg = SilhouetteScore(houseCoords.ToArray(), clusterLabels);
                silhouetteScores.Add(silhouetteAvg);
            }

            double maxValue = silhouetteScores.Max();
            int maxIndex = silhouetteScores.IndexOf(maxValue) + 2;

            return maxIndex;
        }

        static double SilhouetteScore(double[][] coordinates, int[] clusterLabels)
        {
            double silhouetteSum = 0;

            for (int i = 0; i < coordinates.Length; i++)
            {
                double averageDistanceToOtherClusters = 0;
                int clusterLabel = clusterLabels[i];

                for (int j = 0; j < coordinates.Length; j++)
                {
                    if (i != j && clusterLabels[j] != clusterLabel)
                    {
                        double distance = EuclideanDistance(coordinates[i], coordinates[j]);
                        averageDistanceToOtherClusters += distance;
                    }
                }

                averageDistanceToOtherClusters /= coordinates.Length - 1;

                double minDistanceInCluster = double.MaxValue;
                for (int j = 0; j < coordinates.Length; j++)
                {
                    if (i != j && clusterLabels[j] == clusterLabel)
                    {
                        double distance = EuclideanDistance(coordinates[i], coordinates[j]);
                        if (distance < minDistanceInCluster)
                            minDistanceInCluster = distance;
                    }
                }

                double silhouetteCoefficient = (minDistanceInCluster - averageDistanceToOtherClusters) / Math.Max(minDistanceInCluster, averageDistanceToOtherClusters);
                silhouetteSum += silhouetteCoefficient;
            }

            double silhouetteAvg = silhouetteSum / coordinates.Length;
            return silhouetteAvg;
        }

        static double EuclideanDistance(double[] a, double[] b)
        {
            double sum = 0;
            for (int i = 0; i < a.Length; i++)
            {
                sum += Math.Pow(a[i] - b[i], 2);
            }
            return Math.Sqrt(sum);
        }

        static Dictionary<string, Matrix<double>> GetCluster(Matrix<double> houseCoords, int kOptimal)
        {
            KMeans kmeans = new KMeans(kOptimal);
            int[] clusterLabels = kmeans.Clustering(houseCoords.ToArray());

            Dictionary<string, Matrix<double>> clusters = new Dictionary<string, Matrix<double>>();
            for (int i = 0; i < kmeans.Clusters.Length; i++)
            {
                string key = "Cluster " + (i + 1);
                Matrix<double> clusterPoints = DenseMatrix.OfArray(houseCoords.ToArray())
                    .Where((row, index) => clusterLabels[index] == i)
                    .ToRowMatrix();
                clusters.Add(key, clusterPoints);
            }

            return clusters;
        }
    }
}