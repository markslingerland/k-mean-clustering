using System;
using System.Collections.Generic;

namespace k_mean_clustering.Algorithms
{
    public static class KMeans
    {
        public static List<Vector> Clustering(int k, int iterations, Dictionary<int, Vector> data){
            // for(var i = 0; i < iterations; i++){
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
        // }
    }
}