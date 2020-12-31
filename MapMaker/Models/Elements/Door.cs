using JsonSubTypes;
using MapMaker.Models.Elements;
using Newtonsoft.Json;

namespace ProyectoMultio.Models.Elements
{
    public class Door : Structure
    {
        public bool IsOpen { get; set; } = false;
    }
}
