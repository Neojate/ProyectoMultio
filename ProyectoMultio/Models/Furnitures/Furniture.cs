using ProyectoMultio.Helper;
using ProyectoMultio.Models.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMultio.Models.Furnitures
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
