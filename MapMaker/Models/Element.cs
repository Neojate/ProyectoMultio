using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMultio.Models
{
    public class Element
    {
        public Texture2D Texture { get; set; }

        public Rectangle SourceRectangle { get; set; }

        public bool IsVisible { get; set; }

        public bool IsDiscovered { get; set; }
        
    }
}
