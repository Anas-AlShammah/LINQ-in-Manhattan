using Newtonsoft.Json;

namespace LINQManhattan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            var text = File.ReadAllText(@"./data.json");

            Rootobject rootObject = JsonConvert.DeserializeObject<Rootobject>(text);
        
            Feature[] features = rootObject.features;
            var list =from feature in features
                      select feature.properties.neighborhood;
            var list2 = from n in list
                        where n !=""
                        select n;   
            var list3 = list2.Distinct();
            var list4 = (from feature in features
                         where feature.properties.neighborhood != ""
                         select feature.properties.neighborhood).Distinct();
            var list5 = list.Where(e=>e!="").ToList();


            foreach (var feature in list)
            {
                Console.WriteLine(feature);
            }

            foreach (var feature in list2)
            {
                Console.WriteLine(feature);
            }

            foreach (var feature in list3)
            {
                Console.WriteLine(feature);
            }

            foreach (var feature in list4)
            {
                Console.WriteLine(feature);
            }

            foreach (var feature in list5)
            {
                Console.WriteLine(feature);
            }
        }
        public class Rootobject
    {
        public string type { get; set; }
            public Feature[] features { get; set; }
        }

        public class Feature
        {
            public string type { get; set; }
            public Geometry geometry { get; set; }
            public Properties properties { get; set; }
        }

        public class Geometry
        {
            public string type { get; set; }
            public float[] coordinates { get; set; }
        }

        public class Properties
        {
            public string zip { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public string address { get; set; }
            public string borough { get; set; }
            public string neighborhood { get; set; }
            public string county { get; set; }
        }

    }
}