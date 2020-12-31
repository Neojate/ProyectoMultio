using ProyectoMultio.Models.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMultio.Models.Character
{
    public class Sheet
    {
        public List<Element> Inventory { get; set; } = new List<Element>();
    }
}
