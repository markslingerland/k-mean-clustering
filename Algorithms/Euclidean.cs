using System;

namespace k_mean_clustering.Algorithms
{
    public static class Euclidean
    {
        public static double GetDistance(Vector user1, Vector user2){
            
            double result = 0;

            for (int i = 0; i < user1.Points.Count; i++)
            {
                result += Math.Pow((user1.Points[i] - user2.Points[i]),2);
            }

            result = 1 / (1 + Math.Sqrt(result));

            return result;
        }
    }
}