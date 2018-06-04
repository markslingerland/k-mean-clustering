using System.Collections.Generic;
using System.Linq;

namespace k_mean_clustering
{
    public static class Parser
    {
        public static Dictionary<int, Vector> GetData(){
            //Parser
            var list = new Dictionary<int, Vector>();
            var lines = System.IO.File.ReadAllLines(@"WineData.csv").Select(l => l.Split(",").Select(i => double.Parse(i)).ToList()).ToList();

            for (int i = 0; i < lines[0].Count; i++)
            {
                var values = new List<double>();
                foreach(var line in lines){
                    values.Add(line[i]);
                }                
                
                var vector = new Vector(values);
                list.Add(i + 1, vector);         
            }
            return list;
        }
    }
}