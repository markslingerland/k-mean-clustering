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
            Algorithms.KMeans.Clustering(5, 5, customers);
            var debug = 0;
        }
    }
}
