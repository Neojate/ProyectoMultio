using ProyectoMultio.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMultio.Models.Structures
{
    public class Structure : Element
    {
        public Structure()
        {
            Texture = Textures.Structures;
            IsBlock = true;
        }
    }
}
