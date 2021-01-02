using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMultio.Helper
{
    public class Lang
    {
        private static Dictionary<string, string> dictionary { get; set; } = new Dictionary<string, string>();

        public static string Trans(string key)
        {
            return dictionary[key];
        }

        public static void Load()
        {
            temp();
            Save();
        }

        private static void temp()
        {
            //FURNITURE
            dictionary.Add("door", "Puerta");

            //ITEMS
            dictionary.Add("marker", "Pistola de super pintura");

            //METODOS
            dictionary.Add("Use", "Usar");
            dictionary.Add("Grab", "Coger");
        }

        public static void Save()
        {
            using (StreamWriter writer = File.CreateText("es-ES.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(writer, dictionary);
            }
        }
    }
}
