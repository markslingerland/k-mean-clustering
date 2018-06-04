using System;
using System.Collections.Generic;
using System.Linq;

namespace k_mean_clustering.Algorithms
{
    public static class KMeans
    {
        public static Tuple<List<Cluster>, double> Clustering(int k, int iterations, Dictionary<int, Vector> data){
            //Loop of K-Mean iterations
            var runs = new List<Tuple<List<Cluster>, double>>();
            for(var i = 0; i < iterations; i++){
                // Initialization
                var centroids = Initialization(k, data);

                // Centroids -> Clusters
                var clusters = ToCluster(centroids);

                var newCentroids = new List<List<double>>();
                newCentroids = clusters.Select(c => c.Centroid.Points).ToList();
                var oldCentroids = new List<List<double>>();
                var areEqual = false;
                while(!areEqual)
                {     
                    Step(data, clusters);
                    oldCentroids = newCentroids.ToList();
                    newCentroids = clusters.Select(c => c.Centroid.Points).ToList();
                    for(var c = 0; c < oldCentroids.Count; c++){
                        areEqual = true;
                        if(!oldCentroids[c].SequenceEqual(newCentroids[c])){
                            areEqual = false;
                            break;
                        }
                    }
                }            

                runs.Add(Tuple.Create(clusters, SSE(clusters)));
            }

            return runs.OrderBy(c => c.Item2).First();
        }

        private static void Step (Dictionary<int, Vector> data, List<Cluster> clusters){
            foreach(var cluster in clusters){
                cluster.Points.Clear();
            }

            foreach(var point in data){
                var distances = new List<Tuple<int, double>>();
                for(var c = 0; c < clusters.Count; c++ ){
                    distances.Add(Tuple.Create(c, Euclidean.GetDistance(point.Value, clusters[c].Centroid)));
                }
                var bestDistance = distances.OrderBy(d => d.Item2).First();
                clusters[bestDistance.Item1].Points.Add(point.Value);
            }

            foreach(var cluster in clusters){
                if(cluster.Points.Count > 0){
                    cluster.Centroid = CalculateMean(cluster);
                }
            }            
        }

        private static Vector CalculateMean(Cluster cluster){
            var newCentroid = new List<double>();
            for(var i = 0; i < cluster.Points[0].Points.Count; i++){
                var sum = new List<double>();
                foreach(var point in cluster.Points){
                    sum.Add(point.Points[i]);
                }
                newCentroid.Add(sum.Average());
            }

            return new Vector(newCentroid);
        }

        private static List<Vector> Initialization(int k, Dictionary<int, Vector> data){
            var centroids = new List<Vector>();
            Random rnd = new Random();
            for(var j = 0; j < k; j++){                    
                int UserId = rnd.Next(1, 101);
                if(!centroids.Contains(data[UserId])){
                    centroids.Add(data[UserId]);
                } else {
                    k++;
                }
            } 

            return centroids;
        }

        private static List<Cluster> ToCluster(List<Vector> centroids){
            var clusters = new List<Cluster>();

            for(var t = 0; t < centroids.Count; t++){
                clusters.Add(new Cluster(t, centroids[t]));
            }

            return clusters;
        }

        private static double SSE(List<Cluster> clusters){
            foreach(var cluster in clusters){
                foreach(var point in cluster.Points){
                    point.Distance = Euclidean.GetDistance(cluster.Centroid, point);
                }
            }
            return clusters.Select(c => c.Points.Select(p => Math.Pow(p.Distance.Value,2)).Sum()).Average();
        }        
    }
}