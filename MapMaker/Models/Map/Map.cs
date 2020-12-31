using JsonSubTypes;
using MapMaker.Helpers;
using MapMaker.Models.Elements;
using MapMaker.Models.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using ProyectoMultio.Models.Elements;
using System.Collections.Generic;
using System.IO;

namespace ProyectoMultio.Models.Map
{
    public class Map
    {
        public Tile[,] Scenario { get; set; }
        public Point Size { get; set; } = new Point(30, 30);

        //public List<IZerializable> Elements { get; set; } = new List<IZerializable>();
        public List<MapElement> X = new List<MapElement>();

        //Creamos el mapa inicial
        public Map()
        {
            Scenario = new Tile[Size.X, Size.Y];
            for (int y = 0; y < Size.Y; y++)
                for (int x = 0; x < Size.X; x++)
                    Scenario[x, y] = Utils.GetTile(TileType.Void);
        }

        public Map LoadMap(string mapName)
        {
            Map map = new Map();
            using (StreamReader file = File.OpenText($"{mapName}.json"))
            {
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    map = serializer.Deserialize<Map>(reader);
                }
            }
            return map;
        }

        public void SaveMap(string mapName)
        {
            using (StreamWriter file = File.CreateText($"{mapName}.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, this);
            }
        }

        public void Prueba()
        {
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(JsonSubtypesConverterBuilder
                .Of<Map>("Type")
                .RegisterSubtype<Door>(1)
                .SerializeDiscriminatorProperty()
                .Build());
            //using (StreamWriter file = File.CreateText("prueba.json"))
            //{
            //    JsonSerializer serializer = new JsonSerializer();
            //    serializer.Serialize(file, X);
            //}

            var json = JsonConvert.SerializeObject(X, settings);

            var result = JsonConvert.DeserializeObject<Map>(json, settings);

            //List<MapElement> elements = new List<MapElement>();
            //using (StreamReader file = File.OpenText("prueba.json"))
            //{
            //    var animal = JsonConvert.DeserializeObject<MapElement>(file.ReadToEnd());
            //    using (JsonTextReader reader = new JsonTextReader(file))
            //    {
            //        JsonSerializer serializer = new JsonSerializer();
            //        elements = serializer.Deserialize<List<MapElement>>(reader);
            //    }
            //}

        }
    }
}
