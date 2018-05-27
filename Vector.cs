using System.Collections.Generic;

namespace k_mean_clustering
{
   public class Vector
    {
        public Vector(List<float> points)
        {
            Points = points;
        }

        public List<float> Points { get; set; }
        public double? Distance { get; set; }        
    }
}