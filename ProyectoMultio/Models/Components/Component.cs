using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProyectoMultio.Helper;
using ProyectoMultio.Models.Cameras;
using ProyectoMultio.Modules.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMultio.Models.Components
{
    public class Component : IRenderizable
    {
        public Texture2D Texture { get; set; }
        public Rectangle Bounds { get; set; }
        public Rectangle SourceRectangle { get; set; }
        public Color BackgroundColor { get; set; } = Color.White;

        public virtual void Render(Camera camera)
        {
            Globals.SpriteBatch.Draw(Texture, Bounds, SourceRectangle, BackgroundColor);
        }
    }
}
