using MapMaker.Models.Elements;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProyectoMultio.Models.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapMaker.Helpers.Json
{
    public class ElementSerializer : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return false;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jO = JObject.Load(reader);
            bool? IsOpen = (bool?)jO["IsOpen"];

            MapElement mapElement;
            if (IsOpen.GetValueOrDefault())
                mapElement = new Door();
            else
                mapElement = new Structure();

            serializer.Populate(jO.CreateReader(), mapElement);
            return mapElement;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
