using MapMaker.Actions;
using MapMaker.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapMaker.MapMaker
{
    public class UIElement : IRenderizable
    {
        //Textura (png/jpg) que usa el Elemento
        public Texture2D Texture { get; set; } = Textures.Background;

        //Destinacion del elemento (x, y, width, height)
        public Rectangle Bounds { get; set; }

        //Cacho de la textura que dibujará (x, y, width, height)
        public Rectangle SourceRectangle { get; set; }

        //Color de la textura. Blanco neutro.
        public Color BackgroundColor = Color.White;
        
        public virtual void Render()
        {
            Globals.SpriteBatch.Draw(Texture, Bounds, SourceRectangle, BackgroundColor);
        }
    }
}
