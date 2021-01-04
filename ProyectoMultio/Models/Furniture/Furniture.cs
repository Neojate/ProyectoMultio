using ProyectoMultio.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMultio.Models.Furniture
{
    public class Furniture : Element
    {
        public Furniture()
        {
            Texture = Textures.Furniture;
            IsBlock = false;
        }
    }
}
