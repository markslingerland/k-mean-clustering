using System.Collections.Generic;
using System.Linq;

namespace k_mean_clustering
{
    public static class Parser
    {
        public static List<Vector> GetData(){
            //Parser
            var list = new List<Vector>();
            var lines = System.IO.File.ReadAllLines(@"WineData.csv").Select(l => l.Split(",")).ToList();

            for (int i = 0; i < lines[0].Length; i++)
            {
                var values = new List<float>();
                foreach(var line in lines){
                    values.Add(float.Parse(line[i]));
                }                
                
                var vector = new Vector(values);
                list.Add(vector);         
            }
            return list;
        }
    }
}