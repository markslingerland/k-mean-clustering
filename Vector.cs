using System.Collections.Generic;

namespace k_mean_clustering
{
   public class Vector
    {
        public Vector(List<double> points)
        {
            Points = points;
        }

        public List<double> Points { get; set; }
        public double? Distance { get; set; }        
    }
}