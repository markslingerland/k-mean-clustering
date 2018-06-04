using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace k_mean_clustering
{
    class Program
    {
        static void Main(string[] args)
        {
            var customers = Parser.GetData();
            var result = Algorithms.KMeans.Clustering(5, 5, customers);
            Console.WriteLine($"SSE: {result.Item2}");
            foreach(var cluster in result.Item1){
                var purchases = new Dictionary<int,double>();
                foreach(var point in cluster.Points){
                    for(var i = 0; i < point.Points.Count; i++){
                        if(purchases.ContainsKey(i)){
                            purchases[i] += point.Points[i];
                        } else {
                            purchases.Add(i, point.Points[i]);
                        }
                    }
                }
                Console.WriteLine($"----------Cluster {cluster.Id}----------");
                var preferredPurchases = purchases.Where(c => c.Value > 3).ToList();
                var orderedList = preferredPurchases.OrderByDescending(p => p.Value).ToList();
                foreach(var purchase in orderedList){
                    Console.WriteLine($"Offer {purchase.Key} is bought {purchase.Value} times.");
                }
                Console.WriteLine("----------------------------------------");
            }
        }
    }
}
