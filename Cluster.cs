using System.Collections.Generic;

namespace k_mean_clustering
{
    public class Cluster
    {
        public int Id { get; set; }
        public Vector Centroid { get; set; }
        public List<Vector> Points { get; set; }

        public Cluster(int id, Vector centroid)
        {
            Id = id;
            Centroid = centroid;
            Points = new List<Vector>();
        }
    }
}